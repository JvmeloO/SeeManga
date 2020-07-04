using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SeeManga.Models.DTO;
using SeeManga.Models.Model;

namespace SeeManga.Controllers
{
    public class MangasController : Controller
    {
        private readonly string urlApi;
        private readonly HttpClient client = new HttpClient();        
        private readonly IConfiguration _configuration;

        public MangasController(IConfiguration configuration)
        {
            _configuration = configuration;
            urlApi = _configuration.GetValue<string>("AppSettings:conexao_API");
        }

        public async Task<IActionResult> Index()
        {
            var mangaModel = new MangaModel();
            try
            {
                var response = await client.GetAsync($"{urlApi}/Mangas");
                var responseData = JsonConvert.DeserializeObject<IEnumerable<DTOMangas>>(await response.Content.ReadAsStringAsync());

                if (responseData.Count() == 0)
                {
                    return View(mangaModel);
                }

                var listDtoManga = new List<DTOMangas>();
                foreach (var item in responseData)
                {
                    var base64 = Convert.ToBase64String(item.CAPA);
                    var img = String.Format("data:image/gif;base64,{0}", base64);

                    var dtoManga = new DTOMangas()
                    {
                        ID_MANGA = item.ID_MANGA,
                        ID_SITUACAO = item.ID_SITUACAO,
                        TITULO = item.TITULO,
                        SINOPSE = item.SINOPSE,
                        CAPABASE64 = img
                    };

                    listDtoManga.Add(dtoManga);
                }

                mangaModel.DtoManga = listDtoManga;

                return View(mangaModel);
            }
            catch (Exception)
            {
                return View(mangaModel);
            }
        }

        public async Task<IActionResult> AdicionarManga()
        {
            var model = new MangaGenerosSituacaoModel();
            try
            {
                var responseG = await client.GetAsync($"{urlApi}/Generos");
                var responseS = await client.GetAsync($"{urlApi}/Situacoes");
                var responseDataG = JsonConvert.DeserializeObject<IEnumerable<DTOGeneros>>(await responseG.Content.ReadAsStringAsync());
                var responseDataS = JsonConvert.DeserializeObject<IEnumerable<DTOSituacoes>>(await responseS.Content.ReadAsStringAsync());

                model.ListDtoGenero = responseDataG;
                model.ListDtoSituacao = responseDataS;

                return View(model);
            }
            catch (Exception)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> PostAdicionarManga(MangaGenerosSituacaoModel modelManga) 
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("AdicionarManga");
            }

            foreach (var item in modelManga.Capa)
            {
                if (item.Length > 0)
                {
                    using var stream = new MemoryStream();
                    await item.CopyToAsync(stream);
                    modelManga.DtoManga.CAPA = stream.ToArray();
                }
            }

            try
            {
                var manga_generos = new Manga_Generos
                {
                    DtoManga = modelManga.DtoManga,
                    GenerosSelected = modelManga.GenerosSelected
                };

                var json = JsonConvert.SerializeObject(manga_generos);
                var contentString = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"{urlApi}/Mangas", contentString);           

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("AdicionarManga");
            }
        }
    }
}