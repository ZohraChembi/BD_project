namespace MiniProjet_BDA.Dto
{
    
        public class TeamDto
        {
            public int TeamId { get; set; }
            public int Student1Id { get; set; }
            public int? Student2Id { get; set; }

            // Optionnel si tu veux afficher les noms dans le frontend :
            // public string? Student1Name { get; set; }
            // public string? Student2Name { get; set; }
        }
    }

