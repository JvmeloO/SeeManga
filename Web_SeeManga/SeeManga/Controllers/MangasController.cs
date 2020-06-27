using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SeeManga.Models;
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

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AdicionarManga()
        {
            var model = new MangaGenerosSituacaoModel();
            try
            {
                var responseG = await client.GetAsync($"{urlApi}/Generos");
                var responseS = await client.GetAsync($"{urlApi}/Situacoes");
                var responseDataG = JsonConvert.DeserializeObject<IEnumerable<DTOGenero>>(await responseG.Content.ReadAsStringAsync());
                var responseDataS = JsonConvert.DeserializeObject<IEnumerable<DTOSituacao>>(await responseS.Content.ReadAsStringAsync());

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
            return View();
        }
    }
}