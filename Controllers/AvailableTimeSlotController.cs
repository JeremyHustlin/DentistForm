using Microsoft.AspNetCore.Mvc;
using DentistBookingForm.Data;
using Microsoft.EntityFrameworkCore;
using DentistBookingForm.ViewModels;
using DentistBookingForm.Models;

namespace DentistBookingForm.Controllers
{
    public class AvailableTimeSlotController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public AvailableTimeSlotController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ActionResult> Index()
        {

            var AvailableTimeSlotModels = await _applicationDbContext.AvailableTimeSlots
                .Select(time => new AvailableTimeSlotViewModel
                {
                    Id = time.Id,
                    DayOfWeek = time.DayOfWeek,
                    Hour = time.Hour,
                    Doctor=new DoctorViewModel()
                    {
                        UserName=time.Doctor.UserName,
                        Id=time.DoctorId
                    }
                })

                 .ToListAsync();
            return View(AvailableTimeSlotModels);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new AvailableTimeSlotViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AvailableTimeSlotViewModel model)
        {
            AvailableTimeSlot time = new AvailableTimeSlot
            {
                Id = model.Id,
                DoctorId = model.Doctor.Id,
                DayOfWeek= model.DayOfWeek,
                Hour= model.Hour,
            };

            _applicationDbContext.AvailableTimeSlots.Add(time);
            await _applicationDbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _applicationDbContext
                .AvailableTimeSlots
                .Include(x => x.Doctor)
                .SingleOrDefaultAsync(x => x.Id == id);

            if(model == null)
            {
                return NotFound();
            }

            var modelView = new AvailableTimeSlotViewModel
            {
                Id = model.Id,
                DayOfWeek = model.DayOfWeek,
                Hour = model.Hour,
                Doctor = new DoctorViewModel()
                {
                    Id = model.Doctor.Id,
                    UserName = model.Doctor.UserName,
                }
            };
            return View(modelView);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AvailableTimeSlotViewModel model)
        {
            var timeSlot = await _applicationDbContext
                .AvailableTimeSlots
                .SingleOrDefaultAsync(x => x.Id == model.Id);

            if (timeSlot == null)
            {
                NotFound();
            }

            timeSlot.DayOfWeek = model.DayOfWeek;
            timeSlot.Hour = model.Hour;
            timeSlot.DoctorId = model.Doctor.Id;

            await _applicationDbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
            return View(timeSlot);

        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {


            var model = await _applicationDbContext
                .AvailableTimeSlots
                .Include(x => x.Doctor)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (model == null)
            {
                NotFound();
            }

            var viewModel = new AvailableTimeSlotViewModel()
            {

                Id = model.Id,
                DayOfWeek = model.DayOfWeek,
                Hour = model.Hour,

            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(AvailableTimeSlotViewModel model)
        {
            var timeSlot = await _applicationDbContext
                .AvailableTimeSlots
                .SingleOrDefaultAsync(x => x.Id == model.Id);

            if (timeSlot == null)
            {
                NotFound();
            }


            timeSlot.Id = model.Id;
            timeSlot.DayOfWeek=model.DayOfWeek;
            timeSlot.Hour = model.Hour;


            _applicationDbContext.AvailableTimeSlots.Remove(timeSlot);
            await _applicationDbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }






    }

}
