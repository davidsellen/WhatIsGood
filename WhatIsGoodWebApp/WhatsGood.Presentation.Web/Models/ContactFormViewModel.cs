using System;
using WhatsGood.Domain.Entities;

namespace WhatsGood.Presentation.Web.Models
{
    public class ContactFormViewModel
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? BirthDate { get; set; }

        public static ContactFormViewModel Create(Contact contact)
        {
            if (contact == null) return null;
            var vm = new ContactFormViewModel
            {
                ContactId = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                EmailAddress = contact.EmailAddress,
                PhoneNumber = contact.PhoneNumber,
                BirthDate = contact.BirthDate
            };

            return vm;
        }

        public static Contact Create(ContactFormViewModel contactFormViewModel)
        {
            if (contactFormViewModel == null) return null;
            return new Contact
            {
                Id = contactFormViewModel.ContactId,
                FirstName = contactFormViewModel.FirstName,
                LastName = contactFormViewModel.LastName,
                EmailAddress = contactFormViewModel.EmailAddress,
                PhoneNumber = contactFormViewModel.PhoneNumber,
                BirthDate = contactFormViewModel.BirthDate
            };

        }
    }
}