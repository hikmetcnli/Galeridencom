using Microsoft.AspNetCore.Mvc;

namespace Galeriden_com.Controllers
{
    public class SatisController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Musteri");
                         
        }

        

    }
}
