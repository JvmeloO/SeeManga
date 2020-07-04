using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeeManga.Models.DTO
{
    public class Manga_Generos
    {
        public DTOMangas DtoManga { get; set; }

        public List<int> GenerosSelected { get; set; }
    }
}
