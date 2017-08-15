using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Favor digitar o título")][StringLength(50,ErrorMessage = "O título só pode ter até 50 caracteres")]
        public string Titulo { get; set; }
        [Required]
        public string Resumo { get; set; }
        public string Categoria { get; set; }
        public bool Publicado { get; set; }
        public DateTime? Data { get; set; }
    }
}