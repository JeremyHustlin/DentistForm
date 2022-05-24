namespace DentistBookingForm.ViewModels
{
    public class AvailableTimeSlotViewModel
    {
        public int Id { get; set; }

        public DayOfWeek DayOfWeek { get; set; }
        
        public TimeSpan Hour { get; set; }
        public DoctorViewModel Doctor { get; set; }
    }
}
