using Breeze.Persistence.EFCore;
using NorthwindModel.Models;

namespace NorthwindServer
{
    public class NorthwindCorePersistenceManager : EFPersistenceManager<NorthwindContext>
    {
        public NorthwindCorePersistenceManager(NorthwindContext dbContext) : base(dbContext) { }
    }    
}
