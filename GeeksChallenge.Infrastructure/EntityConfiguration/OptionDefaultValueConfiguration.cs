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
    public class OptionDefaultValueConfiguration:IEntityTypeConfiguration<OptionDefaultValue>
    {
        public void Configure(EntityTypeBuilder<OptionDefaultValue> builder)
        {
            var list=new List<OptionDefaultValue>
            {
                new OptionDefaultValue{Id = 1,ServiceOptionId = 1,OptionValue = "Windows",CreatedById = -1,CreatedDate = DateTime.Now},
                new OptionDefaultValue{Id = 2,ServiceOptionId = 1,OptionValue = "Linux",CreatedById = -1,CreatedDate = DateTime.Now},

                new OptionDefaultValue{Id = 3,ServiceOptionId = 2,OptionValue = "MySQL ",CreatedById = -1,CreatedDate = DateTime.Now},
                new OptionDefaultValue{Id = 4,ServiceOptionId = 2,OptionValue = " SQL Server ",CreatedById = -1,CreatedDate = DateTime.Now}
            };

            builder.HasData(list);
        }
    }
}
