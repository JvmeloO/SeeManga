using SeeManga.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeeManga.Models.Model
{
    public class SituacoesModel
    {
        public DTOSituacoes DtoSituacao { get; set; }

        public IEnumerable<DTOSituacoes> ListDTOSituacoes { get; set; }

    }
}
