namespace PetrovvEgorkt_31_22.Models
{
    public class Discipline
    {
        public int DisciplineId { get; set; }
        public string DisciplineName { get; set; }
        public bool IsDeleted { get; internal set; }
    }
}
