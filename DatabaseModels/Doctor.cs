using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace DentistBookingForm.Models
{
    public class Doctor : ApplicationUser
    {
      
        public List<Ability> Abilities { get; set; }
       

        public List<Procedure> Procedures { get; set; }

        public List<AvailableTimeSlot> AvailableTimeSlots { get; set; }
    }
}
