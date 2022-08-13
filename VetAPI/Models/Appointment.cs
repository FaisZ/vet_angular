namespace VetAPI.Models
{
    public class Appointment
    {
        public long Id { get; set; }
        public string? OwnerName { get; set; }
        public string? PetName { get; set; }
        public string? ContactDetails { get; set; }
        public string? AppointmentTime {get;set;}
    }
}