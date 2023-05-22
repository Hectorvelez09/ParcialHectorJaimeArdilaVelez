namespace API.DAL.Entities
{
    public class Tiket
    {
        public Guid Id { get; set; }
        public DateTime? UseDate { get; set; }
        public Boolean IsUsed { get; set; }
        public ICollection<EntranceGateTiket> EntranceGateTiket { get; set; }
    }
}
