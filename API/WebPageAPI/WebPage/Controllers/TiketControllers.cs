using API.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace WebPage.Controllers
{
    public class TiketControllers : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public TiketControllers(IHttpClientFactory httpClient) //Inyectando la dependencia, interface 
        {
            _httpClient = httpClient;
        }
        [HttpPost]
        public async Task<IActionResult> Index(Tiket tiket)
        {
            // Consumir
            var url = "https://localhost:7136/api/TiketControllers/CheckTicket?ticketId=3F2504E0-4F89-11D3-9A0C-0305E82C3301";
            var response = await _httpClient.CreateClient().PostAsJsonAsync(url, tiket);

            if (response.IsSuccessStatusCode)
            {
                // El consumo fue exitoso
                return RedirectToAction("SuccessAction");
            }
            else
            {
                // El consumo falló
                return RedirectToAction("ErrorAction");
            }
        }
    }

}
   

