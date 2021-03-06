﻿namespace PhonebookCodeFirst
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Contact
    {
        public Contact()
        {
            this.Emails = new HashSet<Email>();
            this.Phones = new HashSet<Phone>();

        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Position { get; set; }

        public string Company { get; set; }

        public string Site { get; set; }

        [Column(TypeName = "text")]
        public string Notes { get; set; }

        public virtual ICollection<Email> Emails { get; set; }

        public virtual ICollection<Phone> Phones { get; set; }

    }
}
