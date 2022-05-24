namespace DentistBookingForm.ViewModels
{
    public class ProcedureViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DoctorViewModel Doctor { get; set; }
    }
}
