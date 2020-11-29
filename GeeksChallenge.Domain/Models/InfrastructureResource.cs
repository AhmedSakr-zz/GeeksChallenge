using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GeeksChallenge.Domain.Models
{
    public class InfrastructureResource : AuditEntityBase
    {
        public InfrastructureResource()
        {
            InfrastructureResourceOptions = new List<InfrastructureResourceOption>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public int InfrastructureId { get; set; }
        [ForeignKey(nameof(InfrastructureId))]
        public Infrastructure Infrastructure { get; set; }

        public int ServiceId { get; set; }
        [ForeignKey(nameof(ServiceId))]
        public Service Service { get; set; }

        public IList<InfrastructureResourceOption> InfrastructureResourceOptions { get; set; }
    }
}
