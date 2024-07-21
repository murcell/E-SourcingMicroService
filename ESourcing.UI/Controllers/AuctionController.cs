using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ESourcing.UI.Controllers
{
    //[Authorize]
    public class AuctionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
