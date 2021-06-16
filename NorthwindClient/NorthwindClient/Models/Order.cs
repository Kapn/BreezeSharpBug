using Breeze.Sharp;
using System;

namespace NorthwindModel.Models
{
    public partial class Order : BaseEntity
    {
        public Order()
        {
        }

        public int Id { get { return GetValue<int>(); } set { SetValue(value); } }
        public DateTime OrderDate { get { return GetValue<DateTime>(); } set { SetValue(value); } }
        public string OrderNumber { get { return GetValue<string>(); } set { SetValue(value); } }
        public int CustomerId { get { return GetValue<int>(); } set { SetValue(value); } }
        public decimal? TotalAmount { get { return GetValue<decimal?>(); } set { SetValue(value); } }

        public virtual Customer Customer { get { return GetValue<Customer>(); } set { SetValue(value); } }
        public virtual NavigationSet<OrderItem> OrderItems { get { return GetValue<NavigationSet<OrderItem>>(); } }
    }
}
