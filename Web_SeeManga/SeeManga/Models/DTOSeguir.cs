using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeeManga.Models
{
    public class DTOSeguir
    {
        [Key]
        public int ID_SEGUIR { get; set; }

        [Required]
        public int ID_USUARIO { get; set; }

        [Required]
        public int ID_MANGA { get; set; }

        //public virtual UsuarioModel Usuario { get; set; }

        //public virtual MangaModel Manga { get; set; }

        //public ICollection<NotificacoesModel> notificacoes { get; set; }
    }
}
