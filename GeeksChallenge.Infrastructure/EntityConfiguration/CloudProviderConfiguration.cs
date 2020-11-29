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
    public class CloudProviderConfiguration:IEntityTypeConfiguration<CloudProvider>
    {
        public void Configure(EntityTypeBuilder<CloudProvider> builder)
        {
            var list=new List<CloudProvider>
            {
                new CloudProvider{Id = 1,Name = "IGS",CreatedById = -1,CreatedDate = DateTime.Now}
            };

            builder.HasData(list);
        }
    }
}
