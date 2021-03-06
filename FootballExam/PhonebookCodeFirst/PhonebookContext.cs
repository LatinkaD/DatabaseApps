namespace PhonebookCodeFirst
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PhonebookContext : DbContext
    {
        public PhonebookContext()
            : base("name=PhonebookContext")
        {
        }
        public virtual DbSet<Contact> Contacts { get; set; }

        public virtual DbSet<Email> Emails { get; set; }

        public virtual DbSet<Phone> Phones { get; set; }

    }
}