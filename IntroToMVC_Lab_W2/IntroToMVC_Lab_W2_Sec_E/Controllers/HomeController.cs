using IntroToMVC_Lab_W2_Sec_E.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IntroToMVC_Lab_W2_Sec_E.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // localhost:port/Home/Privacy
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
