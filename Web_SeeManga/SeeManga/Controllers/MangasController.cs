using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace SeeManga.Controllers
{
    public class MangasController : Controller
    {
        string urlApi;
        HttpClient client = new HttpClient();        
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
            try
            {
                //HttpResponseMessage response = client.GetAsync($"{urlApi}+/api/generos").Result;
                
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }

        
    }
}