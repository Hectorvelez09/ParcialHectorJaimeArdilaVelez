using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebPage.Controllers
{
    public class TiketControllers : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public TiketControllers(IHttpClientFactory httpClient) //Inyectando la dependencia, interface 
        {
           _httpClient = httpClient;
        }
        public async Task<IActionResult> Index()
        {   
            //Consumir
            var url = "https://localhost:7136/api/TiketControllers/CheckTicket?ticketId=3F2504E0-4F89-11D3-9A0C-0305E82C3301";
            var json = await _httpClient.CreateClient().GetStringAsync(url);
            return View(json);
        }
    }
}
