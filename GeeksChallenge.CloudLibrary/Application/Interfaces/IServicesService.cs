

using System.Collections.Generic;
using System.Threading.Tasks;
using GeeksChallenge.CloudLibrary.Dtos;
using GeeksChallenge.Domain.Common;

namespace GeeksChallenge.CloudLibrary.Application.Interfaces
{
    public partial interface IServicesService
    {
        Task<ClientMessage<int>> AddAsync(ServicesUpsertDto servicesUpsertDto);
        Task<ClientMessage<int>> UpdateAsync(ServicesUpsertDto servicesUpsertDto);
        Task<ClientMessage<int>> DeleteAsync(int id);
        Task<ServicesReadDto> GetByIdAsync(int id);
        Task<List<ServicesReadDto>> GetAllAsync();

    }
}
