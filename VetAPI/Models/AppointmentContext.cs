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

        public async Task<IEnumerable<Appointment>> Search(string? name, string? date)
        {
            IQueryable<Appointment> query = Appointments;
                
            if (name !=null && !string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.PetName.Contains(name));
            }

            if(date != null)
            {
                query = query.Where(e => e.AppointmentTime == date);
            }

            return await query.ToListAsync();
        }
    }
}