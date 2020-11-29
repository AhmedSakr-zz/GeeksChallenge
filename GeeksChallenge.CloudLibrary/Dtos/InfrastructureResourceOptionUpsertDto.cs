using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksChallenge.CloudLibrary.Dtos
{
    public class InfrastructureResourceOptionUpsertDto
    {
       
        public int? Id { get; set; }
     
        public string Value { get; set; }
    
        public int ServiceOptionId { get; set; }

        public string ServiceOptionName { get; set; }
    }
}
