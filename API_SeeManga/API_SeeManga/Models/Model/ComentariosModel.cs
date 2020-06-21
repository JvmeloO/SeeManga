using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_SeeManga.Models.Model
{
    public class ComentariosModel
    {
        [Key]
        public int ID_COMENTARIOS { get; set; }

        [Required]
        [MaxLength(500)]
        public string COMENTARIO { get; set; }

        [Required]
        public int ID_USUARIO { get; set; }

        [Required]
        public int ID_MANGA { get; set; }

        public MangasModel Manga { get; set; }
    }
}
