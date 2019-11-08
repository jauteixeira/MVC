using Microsoft.AspNetCore.Mvc;

namespace exMVC.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Login ()
        {
            return View();
        }
    }
}