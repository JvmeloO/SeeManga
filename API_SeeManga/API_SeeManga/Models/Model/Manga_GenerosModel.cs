using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_SeeManga.Models.Model
{
    public class Manga_GenerosModel
    {
        //[Key]
        public int ID_MANGA { get; set; }

        //[Key]
        public int ID_GENERO { get; set; }

        public virtual GenerosModel Genero { get; set; }

        public virtual MangasModel Manga { get; set; }
    }
}
