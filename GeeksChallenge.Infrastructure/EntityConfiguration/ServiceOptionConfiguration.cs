using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeeksChallenge.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeeksChallenge.Infrastructure.EntityConfiguration
{
    public class ServiceOptionConfiguration:IEntityTypeConfiguration<ServiceOption>
    {
        public void Configure(EntityTypeBuilder<ServiceOption> builder)
        {
            var list = new List<ServiceOption>
            {
                new ServiceOption {Id = 1, ServiceId = 1, Name = "Operating System", CreatedById = -1, CreatedDate = DateTime.Now},

                new ServiceOption {Id = 2, ServiceId = 2, Name = "Database Engine", CreatedById = -1, CreatedDate = DateTime.Now}
            };

            builder.HasData(list);
        }
    }
}
