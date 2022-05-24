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
    }

}
