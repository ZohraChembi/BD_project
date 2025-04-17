using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProjet_BDA.Models
{
    public class DefenseEvaluation
    {
        public int? DefenseEvaluationId { get; set; } // Clé primaire
        public int? DefenseId { get; set; } // Référence à une soutenance
        public Defense? Defense { get; set; } // Navigation vers la soutenance
        public int? JuryId { get; set; } // Ajoutez cette propriété
        public Jury? Jury { get; set; } // Navigation vers un jury
        public decimal Note { get; set; } // Note entre 0 et 20
        public string? Remark { get; set; }
    }


}
