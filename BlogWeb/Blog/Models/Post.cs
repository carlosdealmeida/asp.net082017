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

        [Display(Name = "Título: ")][Required(ErrorMessage = "Favor digitar o título")][StringLength(50,ErrorMessage = "O título só pode ter até 50 caracteres")]
        public string Titulo { get; set; }
        [Required][Display(Name = "Resumo: ")]
        public string Resumo { get; set; }
        [Display(Name = "Categoria: ")]
        public string Categoria { get; set; }
        public bool Publicado { get; set; }
        public DateTime? Data { get; set; }
    }
}