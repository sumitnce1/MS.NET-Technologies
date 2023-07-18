using Microsoft.AspNetCore.Mvc;
using SeconMvcApp.Models;
using System.Diagnostics;

namespace SeconMvcApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult Index()
        {
            return Redirect("/Home/MyName");
        }
        public IActionResult JsonResultDemo()
        {
            var data = new { Name = "Demo", Age = 30 }; 
            return Json(data);
        }
        public IActionResult FileResultDemo()
        {
            var path = "/img/text.jpg";
            return File(path, "image/jpg");
        }
        public IActionResult ContentResultDemo()
        {
            var conte = "Hello World";
            return Content(conte, "text/plain");
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public ViewResult MyName()
        {
            return View();
        }
        public string GetMyName(string name) 
        {
            return $"{name}";
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}