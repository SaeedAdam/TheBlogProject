using Microsoft.EntityFrameworkCore;
using System.Linq;
using TheBlogProject.Data;
using TheBlogProject.Enums;
using TheBlogProject.Models;

namespace TheBlogProject.Services;

public class BlogSearchService
{
    private readonly ApplicationDbContext _context;

    public BlogSearchService(ApplicationDbContext dbContext)
    {
        _context = dbContext;
    }

    public IQueryable<Post> Search(string searchTerm)
    {
        var posts = _context.Posts
            .Include(b => b.BlogUser)
            .Where(p => p.ReadyStatus == ReadyStatus.ProductionReady)
            .AsQueryable();

        if (searchTerm != null)
        {
            searchTerm = searchTerm.ToLower();

            posts = posts.Where(
                p => p.Title.ToLower().Contains(searchTerm) ||
                     p.Abstract.ToLower().Contains(searchTerm) ||
                     p.Content.ToLower().Contains(searchTerm) ||
                     p.Comments.Any(c => c.Body.ToLower().Contains(searchTerm) ||
                                         c.ModeratedBody.ToLower().Contains(searchTerm) ||
                                         c.BlogUser.FirstName.ToLower().Contains(searchTerm) ||
                                         c.BlogUser.LastName.ToLower().Contains(searchTerm) ||
                                         c.BlogUser.Email.ToLower().Contains(searchTerm)));
        }

        return posts.OrderByDescending(p => p.Created);
    }
}
