using Blog.Infra;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blog.DAL
{
    public class PostDAO
    {
        public void Adiciona(Post p)
        {
            using (var ctx = new BlogContext())
            {
                ctx.Posts.Add(p);
                ctx.SaveChanges();
            }
        }

        public IList<Post> Lista()
        {
            using (var ctx = new BlogContext())
            {
                return ctx.Posts.ToList();
            }
        }

        public IList<Post> PostsPorCategoria(string cat)
        {
            using (var ctx = new BlogContext())
            {
                return ctx.Posts.Where(p => p.Categoria == cat).ToList();
            }
        }
    }
}