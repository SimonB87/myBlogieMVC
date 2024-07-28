using myBloggieMVC.Models.Domain;

namespace myBloggieMVC.Repositories
{
    public interface ITagRespository
    {
        // here is definition of the methods inside iterface
        Task<IEnumerable<Tag>> GetAllAsync(); // Get All Tags

        Task<Tag?> GetAsync(Guid id); // Get single Tag. "Tag?" means it can be type Tag or null. If method doesn't find Tag, it will return null instead.

        Task<Tag> AddAsync(Tag tag); // Add Tag

        Task<Tag?> UpdateAsync(Tag tag); // Update Tag, "Tag?" means it can be type Tag or null

        Task<Tag?> DeleteAsync(Guid id); // "Tag?" means it can be type Tag or null. If method doesn't find Tag, it will return null instead.
    }
}
