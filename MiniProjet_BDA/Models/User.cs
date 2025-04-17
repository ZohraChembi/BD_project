namespace MiniProjet_BDA.Models
{
    public class User
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; } // Assurez-vous de hacher les mots de passe !
        public string? Role { get; set; }


        public bool IsAdmin()
        {
            return Role == "admin";
        }
    }


}
