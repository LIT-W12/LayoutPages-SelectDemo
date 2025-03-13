using Microsoft.AspNetCore.Mvc;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class NorthwindController : Controller
    {
        private string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=Northwnd;Integrated Security=true;TrustServerCertificate=yes;";
        
        public IActionResult Products()
        {
            var db = new NorthwindDb(_connectionString);
            var vm = new ProductsViewModel
            {
                Products = db.GetProducts()
            };
            return View(vm);
        }
    }

    //Create a .Net Core MVC Application. Get rid of the Privacy page. On the home
    //page, display a list of orders from the northwind database.
}
