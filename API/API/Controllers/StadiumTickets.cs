using API.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StadiumTickets : ControllerBase
    {
        private readonly DataBaseContext _context;
        public StadiumTickets(DataBaseContext _context)
        {
            _context = _context;
        }

        [HttpPost]

        public async Task<IActionResult> ValidateTickets (Guid Id)
        {

            var tickeexist = await _context.StadiumTicketss.AnyAsync(st => st.Id == Id);
            if (!tickeexist)
            {
                return Ok("Boleta no validad");
            }
            
            if (await _context.StadiumTicketss.AnyAsync(st => st.Id == Id && st.IsUsed == false))
            {
                var ticketUsed = await _context.StadiumTicketss.Include(st => st.Entrance).FirstOrDefaultAsync(st => st.Id == Id && !st.IsUsed);

                if (ticketUsed != null) 
                {
                    return Ok("Boleta ya usada " + ticketUsed.UseDate + ticketUsed.Entrance);
                }
            }
            return Ok();
        }
       
    }
}
