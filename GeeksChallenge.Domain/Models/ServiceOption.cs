using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksChallenge.Domain.Models
{
    public class ServiceOption : AuditEntityBase
    {
        public ServiceOption()
        {
            InfrastructureResourceOptions = new List<InfrastructureResourceOption>();
            OptionDefaultValues = new List<OptionDefaultValue>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int ServiceId { get; set; }
        [ForeignKey(nameof(ServiceId))]
        public Service Service { get; set; }

        public IList<InfrastructureResourceOption> InfrastructureResourceOptions { get; set; }
        public IList<OptionDefaultValue> OptionDefaultValues { get; set; }
    }
}
