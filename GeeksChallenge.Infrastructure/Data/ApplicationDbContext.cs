using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeeksChallenge.CloudLibrary;
using GeeksChallenge.Domain.Models;
using GeeksChallenge.Infrastructure.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace GeeksChallenge.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<CloudProvider> CloudProviders { get; set; }
        public DbSet<Domain.Models.Infrastructure> Infrastructures { get; set; }
        public DbSet<InfrastructureResourceOption> InfrastructureResourceOptions { get; set; }
        public DbSet<OptionDefaultValue> OptionDefaultValues { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceOption> ServiceOptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<InfrastructureResourceOption>()
                .HasOne(t => t.ServiceOption)
                .WithMany(t => t.InfrastructureResourceOptions)
                .HasForeignKey(t => t.ServiceOptionId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.ApplyConfiguration(new CloudProviderConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceOptionConfiguration());
            modelBuilder.ApplyConfiguration(new OptionDefaultValueConfiguration());
        }
    }
}
