using MediatR;
using Microsoft.EntityFrameworkCore;
using PartsGeneratorApp.Areas.Parts.DatabaseContext;
using PartsGeneratorApp.Areas.Parts.DatabaseContext.Models;
using PartsGeneratorApp.Areas.Parts.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PartsGeneratorApp.Areas.Parts.QueryHandlers
{
    public class GetPartsQueryHandler : IRequestHandler<GetPartsQuery, IEnumerable<string>>
    {
        private ApplicationContext _applicationContext;

        public GetPartsQueryHandler(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<IEnumerable<string>> Handle(GetPartsQuery request, CancellationToken cancellationToken)
        {
            return await _applicationContext
                .Parts
                .Select(part => $"{part.CategoryCode}-{part.FactoryCode}-{part.Id}")
                .ToListAsync();
        }
    }
}
