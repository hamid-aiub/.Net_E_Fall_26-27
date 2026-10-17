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

        public IActionResult Update(int id)
        {
            var student = _context.Student.FirstOrDefault(s => s.id == id);
            if(student == null)
            {
                return NotFound();
            }

            return View(student);
        }
        public IActionResult Delete(int id)
        {
            var student = _context.Student.FirstOrDefault(s => s.id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);

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

        [HttpPost]
        public IActionResult Update(int id, Student student)
        {
            var std = _context.Student.FirstOrDefault(s => s.id == id);
            if (std == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                std.name = student.name;
                std.department = student.department;
                std.program = student.program;
                std.credit_completed = student.credit_completed;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();

        }
        [HttpPost]
        public IActionResult Remove(int id)
        {
            var student = _context.Student.FirstOrDefault(s => s.id == id);
            if (student == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Student.Remove(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
