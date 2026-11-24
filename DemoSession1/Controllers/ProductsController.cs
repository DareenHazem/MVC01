using DemoSession1.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoSession1.Controllers
{
    //[Route("Test/[action]")]
    public class ProductsController : Controller
    {
        public ViewResult index()
        {
            //First Mehtod
            //var view = new ViewResult();
            //return view;

            //Second Method using the helper func 
            return View();
        }

        [HttpGet("Json")] //- Annotation
        public IActionResult GetJsonResults()
        {
            var productlist = new List<Product>()
            {
                new Product(){Id=1, Name = "Laptop"},
                new Product(){Id=2, Name = "PC"},
                new Product(){Id=3, Name = "Phone"},
                new Product(){Id=4, Name = "Keyboard"}
            };

            return Json(productlist);
        }

        //BaseUrl/Products/GetProducts - Convention
        //[HttpGet("ProductCode/{id:int?}")] //- Annotation
        public IActionResult GetProducts(int id)
        {
            if (id == 0)
                return BadRequest();

            if (id != 3)
                return NotFound();

            var productlist = new List<Product>()
            {
                new Product(){Id=1, Name = "Laptop"},
                new Product(){Id=2, Name = "PC"},
                new Product(){Id=3, Name = "Phone"},
                new Product(){Id=4, Name = "Keyboard"}
            };

            return Json(productlist);
        }

        public RedirectToActionResult Redirect()
        {
            return RedirectToAction(nameof(GetProducts));
        }

        public RedirectResult RedirectToFacebook()
        {
            return Redirect("https://www.facebook.com/");
        }

        public ContentResult Content()
        {
            // Plain Text
            //return Content("Hi, From Products");

            // Html Text
            return Content("<h1>Hi, From Products<h1>", "text/html");
        }

        public FileResult DownloadFile()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "css", "site.css");
            var fileBytes = System.IO.File.ReadAllBytes(filePath);

            return File(fileBytes, "text/css", "MyCSS.css");

        }

    }
}
