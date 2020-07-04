using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using SeeManga.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeeManga.Models.Model
{
    public class MangaGenerosSituacaoModel
    {
        public DTOMangas DtoManga { get; set; }

        [Required]
        public List<IFormFile> Capa { get; set; }

        [Required]
        public List<int> GenerosSelected { get; set; }

        public DTOSituacoes DtoSituacao { get; set; }

        public IEnumerable<DTOGeneros> ListDtoGenero { get; set; } 

        public IEnumerable<DTOSituacoes> ListDtoSituacao { get; set; }

        public List<SelectListItem> GetGeneros()
        {
            List<SelectListItem> generos = new List<SelectListItem>
            {
                //new SelectListItem()
                //{
                //    Disabled = false,
                //    Text = "Selecionar",
                //    Value = "",
                //    Selected = true
                //}
            };
            if (ListDtoGenero != null)
            {
                foreach (var item in ListDtoGenero)
                {
                    generos.Add(
                        new SelectListItem()
                        {
                            Disabled = false,
                            Text = item.NM_GENERO,
                            Value = item.ID_GENERO.ToString()
                        });
                }
                return generos;
            }
            else
            {
                return generos;
            }
        }

        public List<SelectListItem> GetSituacoes()
        {
            List<SelectListItem> situacoes = new List<SelectListItem>
            {
                new SelectListItem()
                {
                    Disabled = false,
                    Text = "Selecionar",
                    Value = "",
                    Selected = true
                }
            };
            if (ListDtoSituacao != null)
            {
                foreach (var item in ListDtoSituacao)
                {
                    situacoes.Add(
                        new SelectListItem()
                        {
                            Disabled = false,
                            Text = item.SITUACAO,
                            Value = item.ID_SITUACAO.ToString()
                        });
                }
                return situacoes;
            }
            else
            {
                return situacoes;
            }
        }
    }
}
