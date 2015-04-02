namespace PhonebookCodeFirst
{
    using System;
    using System.Data.Entity;

    public class PhonebookMigrationStrategy
        : DropCreateDatabaseIfModelChanges<PhonebookContext>
    {
        protected override void Seed(PhonebookContext context)
        {
            var peterFirstEmail = new Email() { EmailAddress = "peter@gmail.com" };
            context.Emails.Add(peterFirstEmail);
            var peterSecondEmail = new Email() { EmailAddress = "peter_ivanov@yahoo.com" };
            context.Emails.Add(peterFirstEmail);
            var angieEmail = new Email() { EmailAddress = "peter_ivanov@yahoo.com" };
            context.Emails.Add(angieEmail);

            var peterFirstPhone = new Phone() { PhoneNumber = "+359 2 22 22 22" };
            context.Phones.Add(peterFirstPhone);
            var peterSecondPhone = new Phone() { PhoneNumber = "+359 88 77 88 99" };
            context.Phones.Add(peterSecondPhone);
            var mariaPhone = new Phone() { PhoneNumber = "+359 22 33 44 55" };
            context.Phones.Add(mariaPhone);

            var peter = new Contact()
            {
                Name = "Peter Ivanov",
                Position = "CTO",
                Emails = { peterFirstEmail, peterSecondEmail },
                Phones = { peterFirstPhone, peterSecondPhone },
                Site = "http://blog.peter.com",
                Notes = "Friend from school"
            };
            context.Contacts.Add(peter);

            var maria = new Contact()
            {
                Name = "Maria",
                Phones = { mariaPhone }
            };
            context.Contacts.Add(maria);

            var angie = new Contact()
            {
                Name = "Angie Stanton",
                Emails = { angieEmail },
                Site = "http://angiestanton.com"
            };
            context.Contacts.Add(angie);
        }
    }
}
