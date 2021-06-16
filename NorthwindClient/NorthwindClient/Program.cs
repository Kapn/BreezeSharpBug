using Breeze.Sharp;
using NorthwindModel.Models;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindClient
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            // probe some assemblies
            Configuration.Instance.ProbeAssemblies(new System.Reflection.Assembly[] { typeof(Order).Assembly });
            Configuration.Instance.ProbeAssemblies(new System.Reflection.Assembly[] { typeof(Customer).Assembly });
            Configuration.Instance.QueryUriStyle = QueryUriStyle.JSON;

            // setup/create EntityManager
            var serverPort = 5001;
            var entityManager = new EntityManager($"https://localhost:{serverPort}/api/breeze");

            // Allow use of a partial model of server entities
            entityManager.MetadataStore.AllowedMetadataMismatchTypes = MetadataMismatchTypes.AllAllowable;

            // Query for an Order, Expanding on Customer
            var orderToModifyQuery = EntityQuery.From<Order>().Where(o => o.Id == 1).Expand("Customer");
            var result = await entityManager.ExecuteQuery(orderToModifyQuery);
            var orderWithCustomer = result.First();

            // modify our found Customer entity
            orderWithCustomer.Customer.FirstName = "Modified";

            // query for Order again -- error is thrown here in JsonEntityConverter.ParseObject
            // backingStore is null and crashes on line 258 of JsonEntityConverter
            // line 258: if (backingStore.TryGetValue(key, out tmp)) {
            var secondResult = await entityManager.ExecuteQuery(orderToModifyQuery);

            // we don't get here
            var copy = secondResult.First();
            var customers = result.ToList();
        }
    }
}
