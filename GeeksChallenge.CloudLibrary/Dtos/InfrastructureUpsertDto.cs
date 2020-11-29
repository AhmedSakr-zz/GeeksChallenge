using System.Collections.Generic;

namespace GeeksChallenge.CloudLibrary.Dtos
{
    public class InfrastructureUpsertDto
    {
        public InfrastructureUpsertDto()
        {
            InfrastructureResources = new List<InfrastructureResourceUpsertDto>();
        }
        public int? Id { get; set; }
   
        public string Name { get; set; }
 
        public int CloudProviderId { get; set; }
         
        public string CloudProviderName { get; set; }

        public IList<InfrastructureResourceUpsertDto> InfrastructureResources { get; set; }
    }
}
