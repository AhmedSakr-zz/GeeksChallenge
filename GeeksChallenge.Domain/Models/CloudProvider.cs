using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksChallenge.Domain.Models
{
    public class CloudProvider : AuditEntityBase
    {
        public CloudProvider()
        {
            Infrastructures = new List<Infrastructure>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Infrastructure> Infrastructures { get; set; }
    }
}
