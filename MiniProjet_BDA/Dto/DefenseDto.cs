using MiniProjet_BDA.Models;

namespace MiniProjet_BDA.Dto
{
    public class DefenseDto
    {
        public int Id { get; set; } // utilisé pour GET et PUT
        public DateTime? Date { get; set; }
        public int? ProjectId { get; set; }
        public int? RoomId { get; set; }

    }
}
