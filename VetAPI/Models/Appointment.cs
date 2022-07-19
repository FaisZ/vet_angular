namespace VetAPI.Models
{
    public class Appointment
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
        public DateTime AppointmentTime {get;set;}
    }
}