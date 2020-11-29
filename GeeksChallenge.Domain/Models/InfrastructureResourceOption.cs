using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksChallenge.Domain.Models
{
    public class InfrastructureResourceOption : AuditEntityBase
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public int InfrastructureResourceId { get; set; }
        [ForeignKey(nameof(InfrastructureResourceId))]
        public InfrastructureResource InfrastructureResource { get; set; }

        public int ServiceOptionId { get; set; }
        public ServiceOption ServiceOption { get; set; }
    }
}
