using myBloggieMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Bloggie.Web.Data;
using myBloggieMVC.Models.Domain;

namespace myBloggieMVC.Controllers
{
    public class AdminTagsController : Controller
    {
		private readonly BloggieDbContext bloggieDbContext;

		public AdminTagsController(BloggieDbContext bloggieDbContext)
        {
			this.bloggieDbContext = bloggieDbContext;
		}

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        public IActionResult Add(AddTagRequest addTagRequest)
        {
            // Mapping the AddTagRequest to Tag domain model
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName
            };

            bloggieDbContext.Tags.Add(tag);
            bloggieDbContext.SaveChanges(); // to save data to DB

			return View("Add"); //return view
        }

        [HttpGet]
        public IActionResult List() {
            // use DB Context to read Tags
            var tags = bloggieDbContext.Tags.ToList(); //all tags are in variable "tags" 


			return View(tags);
        }
    }
}
