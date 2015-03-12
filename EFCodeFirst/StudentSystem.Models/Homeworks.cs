namespace StudentSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Homeworks
    {
        public Homeworks() { }

        public int Id { get; set; }

        public string Content { get; set; }

        public ContentType ContentType { get; set; }

        public DateTime DateTime { get; set; }

        public int StudentId { get; set; }

        public virtual Students Student { get; set; }

        public int CourseId { get; set; }

        public virtual Courses Course { get; set; }
    }
}
