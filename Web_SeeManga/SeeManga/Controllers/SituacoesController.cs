using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SeeManga.Models;
using SeeManga.Models.Model;

namespace SeeManga.Controllers
{
    public class SituacoesController : Controller
    {
        private readonly string urlApi;
        private readonly HttpClient client = new HttpClient();
        private readonly IConfiguration _configuration;

        public SituacoesController(IConfiguration configuration)
        {
            _configuration = configuration;
            urlApi = _configuration.GetValue<string>("AppSettings:conexao_API");
        }

        public async Task<IActionResult> Index()
        {
            var model = new MangaSituacoesModel();
            try
            {
                var response = await client.GetAsync($"{urlApi}/Situacoes");
                var responseData = JsonConvert.DeserializeObject<IEnumerable<DTOSituacao>>(await response.Content.ReadAsStringAsync());

                model.listDTOSituacoes = responseData;

                return View(model);
            }
            catch (Exception)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> AdicionarSituacao(DTOSituacao dtoSituacao)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            try
            {
                var json = JsonConvert.SerializeObject(dtoSituacao);
                var contentString = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"{urlApi}/Situacoes", contentString);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
    }
}