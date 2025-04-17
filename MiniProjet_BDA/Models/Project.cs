namespace MiniProjet_BDA.Models
{
    public class Project
    {
        public int? ProjectId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Professor? Supervisor { get; set; }
        public Team? Team { get; set; }
        public int? SupervisorId { get; set; } // Ajoutez cette propriété
        public int? TeamId { get; set; } // Ajoutez cette propriété
    }
}
    
      
     



