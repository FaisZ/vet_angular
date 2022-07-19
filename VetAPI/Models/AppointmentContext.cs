using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace VetAPI.Models
{
    public class AppointmentContext : DbContext
    {
        public AppointmentContext(DbContextOptions<AppointmentContext> options)
            : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; } = null!;
    }
}