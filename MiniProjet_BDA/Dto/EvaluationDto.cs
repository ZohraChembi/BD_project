namespace MiniProjet_BDA.Dto
{

    public class EvaluationDto
        {
            public int JuryId { get; set; }  // Identifiant du jury
            public decimal Note { get; set; }  // La note attribuée
            public string? Remark { get; set; }  // Les remarques

            // Validation pour la note (facultatif mais peut être utilisé pour validation dans le contrôleur ou service)
            public bool IsValidNote()
            {
                return Note >= 0 && Note <= 20;
            }
        }
    }


