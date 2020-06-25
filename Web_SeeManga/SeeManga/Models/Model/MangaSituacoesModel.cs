using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeeManga.Models.Model
{
    public class MangaSituacoesModel
    {
        public DTOManga dtoManga { get; set; }

        public DTOSituacao dtoSituacao { get; set; }

        public IEnumerable<DTOSituacao> listDTOSituacoes { get; set; }

        //public List<SelectListItem> GetLocais()
        //{
        //    List<SelectListItem> locais = new List<SelectListItem>();
        //    locais.Add(
        //            new SelectListItem()
        //            {
        //                Disabled = false,
        //                Text = "Selecionar",
        //                Value = "",
        //                Selected = true
        //            });
        //    if (CadastradosLocal != null)
        //    {
        //        foreach (var item in CadastradosLocal)
        //        {
        //            locais.Add(
        //                new SelectListItem()
        //                {
        //                    Disabled = false,
        //                    Text = item.NmLocal,
        //                    Value = item.CdLocal.ToString()
        //                });
        //        }
        //        return locais;
        //    }
        //    else
        //    {
        //        return locais;
        //    }
        //}
    }
}
