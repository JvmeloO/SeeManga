using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeeManga.Models.Model
{
    public class GenerosModel
    {
        public DTOGenero DtoGenero { get; set; }

        public IEnumerable<DTOGenero> ListDTOGeneros { get; set; }

    }
}
