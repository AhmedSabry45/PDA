using Microsoft.EntityFrameworkCore;
using PDA.Models;
using System.Reflection;

namespace PDA;

public class ApplicationContext : DbContext
{


    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }


    //public DbSet<ContainerDamageReport> ContainerDamageReports { get; set; }
    public DbSet<Damage> Damages { get; set; }
    public DbSet<VesselVoyage> VesselVoyages { get; set; }
    public DbSet<VesselLashing> VesselLashings { get; set; }
    public DbSet<ContainerInformation> ContainerInformations { get; set; }
    public DbSet<DamageContainer> DamagedContainers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

}
