using System.Data;

namespace MiniProjet_BDA.Dto
{
    public class ProfessorDto
    {
        public int Id { get; set; }
        public string? Role { get; }

        public ProfessorDto()
        {
            Role = "professor";
        }
    }
}
