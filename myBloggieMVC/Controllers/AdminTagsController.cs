using Microsoft.AspNetCore.Mvc;

namespace myBloggieMVC.Controllers
{
    public class AdminTagsController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}
