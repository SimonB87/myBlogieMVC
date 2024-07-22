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

            return RedirectToAction("List"); 
        }

        [HttpGet]
        [ActionName("List")]
        public IActionResult List() {
            // use DB Context to read Tags
            var tags = bloggieDbContext.Tags.ToList(); //all tags are in variable "tags" 


			return View(tags);
        }

        [HttpGet]
        public IActionResult Edit(Guid id) 
        {
            //1st method
            //var tag = bloggieDbContext.Tags.Find(id);
            //2nd method
            var tag = bloggieDbContext.Tags.FirstOrDefault(x => x.Id == id);

            if (tag != null)
            {
                var editTagRequest = new EditTagRequest
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    DisplayName = tag.DisplayName
                };

                return View(editTagRequest);
            }

           return View(null);
        }

        [HttpPost]
        public IActionResult Edit(EditTagRequest editTagRequest) 
        {
            var tag = new Tag 
            { 
                Id = editTagRequest.Id,
                Name = editTagRequest.Name,
                DisplayName = editTagRequest.DisplayName 
            };

            var exisTingTag = bloggieDbContext.Tags.Find(tag.Id);

            if (exisTingTag != null) 
            { 
                exisTingTag.Name = tag.Name;
                exisTingTag.DisplayName = tag.DisplayName;

                //to save changes
                bloggieDbContext.SaveChanges();

                // Show Success notification
                return RedirectToAction("List", new { id = editTagRequest.Id }); 
            }

            //Show Error notification
            return RedirectToAction("Edit", new { id = editTagRequest.Id });
        }

        public IActionResult Delete(EditTagRequest editTagRequest)
        {
            var tag = bloggieDbContext.Tags.Find(editTagRequest.Id);

            if (tag != null) 
            {
                bloggieDbContext.Tags.Remove(tag);
                //to save changes
                bloggieDbContext.SaveChanges();

                // Show Success notification
                return RedirectToAction("List");
            }

            // Show error notificaion
            return RedirectToAction("Edit", new { id = editTagRequest.Id });
        }
    }
}
