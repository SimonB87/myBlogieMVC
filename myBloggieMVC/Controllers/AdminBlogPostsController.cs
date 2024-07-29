using Microsoft.AspNetCore.Mvc;

namespace myBloggieMVC.Controllers
{
    public class AdminBlogPostsController : Controller
    {
        [HttpGet]
        public IActionResult Add() 
        {
            return View();
        }
    }
}
