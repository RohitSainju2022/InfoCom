﻿namespace InfoCom.Model
{
    public class Schedule
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? DueDate { get; set; }

        public bool IsDeleted { get; set; }

    }
}
