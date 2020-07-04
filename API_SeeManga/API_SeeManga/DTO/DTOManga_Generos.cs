using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_SeeManga.DTO
{
    public class DTOManga_Generos
    {
        //[Key]
        public int ID_MANGA { get; set; }

        //[Key]
        public int ID_GENERO { get; set; }

        public virtual DTOGeneros Genero { get; set; }

        public virtual DTOMangas Manga { get; set; }
    }
}
