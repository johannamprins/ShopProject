﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class ItemController :Controller 
        //inherits from controller, gives us all functionality of a c
        //but is still a class
    {
        private readonly IItemRepository _itemRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ItemController(IItemRepository itemRepository, ICategoryRepository categoryRepository)
        {
            _itemRepository = itemRepository;
            _categoryRepository = categoryRepository;
        }
         
        public IActionResult List() // builtin type for MVC, returns a view
        {
            // ViewBag.CurrentCategory = "Bestsellers"; 
            //return View(_itemRepository.GetAllItem);

            //changing from viewbag to Viewmodel, bc is a class
            //that will contain all the data in the view
            //and will be constructed in the controller
            //then passed to the view
 

            var itemListViewModel = new ItemListViewModel();
            itemListViewModel.Items = _itemRepository.GetAllItem;
            itemListViewModel.CurrentCategory = "Bestsellers";
            return View(itemListViewModel);

        }
    }
}
