using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GeeksChallenge.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GeeksChallenge.CloudLibrary
{
    public interface IApplicationDbContext
    {
        DbSet<CloudProvider> CloudProviders { get; set; }
        DbSet<Infrastructure> Infrastructures { get; set; }
        DbSet<InfrastructureResourceOption> InfrastructureResourceOptions { get; set; }
        DbSet<OptionDefaultValue> OptionDefaultValues { get; set; }
        DbSet<Service> Services { get; set; }
        DbSet<ServiceOption> ServiceOptions { get; set; }
        int SaveChanges();
    }
}
