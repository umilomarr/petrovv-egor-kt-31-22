using System.Text.Json.Serialization;

namespace PetrovvEgorkt_31_22.Models
{
    public class Cathedral
    {
        public int CathedralId { get; set; }
        public string CathedralName { get; set; }

        public int HeadTeacherId { get; set; }
        [JsonIgnore]
        public Teacher HeadTeacher { get; set; }
        [JsonIgnore]
        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
        [JsonIgnore]
        public bool IsDeleted { get; internal set; }

    }
}
