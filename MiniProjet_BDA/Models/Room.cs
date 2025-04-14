namespace MiniProjet_BDA.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }

        public bool IsRoomAvailable(DateTime date)
        {
            // Implémentez la logique pour vérifier la disponibilité
            return true;
        }
    }


}
