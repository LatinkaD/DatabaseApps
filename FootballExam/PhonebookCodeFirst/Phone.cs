namespace PhonebookCodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Phone
    {
        public int Id { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public virtual Contact Contact { get; set; }
    }
}
