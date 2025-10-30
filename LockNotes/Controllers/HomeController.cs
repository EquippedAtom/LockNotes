using Microsoft.AspNetCore.Mvc;

namespace LockNotes.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("MVC is working! 🚀 Go to /Notes next.");
        }
    }
}
