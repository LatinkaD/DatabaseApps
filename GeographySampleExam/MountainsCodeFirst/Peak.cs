namespace MountainsCodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    
    public class Peak
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Elevation { get; set; }

        public virtual Mountain Mountain { get; set; }
    }
}
