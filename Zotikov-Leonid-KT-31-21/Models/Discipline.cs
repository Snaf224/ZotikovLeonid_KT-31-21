
namespace Zotikov_Leonid_KT_31_21.Models
{
    public class Discipline
    {
        public int DisciplineId { get; set; }

        public string? DisciplineName { get; set; }

        //связь
        public int StudentId { get; set; }

        public Student Student { get; set; }
    }
}
