using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Encodings.Web;
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
            ViewBag.UserId = "I have Vijay Id";
            ViewBag.UserName = "I have Vijay Id";

            ViewData["ID"] = "600116";
            LoadDropDown();
            return View();
        }

        public IActionResult MyEndPoint()
        {   
            return Redirect("https://gemini.google.com/");
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

        public RedirectToRouteResult GoToHome()
        {
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        public IActionResult Vijay()
        {
            return RedirectToAction("Privacy","Home");
        }

        public JsonResult GetJson()
        {
            var data = new { Id = 1, name = "Vijay", Department = "IT Infra" };
            return Json(data);
        }

        public FileResult DownloadFile(string name)
        {
            //TicketinHub.pdf
            byte[] fileBytes = System.IO.File.ReadAllBytes("wwwroot/" + name);
            return File(fileBytes, "application/pdf", "Download.pdf");
        }

        public ContentResult ShowText()
        {
            return Content("Hello World");
        }

        public IActionResult Empty()
        {
            return null;
        }
        public IActionResult Empty1()
        {
            return new EmptyResult();
        }
        public IActionResult Status()
        {
            //return StatusCode(200, "Loged in successfully");
            return StatusCode(404, "Loged in successfully");
        }

        public IActionResult FileStream()
        {
            var stream = new FileStream("wwwroot/TicketinHub.pdf", FileMode.Open);
            return File(stream, "text/plain");
        }

        public IActionResult BadRequest()
        {
            return BadRequest("Invalid Data");
        }
        public IActionResult NotFound()
        {
            return NotFound("Not Found");
        }
    }
}
