using Fiap.PersonalBlog.Models;
using System.Collections.Generic;

namespace Fiap.PersonalBlog.Interfaces
{
    public interface IBlogRepository
    {
        void Atualizar(BlogPost post);
        void Excluir(int id);
        void Incluir(BlogPost post);
        IEnumerable<BlogPost> Listar();
        BlogPost Obter(int id);
    }
}