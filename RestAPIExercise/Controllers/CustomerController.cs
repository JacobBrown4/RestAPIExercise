using Microsoft.AspNetCore.Mvc;

namespace RestAPIExercise.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
