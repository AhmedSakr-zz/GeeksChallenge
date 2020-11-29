using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Schema;

namespace GeeksChallenge.Domain.Models
{
    public class Infrastructure : AuditEntityBase
    {
        public Infrastructure()
        {
            InfrastructureResources = new List<InfrastructureResource>();
        }

        public int Id { get; set; }
        [MaxLength(400)]
        public string Name { get; set; }
        public IList<InfrastructureResource> InfrastructureResources { get; set; }

        public int CloudProviderId { get; set; }
        [ForeignKey(nameof(CloudProviderId))]
        public CloudProvider CloudProvider { get; set; }
    }
}
