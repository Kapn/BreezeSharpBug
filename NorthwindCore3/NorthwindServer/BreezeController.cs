using Breeze.AspNetCore;
using Breeze.Persistence;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using NorthwindModel.Models;
using System.Linq;

namespace NorthwindServer
{
    [Route("api/[controller]/[action]")]
    [BreezeQueryFilter]
    public class BreezeController : Controller
    {
        private NorthwindCorePersistenceManager persistenceManager;
        public BreezeController(NorthwindContext dbContext)
        {
            persistenceManager = new NorthwindCorePersistenceManager(dbContext);
        }

        [HttpGet]
        public IQueryable<Customer> Customers()
        {
            return persistenceManager.Context.Customers;
        }
        [HttpGet]
        public IQueryable<Order> Orders()
        {
            return persistenceManager.Context.Orders;
        }
        [HttpGet]
        public IQueryable<OrderItem> OrderItems()
        {
            return persistenceManager.Context.OrderItems;
        }
        [HttpGet]
        public IQueryable<Product> Products()
        {
            return persistenceManager.Context.Products;
        }
        [HttpGet]
        public IQueryable<Supplier> Suppliers()
        {
            return persistenceManager.Context.Suppliers;
        }

        [HttpPost]
        public ActionResult<SaveResult> SaveChanges([FromBody] JObject saveBundle)
        {
            return persistenceManager.SaveChanges(saveBundle);
        }

        [HttpGet]
        public string Metadata()
        {
            return persistenceManager.Metadata();
        }
    }
}
