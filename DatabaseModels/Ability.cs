namespace DentistBookingForm.Models
{
    public class Ability
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Doctor Doctor { get; set; }

        public string DoctorId { get; set; }
    }
}
