using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartsGeneratorApp.Areas.Parts.Commands;
using PartsGeneratorApp.Areas.Parts.Queries;

namespace PartsGeneratorApp.Areas.Parts
{
    [Route("api/[controller]")]
    public class PartsController : Controller
    {
        private readonly IMediator _mediator;
        public PartsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddPart([FromBody] AddPartCommand addPartCommand)
        {
            if(ModelState.IsValid)
            {
                var result = await _mediator.Send(addPartCommand);

                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetParts([FromQuery] GetPartsQuery getPartsQuery)
        {
            var result = await _mediator.Send(getPartsQuery);

            return Ok(result);
        }
    }
}