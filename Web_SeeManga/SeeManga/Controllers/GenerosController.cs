using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SeeManga.Models;
using SeeManga.Models.Model;

namespace SeeManga.Controllers
{
    public class GenerosController : Controller
    {
        private readonly string urlApi;
        private readonly HttpClient client = new HttpClient();
        private readonly IConfiguration _configuration;

        public GenerosController(IConfiguration configuration)
        {
            _configuration = configuration;
            urlApi = _configuration.GetValue<string>("AppSettings:conexao_API");
        }

        public async Task<IActionResult> Index()
        {
            var model = new MangaGenerosModel();
            try
            {
                var response = await client.GetAsync($"{urlApi}/Generos");
                var responseData = JsonConvert.DeserializeObject<IEnumerable<DTOGenero>>(await response.Content.ReadAsStringAsync());

                model.listDTOGeneros = responseData;

                return View(model);
            }
            catch (Exception) 
            {
                return View(model);
            }
        }

        public async Task<IActionResult> AdicionarGenero(DTOGenero dtoGenero) 
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            try
            {
                var json = JsonConvert.SerializeObject(dtoGenero);
                var contentString = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"{urlApi}/Generos", contentString);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetEditarGenero(int id) 
        {
            var response = await client.GetAsync($"{urlApi}/Generos/{id}");
            var responseData = JsonConvert.DeserializeObject<DTOGenero>(await response.Content.ReadAsStringAsync());

            var responseJson = JsonConvert.SerializeObject(responseData);

            return Json(responseJson);
        }

        public async Task<IActionResult> EditarGenero(DTOGenero dtoGenero) 
        {
            try
            {
                var json = JsonConvert.SerializeObject(dtoGenero);
                var contentString = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"{urlApi}/Generos/{dtoGenero.ID_GENERO}", contentString);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> DeletarGenero(int id)
        {
            try
            {
                var delete = await client.DeleteAsync($"{urlApi}/Generos/{id}");

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
    }
}