using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IntroToMVC_E.Controllers
{
    public class StudentController : Controller
    {
        // localhost:port/student
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(string id)
        {
            var student = new IntroToMVC_E.Models.StudentModel()
            {
                id = id,
                name = "John Doe",
                age = 20,
                cgpa = 3.5f,
                phone = "123-456-7890",
                email = "test@test.com",
                password = "12345"

            };
            return View(student);
        }
    }
}
