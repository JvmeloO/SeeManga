using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeeManga.Models
{
    public class DTOUsuario
    {
        [Key]
        public int ID_USUARIO { get; set; }

        [MaxLength(20)]
        public string USUARIO { get; set; }

        //[Required]
        //[MaxLength(256)]
        //public string NOME { get; set; }

        //[Required]
        //[MaxLength(256)]
        //public string EMAIL { get; set; }

        //[Required]
        //public DateTime DATACADASTRO { get; set; }

        //public ICollection<SeguirModel> Seguir { get; set; }

        //public ICollection<ComentariosModel> Comentarios { get; set; }

        //public ICollection<UsuariosBanModel> UsuariosBan { get; set; }
    }
}
