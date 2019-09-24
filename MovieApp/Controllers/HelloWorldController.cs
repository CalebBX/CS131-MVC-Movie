using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MovieApp.Controllers
{
    public class HelloWorldController : Controller
    {
        public string Index()
        {
            return "Hello World";
        }
        public string Welcome(string name, int ID)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, your Id is: {ID}");
        }
        public IActionResult AboutUs()
        {
            return View();
        }
    }
}