namespace MiniProjet_BDA.Models
{
    public class Jury : Professor
    {
       
        public int DefenseId { get; set; } // Clé étrangère
        public Defense Defense { get; set; } // Navigation vers la soutenance


        public Jury()
        {
            Role = "jury";
        }
    }

}
