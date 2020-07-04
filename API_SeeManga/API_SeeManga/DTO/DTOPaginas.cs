using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_SeeManga.DTO
{
    public class DTOPaginas
    {
        [Key]
        public int ID_PAGINAS { get; set; }

        [Required]
        public int NUMERO { get; set; }

        [Required]
        public byte[] PAGINA { get; set; }

        [Required]
        public int ID_CAPITULOS { get; set; }

        public DTOCapitulos Capitulo { get; set; }

    }
}
