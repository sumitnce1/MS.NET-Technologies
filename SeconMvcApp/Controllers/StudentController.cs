using Microsoft.AspNetCore.Mvc;
using SeconMvcApp.Models;

namespace SeconMvcApp.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index(StudentDB studentDB)
        {
            List<StudentViewModel> userList = studentDB.GetStudentViews();
            return View(userList);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(string id)
        {
            StudentViewModel? StudentViewModel = StudentDB.GetStudent(Convert.ToInt32(id));
            return View(StudentViewModel);
        }
        public IActionResult Details(string id)
        {
            StudentViewModel? StudentViewModel = StudentDB.GetStudent(Convert.ToInt32(id));
            return View(StudentViewModel);
        }
        public IActionResult Delete(string id)
        {
            StudentViewModel StudentViewModel = StudentDB.GetStudent(Convert.ToInt32(id));
            StudentDB.DeleteStudent(StudentViewModel);
            return Redirect("/Student/Index");
        }
        [HttpPost]
        public IActionResult Edit(StudentViewModel StudentViewModel)
        {
            StudentDB.UpdateStudent(StudentViewModel);
            return Redirect("/Student/Index");
        }
        [HttpPost]
        public IActionResult Create(StudentViewModel StudentViewModel)
        {
            StudentDB.AddStudent(StudentViewModel);
            return Redirect("/Student/Index");
            //return View();
        }
    }
}


