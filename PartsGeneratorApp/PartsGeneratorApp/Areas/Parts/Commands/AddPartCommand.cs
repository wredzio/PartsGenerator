using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartsGeneratorApp.Areas.Parts.Commands
{
    public class AddPartCommand : IRequest<long>
    {
        public string CategoryCode { get; set; }
        public string FactoryCode { get; set; }
        public string Country { get; set; }
    }
}
