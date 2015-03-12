namespace StudentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Courses
    {
        private ICollection<Students> students;
        private ICollection<Resources> resources;

        public Courses()
        {
            this.students = new HashSet<Students>();
            this.resources = new HashSet<Resources>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Students> Student
        {
            get { return this.students; }
            set { this.students = value; }
        }


        public virtual ICollection<Resources> Resources
        {
            get { return this.resources; }
            set { this.resources = value; } 
        }
    }
}
