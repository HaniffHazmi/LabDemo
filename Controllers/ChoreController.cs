using LabDemo.Data;
using LabDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabDemo.Controllers
{
    public class ChoreController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public ChoreController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var chores = await dbContext.Chores.ToListAsync();

            return View(chores);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ChoreViewModel viewModel)
        {
            var chores = new Chore
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                DueDate = viewModel.DueDate
            };

            await dbContext.Chores.AddAsync(chores);
            await dbContext.SaveChangesAsync();

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id) 
        {
            var chore = await dbContext.Chores.FindAsync(id);

            if (chore == null)
            {
                return NotFound();
            }

            return View(new ChoreViewModel
            {
                Id = chore.Id,
                Title = chore.Title,
                Description = chore.Description,
                DueDate = chore.DueDate,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ChoreViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var chore = await dbContext.Chores.FindAsync(viewModel.Id);

            if (chore == null) 
            {
                return NotFound();
            }

            chore.Title = viewModel.Title;
            chore.Description = viewModel.Description;
            chore.DueDate = viewModel.DueDate;

            await dbContext.SaveChangesAsync();

            return RedirectToAction("List","Chores");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ChoreViewModel viewModel)
        {
            var chore = await dbContext.Chores.FindAsync(viewModel.Id);

            if(chore != null)
            {
                dbContext.Chores.Remove(chore);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Chore");
        }
    }
}
