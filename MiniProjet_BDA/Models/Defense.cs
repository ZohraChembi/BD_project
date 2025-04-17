namespace MiniProjet_BDA.Models
   
{
    public class Defense
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        //project
        public int? ProjectId { get; set; }
        public Project? Project { get; set; }
        //room
        public int? RoomId { get; set; }
        public Room? Room { get; set; }

    }
}


