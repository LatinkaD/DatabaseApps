namespace ImportContactsFromJSON
{
    using System;
    using System.IO;
    using Newtonsoft.Json.Linq;
    using PhonebookCodeFirst;

    class ImportContacts
    {
        static void Main()
        {
            string json = File.ReadAllText("../../contacts.json");
            var contacts = JArray.Parse(json);

            foreach (var contact in contacts)
            {
                try
                {
                    ImportContact(contact);
                    Console.WriteLine("Contact {0} imported", contact["name"]);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
        }

        private static void ImportContact(JToken contactObj)
        {
            var context = new PhonebookContext();
            var contact = new Contact();

            if (contactObj["name"] == null)
            {
                throw new Exception("Name is required");
            }

            contact.Name = contactObj["name"].Value<string>();

            var phones = contactObj["phones"];
            if (phones != null)
            {
                foreach (var phone in phones)
                {
                    string phoneNumber = phone.Value<string>();
                    contact.Phones.Add(new Phone() { PhoneNumber = phoneNumber });
                }
            }

            var emails = contactObj["emails"];
            if (emails != null)
            {
                foreach (var email in emails)
                {
                    string emailAddress = email.Value<string>();
                    contact.Emails.Add(new Email() { EmailAddress = emailAddress });             
                }
            }

            context.Contacts.Add(contact);
            context.SaveChanges();

        }
    }
}
