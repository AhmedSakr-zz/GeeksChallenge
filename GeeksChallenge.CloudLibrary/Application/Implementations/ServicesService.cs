using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.Results;
using GeeksChallenge.Application.Validations;
using GeeksChallenge.CloudLibrary.Application.Interfaces;
using GeeksChallenge.CloudLibrary.Dtos;
using GeeksChallenge.Domain.Common;
using GeeksChallenge.Domain.Enums;
using GeeksChallenge.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GeeksChallenge.CloudLibrary.Application.Implementations
{
    public partial class ServicesService : IServicesService
    {

        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ServicesService(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<ClientMessage<int>> AddAsync(ServicesUpsertDto servicesUpsertDto)
        {
            #region local variables
            var clientMessage = new ClientMessage<int>();
            var dtoValidator = new ServicesUpsertDtoValidator();
            #endregion local variables

            #region validate payload
            var validationResult = dtoValidator.Validate(servicesUpsertDto);

            if (validationResult != null && validationResult.IsValid == false)
            {
                clientMessage.ClientStatusCode = AppEnums.OperationStatus.ValidationError;
                clientMessage.ValidationResults = validationResult.Errors.Select(modelError => new System.ComponentModel.DataAnnotations.ValidationResult(errorMessage: modelError.ErrorMessage)).ToList();
                return clientMessage;
            }

            #endregion validate payload

            #region already exists
            if (await _context.Services.AnyAsync(o => o.Name.ToUpper() == servicesUpsertDto.Name.ToUpper()))
            {
                clientMessage.ClientStatusCode = AppEnums.OperationStatus.Error;
                clientMessage.ClientMessageContent = new List<string>()
                {
                    "Error: Service already exists"
                };
                return clientMessage;
            }
            #endregion already exists

            #region Add service
            var services = _mapper.Map<Service>(servicesUpsertDto);

            await _context.Services.AddAsync(services);

            var effectedRows = _context.SaveChanges();
            if (effectedRows == 0)
            {
                clientMessage.ClientStatusCode = AppEnums.OperationStatus.Error;
                clientMessage.ClientMessageContent = new List<string>()
                {
                    "Error: Database error occured"
                };
                return clientMessage;
            }

            clientMessage.ClientStatusCode = AppEnums.OperationStatus.Ok;
            clientMessage.ReturnedData = services.Id;
            return clientMessage;
            #endregion Add service
        }


        public async Task<ClientMessage<int>> UpdateAsync(ServicesUpsertDto servicesUpsertDto)
        {
            #region local variable
            var clientMessage = new ClientMessage<int>();
            var dtoValidator = new ServicesUpsertDtoValidator();
            var existService = await _context.Services.Include(t => t.ServiceOptions)
                .ThenInclude(t => t.OptionDefaultValues)
                .Where(t => t.Id == servicesUpsertDto.Id && t.DeletedDate == null)
                .FirstOrDefaultAsync();
            #endregion local variable

            #region Servie is not existing
            if (existService == null)
            {
                clientMessage.ClientStatusCode = AppEnums.OperationStatus.Error;
                clientMessage.ClientMessageContent = new List<string>()
                {
                    "Error: Service is not existing"
                };

                return clientMessage;
            }
            #endregion Servie is not existing

            #region Validate payload

            var validationResult = dtoValidator.Validate(servicesUpsertDto);

            if (validationResult != null && validationResult.IsValid == false)
            {
                clientMessage.ClientStatusCode = AppEnums.OperationStatus.ValidationError;
                clientMessage.ValidationResults = validationResult.Errors.Select(modelError => new System.ComponentModel.DataAnnotations.ValidationResult(errorMessage: modelError.ErrorMessage)).ToList();
                return clientMessage;
            }

            #endregion

            #region Service name already exists
            if (await _context.Services.AnyAsync(o => o.Name.ToUpper() == servicesUpsertDto.Name.ToUpper() && o.Id != servicesUpsertDto.Id))
            {
                clientMessage.ClientStatusCode = AppEnums.OperationStatus.Error;
                clientMessage.ClientMessageContent = new List<string>()
                {
                    "Error: Service name already exists"
                };

                return clientMessage;
            }
            #endregion Service name already exists

            #region map dto

            //mark old option as deleted
            foreach (var option in existService.ServiceOptions)
            {
                // mark as delete
                option.DeletedDate = DateTime.Now;
                foreach (var defaultValue in option.OptionDefaultValues)
                {
                    // mark as delete
                    defaultValue.DeletedDate = DateTime.Now;
                }
            }

            //add new option to service
            var newMappedOptions = _mapper.Map<List<ServiceOption>>(servicesUpsertDto.ServiceOptions.Where(t => t.Id == 0));
            foreach (var option in newMappedOptions)
            {
                existService.ServiceOptions.Add(option);
            }

            //update existing options
            var oldMappedOptions = _mapper.Map<List<ServiceOption>>(servicesUpsertDto.ServiceOptions.Where(t => t.Id != 0));
            foreach (var option in oldMappedOptions)
            {
                var oldOption = existService.ServiceOptions.First(t => t.Id == option.Id);
                _mapper.Map(option, oldOption);

                #region map option default value items
                //add new option default value to option
                var newMappedOptionsDefault = _mapper.Map<List<OptionDefaultValue>>(option.OptionDefaultValues.Where(t => t.Id == 0));
                foreach (var optionDefaultValue in newMappedOptionsDefault)
                {
                    option.OptionDefaultValues.Add(optionDefaultValue);
                }

                //update existing option default values
                var oldMappedOptionDefaultValues = _mapper.Map<List<OptionDefaultValue>>(option.OptionDefaultValues.Where(t => t.Id != 0));
                foreach (var optionDefaultValue in oldMappedOptionDefaultValues)
                {
                    var oldOptionDefaultValue = option.OptionDefaultValues.First(t => t.Id == option.Id);
                    _mapper.Map(optionDefaultValue, oldOptionDefaultValue);
                }

                #endregion map option default value items

            }

            #endregion map dto

            #region save changes
            var effectedRows = _context.SaveChanges();
            if (effectedRows == 0)
            {
                clientMessage.ClientStatusCode = AppEnums.OperationStatus.Error;
                clientMessage.ClientMessageContent = new List<string>()
                {
                    "Error: Database error occured."
                };
            }

            clientMessage.ClientStatusCode = AppEnums.OperationStatus.Ok;
            clientMessage.ReturnedData = effectedRows;
            return clientMessage;
            #endregion save changes
        }


        public async Task<ClientMessage<int>> DeleteAsync(int id)
        {
            var clientMessage = new ClientMessage<int>();

            var entity = await _context.Services
                 .Where(o => o.Id == id)
                 .SingleOrDefaultAsync();

            _context.Services.Remove(entity);

            var effectedRows = _context.SaveChanges();
            if (effectedRows != 0)
            {
                clientMessage.ClientStatusCode = AppEnums.OperationStatus.Ok;
                clientMessage.ReturnedData = effectedRows;
                return clientMessage;
            }

            clientMessage.ClientStatusCode = AppEnums.OperationStatus.Error;
            clientMessage.ClientMessageContent = new List<string>()
            {
                "Error: Database error occured."
            };
            return clientMessage;
        }

        public async Task<ServicesReadDto> GetByIdAsync(int id)
        {
            var result = await _context.Services.Include(t => t.ServiceOptions).ThenInclude(t => t.OptionDefaultValues)
                .FirstOrDefaultAsync(o => o.Id == id);

            return _mapper.Map<ServicesReadDto>(result);
        }


        public async Task<List<ServicesReadDto>> GetAllAsync()
        {
            var result = await _context.Services.Include(t => t.ServiceOptions).ThenInclude(t => t.OptionDefaultValues)
                .ToListAsync();
            return _mapper.Map<List<ServicesReadDto>>(result);
        }


    }
}
