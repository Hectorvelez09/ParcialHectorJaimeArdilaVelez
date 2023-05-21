using System.Diagnostics.Metrics;

namespace ParcialHectorJaimeArdilaVelez.DAL.Entities
{
    public class SeederDb
    {
        private readonly DataBaseContext _context;
        public SeederDb(DataBaseContext context)
        {
            _context = context;
        }

        public async Task SeederAsync()
        {
            await _context.Database.EnsureCreatedAsync(); //Esta línea me ayuda a crear mi BD de forma automática
            await PopulateStadiumTicketssAsync();


            await _context.SaveChangesAsync();
        }

        private Task PopulateStadiumTicketssAsync()
        {

            if (!_context.StadiumTicketss.Any())
            {
                _context.StadiumTicketss.Add(new StadiumTickets
                {
                    Id = ,
                    Name = "Colombia",
                    States = new List<State>()
                    {

                    }

                }
}
        }
    