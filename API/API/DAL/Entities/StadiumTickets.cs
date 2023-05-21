using System.ComponentModel.DataAnnotations;

namespace API.DAL.Entities
{
    public class StadiumTickets 
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime? UseDate { get; set; }
        public bool IsUsed { get; set; }
        public string EntranceGate { get; set; }

        public ICollection<Entrance> Entrance { get; set; }

    }
}
