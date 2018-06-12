using MediatR;
using PartsGeneratorApp.Areas.Parts.Commands;
using PartsGeneratorApp.Areas.Parts.DatabaseContext;
using PartsGeneratorApp.Areas.Parts.DatabaseContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PartsGeneratorApp.Areas.Parts.CommandHandlers
{
    public class AddPartCommandHandler : IRequestHandler<AddPartCommand, long>
    {
        private ApplicationContext _applicationContext;

        public AddPartCommandHandler(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<long> Handle(AddPartCommand request, CancellationToken cancellationToken)
        {
            var newPart = new Part()
            {
                CategoryCode = request.CategoryCode,
                FactoryCode = request.FactoryCode,
                Country = request.Country
            };

            await _applicationContext.Parts.AddAsync(newPart);
            await _applicationContext.SaveChangesAsync();

            return newPart.Id;
        }
    }
}
