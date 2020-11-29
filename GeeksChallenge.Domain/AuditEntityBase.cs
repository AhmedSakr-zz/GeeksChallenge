using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksChallenge.Domain
{
    public class AuditEntityBase
    {
        public int CreatedById { get; set; }
        public int? UpdatedById { get; set; }
        public int? DeletedById { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
