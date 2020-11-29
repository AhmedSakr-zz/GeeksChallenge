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
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            var list = new List<Service>
            {
                new Service {Id = 1, Name = "Virtual Machines", CreatedDate = DateTime.Now, CreatedById = -1},
                new Service {Id = 2, Name = "Database Servers", CreatedDate = DateTime.Now, CreatedById = -1}
            };

            builder.HasData(list);
        }
    }
}
