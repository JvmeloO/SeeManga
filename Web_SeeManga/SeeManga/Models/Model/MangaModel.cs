using SeeManga.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeeManga.Models.Model
{
    public class MangaModel
    {
        public IEnumerable<DTOMangas> DtoManga { get; set; }
    }
}
