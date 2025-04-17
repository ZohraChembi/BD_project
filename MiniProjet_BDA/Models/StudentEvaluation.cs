namespace MiniProjet_BDA.Models
{
    public class StudentEvaluation : Evaluation
    {
        public int? StudentEvaluationId { get; set; } // Clé primaire
        public int? StudentId { get; set; } // Référence à un étudiant
        public Student? Student { get; set; } // Navigation pour l'étudiant
        public int? JuryId { get; set; } // Référence à un membre du jury
        public Jury? Jury { get; set; } // Navigation pour le jury
    }


}
