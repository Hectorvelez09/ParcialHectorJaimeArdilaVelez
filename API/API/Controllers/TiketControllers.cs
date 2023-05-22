using API.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TiketControllers : ControllerBase
    {
        private readonly DataBaseContext _context;
        public TiketControllers(DataBaseContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> CheckTicket(Guid ticketId)
        {
            // Buscar la boleta por ID
            var ticket = await _context.Tikets.Include(t => t.EntranceGateTiket).ThenInclude(egt => egt.EntranceGate).FirstOrDefaultAsync(t => t.Id == ticketId);

            if (ticket == null)
            {
                // Boleta no existe
                return Ok("Boleta no válida");
            }

            if (ticket.IsUsed)
            {
                // Boleta ya usada
                var entranceName = ticket.EntranceGateTiket.First().EntranceGate.Name;
                var useDate = ticket.UseDate;
                return Ok($"Boleta ya usada el {useDate} en la portería {entranceName}");
            }

            // Boleta válida
            ticket.UseDate = DateTime.Now;
            ticket.IsUsed = true;
            ticket.EntranceGateTiket.First();

            await _context.SaveChangesAsync();

            return Ok("Boleta válida, puede ingresar al concierto");
        }
    }
}
