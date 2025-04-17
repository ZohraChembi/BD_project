namespace MiniProjet_BDA.Dto
{
    public class StudentDto
    {
        public int Id { get; set; }           // hérité de User
        public string? Name { get; set; }      // hérité de User
        public string? Email { get; set; }     // hérité de User
        public string? Role { get; set; }      // hérité de User
    }
}
