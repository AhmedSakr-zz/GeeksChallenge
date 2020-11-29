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
    public class ServicesApiController : ControllerBase
    {
        private readonly IServicesService _servicesService;

        public ServicesApiController(IServicesService servicesService)
        {
            _servicesService = servicesService;
        }

        [Route("AddService")]
        [HttpPost]
        public async Task<IActionResult> AddService(ServicesUpsertDto dto)
        {
            var result = await _servicesService.AddAsync(dto);

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

        [Route("UpdateService")]
        [HttpPut]
        public async Task<IActionResult> UpdateService(ServicesUpsertDto dto)
        {
            var result = await _servicesService.UpdateAsync(dto);

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

        [Route("DeleteService")]
        [HttpDelete]
        public async Task<IActionResult> DeleteService(int id)
        {
            var result = await _servicesService.DeleteAsync(id);

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

        [Route("GetService")]
        [HttpGet]
        public async Task<IActionResult> GetService(int id)
        {
            var result = await _servicesService.GetByIdAsync(id);
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        [Route("GetAllService")]
        [HttpGet]
        public async Task<IActionResult> GetAllService()
        {
            var result = await _servicesService.GetAllAsync();
            if (result != null)
                return Ok(result);

            return NotFound();
        }
    }
}
