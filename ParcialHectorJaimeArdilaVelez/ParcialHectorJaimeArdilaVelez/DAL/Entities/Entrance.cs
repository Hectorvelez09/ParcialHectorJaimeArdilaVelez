namespace ParcialHectorJaimeArdilaVelez.DAL.Entities
{
    public class Entrance
    {

        public Guid Id { get; set; }

        public string Name { get; set; }


         public ICollection <StadiumTickets> StadiumTickets { get; set;}
    }
}
