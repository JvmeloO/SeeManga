using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_SeeManga.Models.Model
{
    public class SituacoesModel
    {
        [Key]
        public int ID_SITUACAO { get; set; }

        [Required]
        [MaxLength(30)]
        public string SITUACAO { get; set; }

        public virtual ICollection<MangasModel> Mangas { get; set; }

    }
}
