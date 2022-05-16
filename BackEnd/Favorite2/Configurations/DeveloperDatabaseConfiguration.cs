using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Favorite2.Configurations
{
    public class DeveloperDatabaseConfiguration : IDeveloperDatabaseConfiguration //Configuration Model to access MongoDB instance in DI
    {

        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string FavoriteCollectionName { get; set; }
    }

    public interface IDeveloperDatabaseConfiguration
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string FavoriteCollectionName { get; set; }
    }
}
