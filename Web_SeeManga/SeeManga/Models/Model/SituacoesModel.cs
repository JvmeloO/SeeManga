using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeeManga.Models.Model
{
    public class SituacoesModel
    {
        public DTOSituacao DtoSituacao { get; set; }

        public IEnumerable<DTOSituacao> ListDTOSituacoes { get; set; }

    }
}
