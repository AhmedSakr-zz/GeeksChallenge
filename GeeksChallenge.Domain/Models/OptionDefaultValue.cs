using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksChallenge.Domain.Models
{
    public class OptionDefaultValue : AuditEntityBase
    {
        public int Id { get; set; }
        public string OptionValue { get; set; }

        public int ServiceOptionId { get; set; }

        [ForeignKey(nameof(ServiceOptionId))]
        public ServiceOption ServiceOption { get; set; }
    }
}
