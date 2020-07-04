using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_SeeManga.DTO
{
    public class DTOGeneros
    {
        [Key]
        public int ID_GENERO { get; set; }

        [Required]
        [MaxLength(30)]
        public string NM_GENERO { get; set; }
        
        public virtual ICollection<DTOManga_Generos> Manga_generos { get; set; }
    }
}
