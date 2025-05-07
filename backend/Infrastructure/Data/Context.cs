using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public partial class Context : DbContext
{
    public Context() { }

    public Context(DbContextOptions<Context> options) : base(options) { }

    public virtual DbSet<Patient> Patients { get; set; }
    public virtual DbSet<Appointment> Appointments { get; set; }
    public virtual DbSet<Doctor> Doctors { get; set; }
    public virtual DbSet<Staff> Staff { get; set; }
    public virtual DbSet<Speciality> Specialities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

    }
}
