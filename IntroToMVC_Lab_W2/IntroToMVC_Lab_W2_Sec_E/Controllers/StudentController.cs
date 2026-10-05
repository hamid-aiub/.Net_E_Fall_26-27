using Microsoft.AspNetCore.Mvc;
using IntroToMVC_Lab_W2_Sec_E.Models;

namespace IntroToMVC_Lab_W2_Sec_E.Controllers
{
    [Route("abcd")]
    public class StudentController : Controller
    {
        // localhost:port/student
        [Route("dashboard")]
        public IActionResult Index()
        {
            Student[] students = new Student[5];
            for(int i = 0; i < 5; i++)
            {
                var student = new Student()
                {
                    id = i + 1,
                    name = "Student " + (i + 1),
                    dept = "Department " + (i + 1)
                };
                students[i] = student;
            }
            return View(students);
        }

        //localhost:port/student/details
        [Route("details")]
        [Route("info")]
        public IActionResult Details()
        {
            return View();
        }
    }
}
