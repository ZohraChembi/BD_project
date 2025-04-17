namespace MiniProjet_BDA.Dto
{
    
        public class RoomDto
        {
        public int? RoomId { get; set; }
        public int? RoomNumber { get; set; }

        public bool IsRoomAvailable(DateTime date)
        {
            // Implémentez la logique pour vérifier la disponibilité
            return true;
        }
    }
    }


