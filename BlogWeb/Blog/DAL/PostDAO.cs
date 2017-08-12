using Blog.Infra;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
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
                //ctx.Database.Log = MostraSql;
                ctx.Posts.Add(p);
                ctx.SaveChanges();
            }
        }

        public void Remove (int id)
        {
            using (var ctx = new BlogContext())
            {
                var post = ctx.Posts.Find(id);
                ctx.Posts.Remove(post);
                ctx.SaveChanges();
            }
        }

        public void Update(Post p)
        {
            using (var ctx = new BlogContext())
            {
                ctx.Entry(p).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        public Post BuscaPorId(int id)
        {
            using (var ctx = new BlogContext())
            {
                return ctx.Posts.Find(id);
            }
        }

        public IList<Post> Lista()
        {
            using (var ctx = new BlogContext())
            {
                //ctx.Database.Log = MostraSql;
                return ctx.Posts.ToList();
            }
        }

        public IList<Post> PostsPorCategoria(string cat)
        {
            using (var ctx = new BlogContext())
            {
                //ctx.Database.Log = MostraSql;
                return ctx.Posts.Where(p => p.Categoria == cat).ToList();
            }
        }

        private void MostraSql(string sql)
        {
            Debug.WriteLine(sql);
        }
    }
}