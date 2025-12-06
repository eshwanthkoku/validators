using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using validators.Models;

namespace validators.Controllers
{
    public class StudentController : Controller
    {
        private static List<StudentViewModel> students = new List<StudentViewModel>();
        public ActionResult Index()
        {
            return View(students);
        }
        public IActionResult Create()
        {
            LoadDropDown();
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                students.Add(model);
                return RedirectToAction("Index");
            }
            LoadDropDown();
            return View();
        }

        private void LoadDropDown()
        {
            ViewBag.Vijay = new List<SelectListItem>
            {
                new SelectListItem {Text = "India", Value="1"},
                new SelectListItem {Text = "UK", Value="2"},
                new SelectListItem {Text = "USA", Value="3"}
            };
        }
    }
}
