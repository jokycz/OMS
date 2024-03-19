using Microsoft.AspNetCore.Mvc;

namespace FiStar.OMS.Controllers
{
    [Controller]
    public class NumbersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
