using MediatR;
using PartsGeneratorApp.Areas.Parts.DatabaseContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartsGeneratorApp.Areas.Parts.Queries
{
    public class GetPartsQuery : IRequest<IEnumerable<string>>
    {
    }
}
