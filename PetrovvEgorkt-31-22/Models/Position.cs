﻿namespace PetrovvEgorkt_31_22.Models
{
    public class Position
    {
        public int PositionId { get; set; }
        public string PositionName { get; set; } // "Преподаватель", "Доцент" и т.д.
        public bool IsDeleted { get; internal set; }
    }
}
