using System.Text.Json.Serialization;

namespace PetrovvEgorkt_31_22.Models
{
    public class Workload
    {
        public int WorkloadId { get; set; }

        // Связи с преподавателем и дисциплиной
        public int TeacherId { get; set; }
        [JsonIgnore]
        public Teacher Teacher { get; set; }

        public int DisciplineId { get; set; }
        [JsonIgnore]
        public Discipline Discipline { get; set; }

        // Тип занятия (лекция/практика)
        public string LessonType { get; set; }

        // Количество часов
        public int Hours { get; set; }
        [JsonIgnore]
        public bool IsDeleted { get; internal set; }


    }
}
