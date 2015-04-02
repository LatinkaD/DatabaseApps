namespace PhonebookCodeFirst
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    class PhonebookCodeFirst
    {
        static void Main()
        {
            Database.SetInitializer(new PhonebookMigrationStrategy());
            var context = new PhonebookContext();
            var contactsQuery = context.Contacts
                .Select(c => new
                {
                    ContactName = c.Name,
                    Emails = c.Emails.Select(e => new { e.EmailAddress }),
                    Phones = c.Phones.Select(p => new { p.PhoneNumber })
                });

            foreach (var contact in contactsQuery)
            {
                Console.WriteLine("Contact: " + contact.ContactName);

                Console.WriteLine("Emails: ");
                foreach (var email in contact.Emails)
                {
                    Console.WriteLine("\t" + email.EmailAddress);
                }

                Console.WriteLine("Phones: ");
                foreach (var phone in contact.Phones)
                {
                    Console.WriteLine("\t" + phone.PhoneNumber);
                }
                Console.WriteLine();
            }
        }
    }
}
