using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace DentistBookingForm.Models
{
    public class AvailableTimeSlot
    {
        public int Id { get; set; }

        public Doctor Doctor { get; set; }

        public string DoctorId { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public TimeSpan Hour { get; set; }

    }
}
