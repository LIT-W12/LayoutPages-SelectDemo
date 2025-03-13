using Microsoft.AspNetCore.Mvc;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class SelectDemoController : Controller
    {
        private string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=Northwnd;Integrated Security=true;TrustServerCertificate=yes;";
        public IActionResult Index()
        {
            ColorDb db = new ColorDb();

            return View(new SelectDemoViewModel
            {
                Colors = db.GetColors()
            });
        }

        public IActionResult Submit(int colorId)
        {
            var db = new ColorDb();
            var color = db.GetColors().FirstOrDefault(c => c.Id == colorId);

            return View(new SelectDemoPostViewModel
            {
                Color = color.Name
            });
        }

        public IActionResult Employees()
        {
            var db = new NorthwindDb(_connectionString);
            return View(new EmployeesViewModel
            {
                Employees = db.GetEmployees()
            });
        }
    }
}
