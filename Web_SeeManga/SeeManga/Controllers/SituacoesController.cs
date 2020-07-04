using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SeeManga.Models.DTO;
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
            var model = new SituacoesModel();
            try
            {
                var response = await client.GetAsync($"{urlApi}/Situacoes");
                var responseData = JsonConvert.DeserializeObject<IEnumerable<DTOSituacoes>>(await response.Content.ReadAsStringAsync());

                if (responseData.Count() == 0)
                {
                    return View(model);
                }

                model.ListDTOSituacoes = responseData;

                return View(model);
            }
            catch (Exception)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> AdicionarSituacao(DTOSituacoes dtoSituacao)
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

        [HttpGet]
        public async Task<JsonResult> GetEditarSituacao(int id)
        {
            var response = await client.GetAsync($"{urlApi}/Situacoes/{id}");
            var responseData = JsonConvert.DeserializeObject<DTOSituacoes>(await response.Content.ReadAsStringAsync());

            var responseJson = JsonConvert.SerializeObject(responseData);

            return Json(responseJson);
        }

        public async Task<IActionResult> EditarSituacao(DTOSituacoes dtoSituacao)
        {
            try
            {
                var json = JsonConvert.SerializeObject(dtoSituacao);
                var contentString = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"{urlApi}/Situacoes/{dtoSituacao.ID_SITUACAO}", contentString);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> DeletarSituacao(int id)
        {
            try
            {
                var delete = await client.DeleteAsync($"{urlApi}/Situacoes/{id}");

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
    }
}