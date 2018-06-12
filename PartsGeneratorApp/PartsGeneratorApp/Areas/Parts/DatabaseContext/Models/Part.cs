using PartsGeneratorApp.Shared.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartsGeneratorApp.Areas.Parts.DatabaseContext.Models
{
    public class Part: BaseEntity
    {
        public string CategoryCode { get; set; }
        public string FactoryCode { get; set; }
        public string Country { get; set; }
    }
}
