using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GeeksChallenge.CloudLibrary.Application.Interfaces;
using GeeksChallenge.CloudLibrary.Dtos;
using GeeksChallenge.CloudLibrary.Services.CloudProvider;
using GeeksChallenge.CloudLibrary.Validations;
using GeeksChallenge.Domain.Common;
using GeeksChallenge.Domain.Enums;
using GeeksChallenge.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GeeksChallenge.CloudLibrary.Application.Implementations
{


    public class InfrastructureService : IInfrastructureService
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;


        public InfrastructureService(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<ClientMessage<int>> CreateAsync(InfrastructureUpsertDto postDto)
        {
            #region local parameters
            ClientMessage<int> clientMessage = new ClientMessage<int>();
            var dtoValidator = new InfrastructureUpsertValidator();
            #endregion local parameters

            #region validate payload
            var validationResult = dtoValidator.Validate(postDto);
            if (validationResult != null && validationResult.IsValid == false)
            {
                clientMessage.ClientStatusCode = AppEnums.OperationStatus.ValidationError;
                clientMessage.ValidationResults = validationResult.Errors.Select(modelError => new System.ComponentModel.DataAnnotations.ValidationResult(errorMessage: modelError.ErrorMessage)).ToList();
                return clientMessage;
            }
            #endregion validate payload

            #region Infrastructure already exists
            var alreadyExists = await _context.Infrastructures.Where(t => t.Name == postDto.Name && t.DeletedDate == null)
                .FirstOrDefaultAsync();
            if (alreadyExists != null)
            {
                clientMessage.ClientStatusCode = AppEnums.OperationStatus.ValidationError;
                clientMessage.ClientMessageContent = new List<string> { "Error : Infrastructure already exists" };
                return clientMessage;
            }
            #endregion Infrastructure already exists

            #region create infrastructure on cloud service provider
            var serviceManager = new ServiceManager.ServiceManager();
            var igsProvider = new IGSCloudServices();

            //all service providers must subscribe the create event
            //another solution is to use reflection to call create method in all service provider assembly
            serviceManager.CreateInfrastructure += igsProvider.OnCreateService;
            var created = serviceManager.Create(postDto);

            if (!created)
            {
                clientMessage.ClientStatusCode = AppEnums.OperationStatus.Error;
                clientMessage.ClientMessageContent = new List<string> { "Error : an error occured while creating infrastructure on provider, or you used unsupported provider" };
                return clientMessage;
            }
            #endregion region create infrastructure on cloud service provider

            #region Add to database
            var infrastructure = _mapper.Map<Infrastructure>(postDto);
            await _context.Infrastructures.AddAsync(infrastructure);
            try
            {
                var effectedRows = _context.SaveChanges();
                if (effectedRows == 0)
                {
                    clientMessage.ClientStatusCode = AppEnums.OperationStatus.Error;
                    clientMessage.ClientMessageContent = new List<string> { "Error : an error occured while saving infrastructure details to database" };
                    return clientMessage;
                }
            }
            catch (Exception ex)
            {
                var t = ex.Message;
            }


            clientMessage.ClientStatusCode = AppEnums.OperationStatus.Ok;
            clientMessage.ReturnedData = infrastructure.Id;

            return clientMessage;
            #endregion Add to database


        }

        public async Task<ClientMessage<bool>> DeleteAsync(string infrastructureName)
        {

            #region local parameters
            ClientMessage<bool> clientMessage = new ClientMessage<bool>();

            var infrastructure = await _context.Infrastructures.Include(t => t.CloudProvider)
                .Where(t => t.Name == infrastructureName && t.DeletedDate == null)
                .FirstOrDefaultAsync();
            #endregion local parameters

            #region validate infrastructure name
            if (infrastructure == null)
            {
                clientMessage.ClientStatusCode = AppEnums.OperationStatus.Error;
                clientMessage.ReturnedData = false;
                clientMessage.ClientMessageContent = new List<string> { "Error: infrastructure is not exist" };
                return clientMessage;
            }
            #endregion validate infrastructure name

            #region delete infrastructure on cloud service provider
            var serviceManager = new ServiceManager.ServiceManager();
            var igsProvider = new IGSCloudServices();
            serviceManager.DeleteInfrastructure += igsProvider.OnDeleteService;
            var deleted = serviceManager.Delete(infrastructure);

            if (!deleted)
            {
                clientMessage.ClientStatusCode = AppEnums.OperationStatus.Error;
                clientMessage.ClientMessageContent = new List<string> { "Error : an error occured while deleting infrastructure on provider" };
                return clientMessage;
            }
            #endregion region delete infrastructure on cloud service provider

            #region Mark infrastructure as deleted in database
            infrastructure.DeletedDate = DateTime.Now;
            infrastructure.DeletedById = -1; // -1 = system
            _context.SaveChanges();

            clientMessage.ClientStatusCode = AppEnums.OperationStatus.Ok;
            clientMessage.ReturnedData = true;
            return clientMessage;
            #endregion Mark infrastructure as deleted in database

        }

    }
}
