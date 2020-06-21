using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_SeeManga.Models.Model
{
    public class PaginasModel
    {
        [Key]
        public int ID_PAGINAS { get; set; }

        [Required]
        public int NUMERO { get; set; }

        [Required]
        public byte[] PAGINA { get; set; }

        [Required]
        public int ID_CAPITULOS { get; set; }

        public CapitulosModel Capitulo { get; set; }

    }
}
