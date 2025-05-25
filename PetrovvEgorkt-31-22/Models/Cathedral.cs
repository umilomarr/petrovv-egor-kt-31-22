namespace PetrovvEgorkt_31_22.Models
{
    public class Cathedral
    {
        public int CathedralId { get; set; }
        public string CathedralName { get; set; }

        public int HeadTeacherId { get; set; }
        public Teacher HeadTeacher { get; set; }
    }
}
