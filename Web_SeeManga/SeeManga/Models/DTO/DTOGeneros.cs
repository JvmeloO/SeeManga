using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeeManga.Models.DTO
{
    public class DTOGeneros
    {
        [Key]
        public int ID_GENERO { get; set; }

        [Required]
        [MaxLength(20)]
        public string NM_GENERO { get; set; }

        //public virtual ICollection<MangasModel> Mangas { get; set; }
    }
}
