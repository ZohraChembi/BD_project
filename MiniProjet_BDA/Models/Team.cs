namespace MiniProjet_BDA.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public Student? Student1 { get; set; }
        public Student?  Student2 { get; set; }
        public int? Student1Id { get; set; } // Ajoutez cette propriété
        public int? Student2Id { get; set; } // Id optionnel

        public bool IsValidTeam()
        {
            return Student1 != null && (Student2 == null || Student1.Id != Student2.Id);
        }
    }
   


}
