using IntroToEF_E.EF;
using Microsoft.AspNetCore.Mvc;
using IntroToEF_E.Models;

namespace IntroToEF_E.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;
        public StudentController(AppDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            var students = _context.Student.ToList();
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Student.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }
    }
}
