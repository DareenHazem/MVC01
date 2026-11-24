using Microsoft.AspNetCore.Mvc;

namespace DemoSession1.Controllers
{
    public class MembersControllers : Controller
    {

        //BaseUrl/Member/Index
        public IActionResult Index()
        {
            return View();
        }

        //BaseUrl/Member/GetMembers
        public IActionResult GetMembers()
        {
            return View();
        }

        //BaseUrl/Member/Create
        public IActionResult Create()
        {
            return View();
        }
    }
}
