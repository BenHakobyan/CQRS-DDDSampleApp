﻿using SampleApp.Domain.Rules.Contact;
using System.ComponentModel.DataAnnotations;

namespace SampleApp.Domain.Entities
{
    public class Contact : BaseEntity
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Address { get; private set; }


        public static Contact Create(string fullName, string email, string phoneNumber, string address, IContactsContext contactsContext)
        {
            var contact = new Contact()
            {
                FullName = fullName,
                Email = email,
                PhoneNumber = phoneNumber,
                Address = address
            };

            CheckRule(new ContactModelValidationRule(contact));
            CheckRule(new ContactMustBeUniqueRule(contactsContext, contact));

            return contact;
        }

        public void Edit(string fullName, string email, string phoneNumber, string address, IContactsContext contactsContext)
        {
            this.FullName = fullName;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.Address = address;

            CheckRule(new ContactModelValidationRule(this));
            CheckRule(new ContactMustBeUniqueRule(contactsContext, this));
        }


        //method for seed Contacts
        public static Contact[] SeedContacts()
        {
            return new Contact[]
            {
                new Contact(){Id = 1, FullName = "John Smith", Email = "jsmith@mail.com", PhoneNumber= "123456", Address = "London, UK" },
                new Contact(){Id = 2, FullName = "Walter White", Email =  "wwhite@gmail.com", PhoneNumber = "654321", Address = "Albuquerque, New Mexico, USA" }
            };
        }
    }
}
