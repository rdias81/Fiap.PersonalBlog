using Fiap.PersonalBlog.Models;
using System.Collections.Generic;

namespace Fiap.PersonalBlog.Interfaces
{
    public interface IBlogService
    {
        List<BlogPost> GetLatestPosts();
        string GetPostText(string link);
    }
}
