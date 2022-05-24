using Microsoft.AspNetCore.Mvc;
using DentistBookingForm.Data;
using Microsoft.EntityFrameworkCore;
using DentistBookingForm.ViewModels;
using DentistBookingForm.Models;

namespace DentistBookingForm.Controllers
{
    public class ApplicationUserController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ApplicationUserController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<ActionResult> Index()
        {
            var applicationUserViewModels = await _applicationDbContext.Users
                .Select(user => new ApplicationUserViewModel
                {
                    UserName = user.UserName,
                    Id = user.Id,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                }).ToListAsync();

            return View(applicationUserViewModels);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model=new ApplicationUserViewModel();
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ApplicationUserViewModel model)
        {
            ApplicationUser user = new ApplicationUser
            {
              
                UserName = model.UserName,
                Id = model.Id,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
            };
            _applicationDbContext.Users.Add(user);
            await _applicationDbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

    }
}
