using System.ComponentModel.DataAnnotations;

namespace DentistBookingForm.ViewModels
{
    public class DoctorViewModel : ApplicationUserViewModel
    {
        public string UserName { get; set; }

        public List<AbilityViewModel> Abilities { get; set; }

        public List<ProcedureViewModel> Procedures { get; set; }

        public List<AvailableTimeSlotViewModel> AvailableTimeSlots { get; set; }

    }
}
