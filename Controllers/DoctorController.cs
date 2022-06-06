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

        public DoctorController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;

        }
        public async Task<ActionResult> Index()
        {
            var DoctorControllerModels = await _applicationDbContext.Doctors
                .Select(doctor => new DoctorViewModel
                {
                    Id = doctor.Id,
                    Abilities = doctor.Abilities.Select(ability => new AbilityViewModel()
                    {
                        Id = ability.Id,
                        Name = ability.Name,
                    }).ToList(),
                    UserName = doctor.UserName,
                    Procedures = doctor.Procedures.Select(procedure => new ProcedureViewModel()
                    {
                        Id = procedure.Id,
                        Name = procedure.Name
                    }).ToList(),
                    AvailableTimeSlots = doctor.AvailableTimeSlots.Select(time => new AvailableTimeSlotViewModel()
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
        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            var model = await _applicationDbContext
                .Doctors
                .Include(x => x.Abilities)
                .Include(x => x.Procedures)
                .Include(x => x.AvailableTimeSlots)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (model == null)
            {
                NotFound();
            }
            var viewModel = new DoctorViewModel()
            {
                Id = model.Id,
                UserName = model.UserName,
              /*  Abilities = model.Abilities.Select(ability => new AbilityViewModel()
                {
                    Name = ability.Name,
                }).ToList(),
                Procedures = model.Procedures.Select(procedure => new ProcedureViewModel()
                {
                    Name = procedure.Name,
                }).ToList(),
                AvailableTimeSlots = model.AvailableTimeSlots.Select(time => new AvailableTimeSlotViewModel()
                {
                    Hour = time.Hour,
                }).ToList(),*/

            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(DoctorViewModel model)
        {
            var doctor = await _applicationDbContext
                .Doctors
                .Include(x => x.Abilities)
                 .Include(x => x.Procedures)
                .Include(x => x.AvailableTimeSlots)
                .SingleOrDefaultAsync(x => x.Id == model.Id);

            if (doctor == null)
            {
                NotFound();
            }

            doctor.Id = model.Id;
            doctor.UserName = model.UserName;
           /* doctor.Abilities = new List<Ability>();
            doctor.Abilities = model.Abilities.Select(ability => new Ability()
            {
                DoctorId = model.Id,
                Name = ability.Name
            }).ToList();
            doctor.Procedures = new List<Procedure>();
            doctor.Procedures=model.Procedures.Select(procedure=>new Procedure()
            {
                DoctorId=model.Id,
                Name=procedure.Name,
            }).ToList();
            doctor.AvailableTimeSlots = new List<AvailableTimeSlot>();
            doctor.AvailableTimeSlots = model.AvailableTimeSlots.Select(time => new AvailableTimeSlot()
            { 
                DoctorId=model.Id,
                Hour=time.Hour,
                DayOfWeek=time.DayOfWeek,
            }).ToList();*/
           
            _applicationDbContext.Update(doctor);
            await _applicationDbContext.SaveChangesAsync();
           return RedirectToAction(nameof(Index));
           
        }

        [HttpGet]
        public async Task<ActionResult> Delete(string id)
        {


            var model = await _applicationDbContext
                .Doctors
                .Include(x => x.Procedures)
                 .Include(x => x.AvailableTimeSlots)
                  .Include(x => x.Abilities)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (model == null)
            {
                NotFound();
            }

            var viewModel = new DoctorViewModel()
            {

                Id = model.Id,

            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(DoctorViewModel model)
        {
            var doctor = await _applicationDbContext
                .Doctors
                .SingleOrDefaultAsync(x => x.Id == model.Id);

            if (doctor == null)
            {
                NotFound();
            }


            doctor.Id = model.Id;


            _applicationDbContext.Doctors.Remove(doctor);
            await _applicationDbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
    }
}

