namespace VetAPI.Models
{
    public class DataPool
    {
        public long Id { get; set; }
        public string? OwnerName { get; set; }
        public string? PetName { get; set; }
        public string? ContactDetails { get; set; }
        public DateTime AppointmentTime {get;set;}

        public string GetRandomOwnerName(){
            Random rand = new Random();
            int num = rand.Next(7);
            switch (num) 
            {
            case 1:
                return "Endang";
            case 2:
                return "Roy";
            case 3:
                return "Loekinto";
            case 4:
                return "Budi Buhadi";
            case 5:
                return "Robert";
            case 6:
                return "Michael";
            default:
                return "Joey";
            }
        }
        public string GetRandomPetName(){
            Random rand = new Random();
            int num = rand.Next(7);
            switch (num) 
            {
            case 1:
                return "John Krueger";
            case 2:
                return "Cassimila";
            case 3:
                return "Mary Sue";
            case 4:
                return "Crash B.";
            case 5:
                return "Darius Nathaniel";
            case 6:
                return "Raimain Samuel";
            default:
                return "Joelandor";
            }
        }
    }
}