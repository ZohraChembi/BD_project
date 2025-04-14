namespace MiniProjet_BDA.Models
{
    public abstract class Evaluation
    {
        public Jury Jury { get; set; }
        public decimal Note { get; set; }
        public string Remark { get; set; }

        public bool IsValidNote()
        {
            return Note >= 0 && Note <= 20;
        }
    }
}
