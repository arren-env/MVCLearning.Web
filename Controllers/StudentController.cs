using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCLearning.Web.Data;
using MVCLearning.Web.Models;
using MVCLearning.Web.Models.Entities;

namespace MVCLearning.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public StudentController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(AddStudentViewModel viewModel)
        {

            var student = new Student
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Subscribed = viewModel.Subscribed
            };
            await dbContext.Students.AddAsync(student);

            await dbContext.SaveChangesAsync();
            return RedirectToAction("List", "Student");
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            var students = await dbContext.Students.ToListAsync();
            return View(students);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            var student = await dbContext.Students.FindAsync(id);
            return View(student);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Student viewModel)
        {
            var studentToUpdate = await dbContext.Students.FindAsync(viewModel.Id);
            if (studentToUpdate is not null)
            {
                studentToUpdate.Name = viewModel.Name;
                studentToUpdate.Email = viewModel.Email;
                studentToUpdate.Phone = viewModel.Phone;
                studentToUpdate.Subscribed = viewModel.Subscribed;
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Student");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Student viewModel)
        {
            var student = await dbContext.Students.AsNoTracking().FirstOrDefaultAsync(s => s.Id == viewModel.Id);
            if (student is not null)
            {
                dbContext.Students.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Student");
        }
    }
}
