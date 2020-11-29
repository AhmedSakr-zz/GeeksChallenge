using System.Threading.Tasks;
using GeeksChallenge.CloudLibrary.Dtos;
using GeeksChallenge.Domain.Common;

namespace GeeksChallenge.CloudLibrary.Application.Interfaces
{
    public interface IInfrastructureService
    {
        Task<ClientMessage<int>> CreateAsync(InfrastructureUpsertDto postDto);

        Task<ClientMessage<bool>> DeleteAsync(string infrastructureName);
    }
}
