namespace MiniProjet_BDA.Models
{
    public class Student : User
    {
        // Hérite de User
        public List<StudentEvaluation> Evaluations { get; set; }
        public Student()
        {
            Role = "student";
        }
    }


}
