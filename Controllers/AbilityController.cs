using Microsoft.AspNetCore.Mvc;
using DentistBookingForm.Data;
using DentistBookingForm.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DentistBookingForm.ViewModels;

namespace DentistBookingForm.Controllers
{
    public class AbilityController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public AbilityController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        public async Task<ActionResult> Index()
        {
            var AbilityViewModels = await _applicationDbContext
                .Abilities

                .Select(ability => new AbilityViewModel
                {
                    Id = ability.Id,
                    Name = ability.Name,
                    Doctor = new DoctorViewModel()
                    {
                        UserName = ability.Doctor.UserName
                    },

                }).ToListAsync();

            return View(AbilityViewModels);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var model = new AbilityViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Create(AbilityViewModel model)
        {
            Ability ability = new Ability

            {
                Id = model.Id,
                Name = model.Name,
                DoctorId = model.Doctor.Id

            };
            _applicationDbContext.Abilities.Add(ability);
            await _applicationDbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _applicationDbContext
                .Abilities
                .Include(x => x.Doctor)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (model == null)
            {
                return NotFound();
            }

            var viewModel = new AbilityViewModel()
            {
                Name = model.Name,
                Id = model.Id,
                Doctor = new DoctorViewModel()
                {
                    Id = model.Doctor.Id,
                    UserName = model.Doctor.UserName
                }
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AbilityViewModel model)
        {

            var ability = await _applicationDbContext
                .Abilities
                .SingleOrDefaultAsync(x => x.Id == model.Id);
            
            if (ability == null)
            {
                return NotFound();
            }

            ability.Name = model.Name;
            ability.DoctorId = model.Doctor.Id;




            await _applicationDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            return View(ability);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            

            var model = await _applicationDbContext
                .Abilities
                .Include(x => x.Doctor)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (model == null)
            {
                NotFound();
            }

            var viewModel = new AbilityViewModel()
            {
               
                Id = model.Id,
               
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(AbilityViewModel model)
        {
            var ability = await _applicationDbContext
                .Abilities
                .SingleOrDefaultAsync(x=>x.Id==model.Id);

            if (ability == null)
            {
                NotFound();
            }

           
            ability.Id=model.Id;
           

           _applicationDbContext.Abilities.Remove(ability);
            await _applicationDbContext.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));

        }
            
        


    }
    
}









