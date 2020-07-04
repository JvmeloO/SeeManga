using Microsoft.AspNetCore.Mvc.Rendering;
using SeeManga.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeeManga.Models.Model
{
    public class GenerosModel
    {
        public DTOGeneros DtoGenero { get; set; }

        public IEnumerable<DTOGeneros> ListDTOGeneros { get; set; }

    }
}
