﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeeManga.Models.DTO
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

        //public virtual MangaModel Manga { get; set; }

        //public virtual ICollection<PaginasModel> Paginas { get; set; }
    }
}
