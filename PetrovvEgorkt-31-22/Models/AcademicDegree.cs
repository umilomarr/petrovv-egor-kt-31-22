namespace PetrovvEgorkt_31_22.Models
{
    public class AcademicDegree
    {
        public int AcademicDegreeId { get; set; }
        public string DegreeName { get; set; } // "Кандидат наук", "Доктор наук"
        public bool IsDeleted { get; internal set; }
    }
}
