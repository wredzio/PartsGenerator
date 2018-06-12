using Microsoft.EntityFrameworkCore;
using PartsGeneratorApp.Areas.Parts.DatabaseContext.Models;
using PartsGeneratorApp.Shared.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartsGeneratorApp.Areas.Parts.DatabaseContext
{
    public class ApplicationContext : BaseDbContext<ApplicationContext>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }

        public DbSet<Part> Parts { get; set; }
    }

}
