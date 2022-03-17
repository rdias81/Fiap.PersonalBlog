using Fiap.PersonalBlog.Interfaces;
using Fiap.PersonalBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fiap.PersonalBlog.Persistence
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogContext _dataContext;

        public BlogRepository(BlogContext context)
        {
            _dataContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Atualizar(BlogPost post)
        {
            _dataContext.Entry(post).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dataContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            var post = _dataContext.Posts.Find(id);

            if (post != null)
            {
                _dataContext.Posts.Remove(post);
                _dataContext.SaveChanges();
            }
        }

        public void Incluir(BlogPost post)
        {
            _dataContext.Posts.Add(post);
            _dataContext.SaveChanges();
        }

        public BlogPost Obter(int id)
        {
            return _dataContext.Posts.FirstOrDefault(m => m.PostId == id);
        }

        public IEnumerable<BlogPost> Listar()
        {
            return _dataContext.Posts.ToList();
        }
    }
}
