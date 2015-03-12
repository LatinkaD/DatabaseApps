namespace StudentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Students
    {
        private ICollection<Courses> courses;
        private ICollection<Homeworks> homeworks;
        public Students()
        {
            this.courses = new HashSet<Courses>();
            this.homeworks = new HashSet<Homeworks>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [MaxLength(10)]
        public string PhoneNumber { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime Birthday { get; set; }

        public int HomeworkId { get; set; }

        public virtual ICollection<Homeworks> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; } 
        }

        public virtual ICollection<Courses> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }
    }
}
