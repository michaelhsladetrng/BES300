﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingApi.Data;
using ShoppingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApi.Controllers
{
    public class ShoppingListController : ControllerBase
    {
        private readonly ShoppingDataContext DataContext;
        private readonly IMapper Mapper;
        private readonly MapperConfiguration MapperConfig;

        public ShoppingListController(ShoppingDataContext dataContext, IMapper mapper, MapperConfiguration mapperConfig)
        {
            DataContext = dataContext;
            Mapper = mapper;
            MapperConfig = mapperConfig;
        }

        [HttpGet("shoppinglist")]
        public  async Task<ActionResult> GetFullShoppingList()
        {
            var response = new GetShoppingListResponse();

            response.Data = await DataContext.ShoppingItems
                .ProjectTo<ShoppingListItemResponse>(MapperConfig).ToListAsync();
                //.Select(item => Mapper.Map<ShoppingListItemResponse>(item)).ToListAsync();

                //.Select(item => new ShoppingListItemResponse
                //{
                //    Id = item.Id,
                //    Description = item.Description,
                //    Purchased = item.Purchased
                //}).ToListAsync();

            return Ok(response);
        }
    }
}
