namespace PetrovvEgorkt_31_22.Models
{
    public class Workload
    {
        public int WorkloadId { get; set; }

        // Связи с преподавателем и дисциплиной
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int DisciplineId { get; set; }
        public Discipline Discipline { get; set; }

        // Тип занятия (лекция/практика)
        public string LessonType { get; set; }

        // Количество часов
        public int Hours { get; set; }
    }
}
