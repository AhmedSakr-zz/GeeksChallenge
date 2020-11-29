using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksChallenge.Domain.Models
{
    public class Service : AuditEntityBase
    {
        public Service()
        {
            ServiceOptions = new List<ServiceOption>();
            InfrastructureResources = new List<InfrastructureResource>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<ServiceOption> ServiceOptions { get; set; }
        public IList<InfrastructureResource> InfrastructureResources { get; set; }
    }
}
