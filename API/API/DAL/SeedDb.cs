using API.DAL.Entities;
using Microsoft.EntityFrameworkCore;


namespace API.DAL
{
    public class SeedDb
    {
        private readonly DataBaseContext _context;

        public SeedDb(DataBaseContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckTickets();
            await CheckEntrances();
            await AssignEntrancesToTickets();
        }
        private async Task CheckTickets()
        {
            if (!_context.Tikets.Any())
            {
                for (int i = 0; i < 50000; i++)
                {
                    Tiket tiket = new Tiket
                    {
                        Id = Guid.NewGuid(),
                        UseDate = null,
                        IsUsed = false,
                        EntranceGateTiket = new List<EntranceGateTiket>()
                    };

                    _context.Tikets.Add(tiket);
                }

                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckEntrances()
        {
            if (!_context.EntranceGates.Any())
            {
                _context.EntranceGates.Add(new EntranceGate { Id = Guid.NewGuid(), Name = "Norte" });
                _context.EntranceGates.Add(new EntranceGate { Id = Guid.NewGuid(), Name = "Sur" });
                _context.EntranceGates.Add(new EntranceGate { Id = Guid.NewGuid(), Name = "Oriental" });
                _context.EntranceGates.Add(new EntranceGate { Id = Guid.NewGuid(), Name = "Occidental" });
                await _context.SaveChangesAsync();
            }
        }
        private async Task AssignEntrancesToTickets()
        {
            if (!_context.EntranceGateTikets.Any())
            {
                var tickets = await _context.Tikets.ToListAsync();
                var entrances = await _context.EntranceGates.ToListAsync();

                var random = new Random();
                tickets = tickets.OrderBy(x => random.Next()).ToList();
                entrances = entrances.OrderBy(x => random.Next()).ToList();

                for (int i = 0; i < tickets.Count; i++)
                {
                    var ticket = tickets[i];
                    var entrance = entrances[i % entrances.Count];

                    ticket.EntranceGateTiket = new List<EntranceGateTiket>();
                    ticket.EntranceGateTiket.Add(new EntranceGateTiket
                    {
                        TicketId = ticket.Id,
                        EntranceGateId = entrance.Id
                    });
                }

                await _context.SaveChangesAsync();
            }
        }
    }
}
