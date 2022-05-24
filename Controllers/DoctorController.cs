using Microsoft.AspNetCore.Mvc;
using DentistBookingForm.Data;
using DentistBookingForm.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DentistBookingForm.ViewModels;

namespace DentistBookingForm.Controllers
{ 
    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        
        public DoctorController (ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext=applicationDbContext;
            
        }
        public async Task<ActionResult> Index()
        {
            var DoctorControllerModels = await _applicationDbContext.Doctors
                .Select(doctor=> new DoctorViewModel
                {
                   Id= doctor.Id,
                    Abilities= doctor.Abilities.Select(ability => new AbilityViewModel()
                    {
                        Id = ability.Id,
                        Name=ability.Name,
                    }).ToList(),
                    UserName = doctor.UserName,
                    Procedures = doctor.Procedures.Select(procedure => new ProcedureViewModel ()
                    {
                        Id= procedure.Id,
                        Name = procedure.Name
                    }).ToList(),
                    AvailableTimeSlots=doctor.AvailableTimeSlots.Select(time=> new AvailableTimeSlotViewModel()
                    {
                        Id = time.Id,
                        DayOfWeek = time.DayOfWeek,
                        Hour = time.Hour,
                    }).ToList(),
                })
                .ToListAsync();
            return View(DoctorControllerModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new DoctorViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DoctorViewModel model)
        {
            Doctor doctor = new Doctor
            {
                
                UserName = model.UserName,
               
            };

            _applicationDbContext.Doctors.Add(doctor);
            await _applicationDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            
        }
    }
}
