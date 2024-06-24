using myBloggieMVC.Models.ViewModels;
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

        [HttpPost]
        [ActionName("Add")]
        public IActionResult Add(AddTagRequest addTagRequest)
        {
            var name = addTagRequest.Name;
            var displayName = addTagRequest.DisplayName;

            return View("Add"); //return view
        } 
    }
}
