using Bloggie.Web.Data;
using Microsoft.EntityFrameworkCore;
using myBloggieMVC.Models.Domain;

namespace myBloggieMVC.Repositories
{
    public class TagRepository : ITagRespository
    {
        private readonly BloggieDbContext bloggieDbContext;
        public TagRepository(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
        }
        public async Task<Tag> AddAsync(Tag tag)
        {
            // NOTE - await used to make the line asyncronous
            await bloggieDbContext.Tags.AddAsync(tag);
            await bloggieDbContext.SaveChangesAsync(); // to save data to DB

            return tag;
        }

        public async Task<Tag?> DeleteAsync(Guid id)
        {
            var existingTag = await bloggieDbContext.Tags.FindAsync(id);

            if (existingTag != null) 
            { 
                bloggieDbContext.Tags.Remove(existingTag);
                await bloggieDbContext.SaveChangesAsync();

                return existingTag;
            }

            return null;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            // use DB Context to read Tags
            return await bloggieDbContext.Tags.ToListAsync(); //all tags are in variable "tags" 
        }

        public Task<Tag?> GetAsync(Guid id)
        {
            return bloggieDbContext.Tags.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Tag?> UpdateAsync(Tag tag)
        {
            var existingTag = await bloggieDbContext.Tags.FindAsync(tag.Id);

            if (existingTag != null) {
                existingTag.Name = tag.Name;
                existingTag.DisplayName = tag.DisplayName;

                //to save changes
                await bloggieDbContext.SaveChangesAsync();

                return existingTag;
            }

            return null; //if the existingTag was not found return null
        }
    }
}
