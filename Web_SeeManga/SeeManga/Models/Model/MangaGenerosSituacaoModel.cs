using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeeManga.Models.Model
{
    public class MangaGenerosSituacaoModel
    {
        public DTOManga DtoManga { get; set; }

        [Required]
        public IEnumerable<DTOGenero> GenerosSelected { get; set; }

        public DTOSituacao DtoSituacao { get; set; }

        public IEnumerable<DTOGenero> ListDtoGenero { get; set; } 

        public IEnumerable<DTOSituacao> ListDtoSituacao { get; set; }

        public List<SelectListItem> GetGeneros()
        {
            List<SelectListItem> generos = new List<SelectListItem>
            {
                new SelectListItem()
                {
                    Disabled = false,
                    Text = "Selecionar",
                    Value = "",
                    Selected = true
                }
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
