using myBloggieMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Bloggie.Web.Data;
using myBloggieMVC.Models.Domain;
using Microsoft.EntityFrameworkCore;
using myBloggieMVC.Repositories;

namespace myBloggieMVC.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly ITagRespository tagRepository;

		public AdminTagsController(ITagRespository tagRepository)
        {
            this.tagRepository = tagRepository;
		}

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> Add(AddTagRequest addTagRequest)
        {
            // Mapping the AddTagRequest to Tag domain model
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName
            };
            // moved lines to Add and Dave to Iterface
            await tagRepository.AddAsync(tag);

            return RedirectToAction("List"); 
        }

        [HttpGet]
        [ActionName("List")]
        public async Task<IActionResult> List() {

            var tags = await tagRepository.GetAllAsync(); 

			return View(tags);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id) 
        {
            var tag = await tagRepository.GetAsync(id);
            
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
        public async Task<IActionResult> Edit(EditTagRequest editTagRequest) 
        {
            var tag = new Tag 
            { 
                Id = editTagRequest.Id,
                Name = editTagRequest.Name,
                DisplayName = editTagRequest.DisplayName 
            };

           var updatedTag = await tagRepository.UpdateAsync(tag);

            if (updatedTag != null)
            {
                //Show success notification

            }
            else 
            {
                // Show Error notification
            }

            //Show Error notification
            return RedirectToAction("Edit", new { id = editTagRequest.Id });
        }

        public async Task<IActionResult> Delete(EditTagRequest editTagRequest)
        {
            var deletedTag = await tagRepository.DeleteAsync(editTagRequest.Id);

            if (deletedTag != null) 
            {
                //show success notification
                return RedirectToAction("List");       
            
            }

            // Show error notificaion
            return RedirectToAction("Edit", new { id = editTagRequest.Id });
        }
    }
}
