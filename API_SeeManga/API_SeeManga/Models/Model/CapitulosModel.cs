﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_SeeManga.Models.Model
{
    public class CapitulosModel
    {
        [Key]
        public int ID_CAPITULOS { get; set; }

        [Required]
        public int NUMERO { get; set; }

        [Required]
        public int QT_CAPITULOS { get; set; }

        [Required]
        public int ID_MANGA { get; set; }

        public virtual MangasModel Manga { get; set; }

        public virtual ICollection<PaginasModel> Paginas { get; set; }
    }
}
