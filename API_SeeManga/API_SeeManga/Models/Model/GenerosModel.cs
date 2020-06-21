using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_SeeManga.Models.Model
{
    public class GenerosModel
    {
        [Key]
        public int ID_GENERO { get; set; }

        [Required]
        public string NM_GENERO { get; set; }

        public virtual ICollection<MangasModel> Mangas { get; set; }
    }
}
