using Fiap.PersonalBlog.Interfaces;
using Fiap.PersonalBlog.Models;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Fiap.PersonalBlog.Services
{
    public class BlogService : IBlogService
    {
        private readonly IHostEnvironment _env;
        private readonly IBlogRepository _repository;

        public BlogService(IHostEnvironment env, IBlogRepository repository)
        {
            _env = env;
            _repository = repository;
        }

        private List<BlogPost> Posts
        {
            get
            {
                return new List<BlogPost>() {
                    new BlogPost { PostId = 1, Title = "How to capture posts via APIs", ShortDescription = "How to use fetch to get a list of blog posts" },
                    new BlogPost { PostId = 2, Title = "Using Indexed DB", ShortDescription = "How to save a list of posts using IndexedDB" },
                    new BlogPost { PostId = 3, Title = "Using Cache to store Blog posts", ShortDescription = "How to use the Cache API to store blog posts that can be available offline" },
                    new BlogPost { PostId = 4, Title = "Obtaining cache data from Service Worker", ShortDescription = "How to use Service Workers to get data from cache when user is offline" },
                    new BlogPost { PostId = 5, Title = "Creating a Installable Web App", ShortDescription = "How to create the files that allow you to install your site as an App on your phone" },
                    new BlogPost { PostId = 6, Title = "Sending push notifications", ShortDescription = "How to send push notifications to call your user attention to something on your app" },
                    new BlogPost { PostId = 7, Title = "Camera, Microphone and Video", ShortDescription = "How powerful the native file inputs can be" },
                    new BlogPost { PostId = 8, Title = "Geolocation", ShortDescription = "How to know where your user is located using geocoding" },
                    new BlogPost { PostId = 9, Title = "Vibration", ShortDescription = "How to vibrate your phone" },
                    new BlogPost { PostId = 10, Title = "Gyroscope", ShortDescription = "How to capture phone gyroscope" },
                    new BlogPost { PostId = 11, Title = "Code Improvements", ShortDescription = "How to improve the implementation" },
                    new BlogPost { PostId = 12, Title = "Debugging on the Phone", ShortDescription = "How connect to a Phone and debug from there" },
                    new BlogPost { PostId = 13, Title = "Using AutoMapper", ShortDescription = "Using AutoMapper" },
                    new BlogPost { PostId = 14, Title = "Using AutoMapper part 2", ShortDescription = "Using AutoMapper part 2" }
                };
            }
        }

        private List<BlogPost> GetLastOrderingPosts(IEnumerable<BlogPost> query)
        {
            return query.OrderByDescending(e => e.PostId).Take(3).ToList();
        }

        public List<BlogPost> GetLatestPosts()
        {
            var posts = _repository.Listar();
            return GetLastOrderingPosts(posts);
        }

        public List<BlogPost> GetOlderPosts(int olderBlogPostId)
        {
            var posts = _repository.Listar();
            var query = posts.Where(post => post.PostId < olderBlogPostId);
            return GetLastOrderingPosts(query);
        }

        public string GetPostText(string link)
        {
            var posts = _repository.Listar();
            var post = posts.FirstOrDefault(post => post.Link == link);

            return post.Content;
            //return File.ReadAllText($"{_env.ContentRootPath}/wwwroot/Posts/{post.PostId}_post.md");
        }
    }
}
