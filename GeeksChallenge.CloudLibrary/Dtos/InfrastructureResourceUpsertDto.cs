using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeeksChallenge.Domain.Models;

namespace GeeksChallenge.CloudLibrary.Dtos
{
    public class InfrastructureResourceUpsertDto
    {
        public InfrastructureResourceUpsertDto()
        {
            InfrastructureResourceOption = new List<InfrastructureResourceOptionUpsertDto>();
        }
        public int? Id { get; set; }
        
        public string Name { get; set; }

        public int? InfrastructureId { get; set; }
    
        public string InfrastructureName { get; set; }

       
        public int ServiceId { get; set; }
      
        public string ServiceName { get; set; }


        public IList<InfrastructureResourceOptionUpsertDto> InfrastructureResourceOption { get; set; }
    }
}
