namespace MiniProjet_BDA.Dto
{
   
        public class ProjectDto
        {
            public int ProjectId { get; set; }
            public string? Title { get; set; }
            public string? Description { get; set; }

            public int? SupervisorId { get; set; }
            public int? TeamId { get; set; }

            // Optionnel (si tu veux les noms dans le frontend)
            // public string? SupervisorName { get; set; }
            // public string? TeamName { get; set; }
        }
    }


