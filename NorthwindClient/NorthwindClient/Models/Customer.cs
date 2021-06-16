using Breeze.Sharp;

namespace NorthwindModel.Models
{
    public partial class Customer : BaseEntity
    {
        public Customer()
        {
        }

        public int Id { get { return GetValue<int>(); } set { SetValue(value); } }
        public string FirstName { get { return GetValue<string>(); } set { SetValue(value); } }
        public string LastName { get { return GetValue<string>(); } set { SetValue(value); } }
        public string City { get { return GetValue<string>(); } set { SetValue(value); } }
        public string Country { get { return GetValue<string>(); } set { SetValue(value); } }
        public string Phone { get { return GetValue<string>(); } set { SetValue(value); } }

        public virtual NavigationSet<Order> Orders { get { return GetValue<NavigationSet<Order>>(); } }
    }
}
