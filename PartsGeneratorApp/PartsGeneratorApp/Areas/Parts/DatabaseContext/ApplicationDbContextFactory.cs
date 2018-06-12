using PartsGeneratorApp.Shared.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartsGeneratorApp.Areas.Parts.DatabaseContext
{
    public class ApplicationDbContextFactory : DesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationDbContextFactory()
        {
            _databaseName = "ApplicationConnection";
        }
    }
}
