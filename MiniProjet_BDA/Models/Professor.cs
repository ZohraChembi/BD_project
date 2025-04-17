namespace MiniProjet_BDA.Models
{
    public class Professor : User
    {
        public int? Id { get; set; }
        public Professor()
        {
            Role = "professor";
        }

        public bool IsAvailableOn(DateTime date)
        {
            // Implémentez la logique pour vérifier la disponibilité
            return true;
        }

    }
}
