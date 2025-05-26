namespace PetrovvEgorkt_31_22.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        // Связи с другими таблицами
        public int CathedralId { get; set; }
        public Cathedral Cathedral { get; set; }

        public int AcademicDegreeId { get; set; }
        public AcademicDegree AcademicDegree { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }
        public bool IsDeleted { get; internal set; }
    }
}
