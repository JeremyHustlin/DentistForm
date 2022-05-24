using Microsoft.AspNetCore.Mvc;
using DentistBookingForm.Data;
using DentistBookingForm.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DentistBookingForm.ViewModels;

namespace DentistBookingForm.Controllers
{
    
    public class ProcedureController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ProcedureController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<ActionResult> Index()
        {
            var AbilityViewModels = await _applicationDbContext.Procedures
                .Select(procedure => new ProcedureViewModel
                {
                    Id = procedure.Id,
                    Name = procedure.Name,
                    Doctor = new DoctorViewModel()
                    {
                        UserName=procedure.Doctor.UserName,
                        Id=procedure.DoctorId,
                    }

                }).ToListAsync();

            return View(AbilityViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new ProcedureViewModel();
            ViewBag.AvailableDoctors = _applicationDbContext.Doctors
                .Select(x => new { x.Id, x.UserName })
                .ToList();

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProcedureViewModel model) 
        {
            Procedure procedure = new Procedure
            {
                Id = model.Id,
                Name = model.Name,
                DoctorId = model.Doctor.Id,
            };

            _applicationDbContext.Procedures.Add(procedure);
            await _applicationDbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
            
        }
    }
    
}
