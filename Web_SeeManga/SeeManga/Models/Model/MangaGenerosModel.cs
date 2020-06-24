using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeeManga.Models.Model
{
    public class MangaGenerosModel
    {
        public DTOManga dtoManga { get; set; }

        public DTOGenero dtoGenero { get; set; }

        public IEnumerable<DTOGenero> listDTOGenero { get; set; }

        
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
