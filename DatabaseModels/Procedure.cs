using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace DentistBookingForm.Models
{
    public class Procedure
    {
        public int Id { get; set; }

        public Doctor Doctor { get; set; }

        public string DoctorId { get; set; }

        public string Name { get; set; }
    }
}
