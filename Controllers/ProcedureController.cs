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
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _applicationDbContext
                .Procedures
                .Include(x => x.Doctor)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (model == null)
            {
                return NotFound();
            }

            var viewModel = new ProcedureViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Doctor = new DoctorViewModel()
                {
                    Id = model.Doctor.Id,
                    UserName = model.Doctor.UserName,
                }

            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProcedureViewModel model)
        {
            var procedure = await _applicationDbContext
                .Procedures
                .SingleOrDefaultAsync(x => x.Id == model.Id);
                if(procedure==null)
                {
                NotFound();
                }
            procedure.Name = model.Name;
            procedure.DoctorId=model.Doctor.Id;

            await _applicationDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            return View(procedure);
           
        }


        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {


            var model = await _applicationDbContext
                .Procedures
                .Include(x => x.Doctor)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (model == null)
            {
                NotFound();
            }

            var viewModel = new ProcedureViewModel()
            {

                Id = model.Id,

            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(ProcedureViewModel model)
        {
            var procedure = await _applicationDbContext
                .Procedures
                .SingleOrDefaultAsync(x => x.Id == model.Id);

            if (procedure == null)
            {
                NotFound();
            }


            procedure.Id = model.Id;


            _applicationDbContext.Procedures.Remove(procedure);
            await _applicationDbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }





    }

}
