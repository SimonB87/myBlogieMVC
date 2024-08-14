using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using myBloggieMVC.Models.ViewModels;
using myBloggieMVC.Models.Domain;
using myBloggieMVC.Repositories;

namespace myBloggieMVC.Controllers
{
    public class AdminBlogPostsController : Controller
    {
		private readonly ITagRespository tagRespository;

		public AdminBlogPostsController(ITagRespository tagRespository)
        {
			this.tagRespository = tagRespository;
		}
        [HttpGet]
        public async Task<IActionResult> Add() 
        {
            // get tags from repository
            var tags = await tagRespository.GetAllAsync();

            var model = new AddBlogPostRequest
            {
				Tags = tags.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }) 
            };

            return View(model);
        }

        public async Task<IActionResult> Add(AddBlogPostRequest addBlogPostRequest)
        {
            return RedirectToAction("Add");
        }
    }
}
