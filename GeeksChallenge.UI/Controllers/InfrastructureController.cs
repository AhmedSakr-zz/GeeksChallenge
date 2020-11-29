using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeeksChallenge.CloudLibrary.Application.Interfaces;
using GeeksChallenge.CloudLibrary.Dtos;
using GeeksChallenge.Domain.Enums;

namespace GeeksChallenge.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfrastructureController : ControllerBase
    {
        private readonly IInfrastructureService _infrastructureService;

        public InfrastructureController(IInfrastructureService infrastructureService)
        {
            _infrastructureService = infrastructureService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(InfrastructureUpsertDto dto)
        {
            var result = await _infrastructureService.CreateAsync(dto);
            switch (result.ClientStatusCode)
            {
                case AppEnums.OperationStatus.Ok:
                    return Ok(result.ReturnedData);
                case AppEnums.OperationStatus.ValidationError:
                    return BadRequest(result.ValidationResults);
                default:
                    return BadRequest(result.ClientMessageContent);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(string infrastructureName)
        {
            var result = await _infrastructureService.DeleteAsync(infrastructureName);
            switch (result.ClientStatusCode)
            {
                case AppEnums.OperationStatus.Ok:
                    return Ok(result.ReturnedData);
                case AppEnums.OperationStatus.ValidationError:
                    return BadRequest(result.ValidationResults);
                default:
                    return BadRequest(result.ClientMessageContent);
            }
        }
    }
}
