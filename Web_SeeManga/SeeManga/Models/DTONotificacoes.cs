using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeeManga.Models
{
    public class DTONotificacoes
    {
        [Key]
        public int ID_NOTIFICACOES { get; set; }

        [Required]
        public int ID_SEGUIR { get; set; }

        //public SeguirModel Seguir { get; set; }
    }
}
