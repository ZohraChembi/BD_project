namespace MiniProjet_BDA.Models
{
    public class Defense
    {

        public int DefenseId { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }

        public DateTime DefenseDate { get; set; }





    }




}


