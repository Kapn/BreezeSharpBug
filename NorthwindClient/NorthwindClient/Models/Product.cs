using Breeze.Sharp;
using System;
using System.Collections.Generic;


namespace NorthwindModel.Models
{
    public partial class Product : BaseEntity
    {
        public Product()
        {
            OrderItems = new NavigationSet<OrderItem>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public decimal? UnitPrice { get; set; }
        public string Package { get; set; }
        public bool IsDiscontinued { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual NavigationSet<OrderItem> OrderItems { get; set; }
    }
}
