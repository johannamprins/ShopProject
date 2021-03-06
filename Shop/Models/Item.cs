﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set;}
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool IsOnsale { get; set; }
        public bool IsInStock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } // one item has one category, one category can have many items - so 1 to * relationship
    }
}
