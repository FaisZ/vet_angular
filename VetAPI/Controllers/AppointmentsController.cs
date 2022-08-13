using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetAPI.Models;
using System.Web.Http.Cors;

namespace VetAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors(origins: "http://localhost:7139", headers: "*", methods: "*")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly AppointmentContext _context;

        public AppointmentsController(AppointmentContext context)
        {
            _context = context;
        }

        public void GenerateAppointmentData(int numberOfData){
            
        }

        // GET: api/Appointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments([FromQuery] PaginationFilter filter, string? name, string? date)
        {
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin","http://localhost:4200");
            // Console.WriteLine(filter.PageNumber);
            // Console.WriteLine(filter.PageSize);
            // var filters = new PaginationFilter(filter.PageNumber, filter.PageSize);
            if (_context.Appointments == null)
            {
                return NotFound();
            }
            var res = _context.Appointments;
            IQueryable<Appointment> sortedResult = _context.Appointments;
            sortedResult = sortedResult.OrderBy(e => e.AppointmentTime);

            var query = sortedResult
            .Skip((filter.PageNumber - 1) * filter.PageSize).Take(filter.PageSize);

            if(name!=null)
                query = query.Where(e =>  e.PetName.Contains(name));
            if(date!=null)
                query = query.Where(e =>  e.AppointmentTime.Contains(date));
            Console.WriteLine(query);
            return await query.ToListAsync();
        }

        [HttpGet("generate")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GenerateAppointmentData()
        {
        
        Random rand = new Random();

        Appointment appointment;
        DataPool randomDataSource = new DataPool();
        DateTime date;
        for(int i=0;i<100; i++){
            date = DateTime.Now;
            date = date.AddDays(rand.Next(20));
            date = date.AddHours(rand.Next(20));
            date = date.AddMinutes(rand.Next(40));
            appointment = new Appointment();
            appointment.OwnerName = randomDataSource.GetRandomOwnerName();
            appointment.PetName = randomDataSource.GetRandomPetName();
            appointment.ContactDetails = "086612344321";
            appointment.AppointmentTime = date.ToString();
            _context.Appointments.Add(appointment);
        }
            await _context.SaveChangesAsync();

            return await _context.Appointments.ToListAsync();
        }

        // GET: api/Appointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(long id)
        {
          if (_context.Appointments == null)
          {
              return NotFound();
          }
            var appointment = await _context.Appointments.FindAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return appointment;
        }

        // PUT: api/Appointments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointment(long id, Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return BadRequest();
            }

            _context.Entry(appointment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Appointments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
        {

          if (_context.Appointments == null)
          {
              return Problem("Entity set 'AppointmentContext.Appointments'  is null.");
          }
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAppointment), new { id = appointment.Id }, appointment);
        }

        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(long id)
        {
            if (_context.Appointments == null)
            {
                return NotFound();
            }
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppointmentExists(long id)
        {
            return (_context.Appointments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
