﻿using GoodHamburguerAPI.Model;

namespace GoodHamburguerAPI.DTO
{
    public class ProductsWithDiscount
    {
        public List<Product> Products { get; set; }
        public decimal DiscountApplyed { get; set; }
        public decimal total_price { get; set; }
    }
}
