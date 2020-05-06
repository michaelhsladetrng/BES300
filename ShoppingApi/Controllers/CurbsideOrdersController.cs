using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Infrastructure;
using ShoppingApi.Data;
using ShoppingApi.Mappers;
using ShoppingApi.Models;
using ShoppingApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingApi.Controllers
{
    public class CurbsideOrdersController : ControllerBase 
    {
        private readonly IMapCurbsideOrders CurbsideMapper;
        private readonly CurbsideChannel TheChannel;
        private readonly ShoppingDataContext Context;

        public CurbsideOrdersController(IMapCurbsideOrders curbsideMapper, CurbsideChannel theChannel, ShoppingDataContext context)
        {
            CurbsideMapper = curbsideMapper;
            TheChannel = theChannel;
            Context = context;
        }

        [HttpPost("curbsideordersync")]
        public async Task<ActionResult> PlaceOrderSynchronously([FromBody] CreateCurbsideOrder orderToPlace)
        {
            var temp = await CurbsideMapper.PlaceOrder(orderToPlace);
            for (var t = 0; t < temp.Items.Count; t++)
            {
                Thread.Sleep(1000);
            }
            temp.Status = CurbsideOrderStatus.Processed;
            var order = await Context.SaveChangesAsync();
            return Ok(temp); // not going to map it... just want you to see.
        }

        [HttpPost("curbsideorders")]
        public async Task<ActionResult> PlaceOrder([FromBody] CreateCurbsideOrder orderToPlace)
        {
            // 1. Validate It (bad? return 400)
            // 2. Save it to the database - (e.g. do domain stuff)
            // 3. Return
            //      201 Created
            //      Location Header with the location of the new resource
            //      A copy of the entity they would get if they did a GET to the location
            CurbsideOrder response = await CurbsideMapper.PlaceOrder(orderToPlace);

            await TheChannel.AddCurbsideOrder(new CurbsideChannelRequest { OrderId = response.Id });

            return Ok(response);
        }

        [HttpGet("curbsideorders/{id:int}")]
        public async Task<ActionResult<CurbsideOrder>> GetById(int id)
        {
            CurbsideOrder response = await CurbsideMapper.GetOrderById(id);
            if (response == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }

        }
    }
}
