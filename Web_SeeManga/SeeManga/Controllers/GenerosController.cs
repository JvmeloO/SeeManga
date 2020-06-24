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
        string urlApi;
        HttpClient client = new HttpClient();
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

                model.listDTOGenero = responseData;

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
                throw;
            }
        }
    }
}