using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_SeeManga.DTO
{
    public class DTOCapitulos
    {
        [Key]
        public int ID_CAPITULOS { get; set; }

        [Required]
        public int NUMERO { get; set; }

        [Required]
        public int QT_CAPITULOS { get; set; }

        [Required]
        public int ID_MANGA { get; set; }

        public virtual DTOMangas Manga { get; set; }

        public virtual ICollection<DTOPaginas> Paginas { get; set; }
    }
}
