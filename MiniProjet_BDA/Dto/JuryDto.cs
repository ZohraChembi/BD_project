namespace MiniProjet_BDA.Dto
{
     public class JuryDto
        {
            public int Id { get; set; } // hérité men Professor
            public string? Nom { get; set; }
            public string? Prenom { get; set; }
            public string? Email { get; set; }
            public string? Grade { get; set; }

            public int? DefenseId { get; set; }
        }
    }

