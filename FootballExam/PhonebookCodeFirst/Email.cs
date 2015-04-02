namespace PhonebookCodeFirst
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Email
    {
        public int Id { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        public virtual Contact Contact { get; set; }

    }
}
