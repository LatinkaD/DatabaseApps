namespace StudentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Resources
    {
        public Resources() { }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public TypeOfResource TypeOfResource { get; set; }

        public string Link { get; set; }

        public int CourseId { get; set; }

        public virtual Courses Courses { get; set; }
    }
}
