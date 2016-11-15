using WhatsGood.Domain.Entities;

namespace WhatsGood.Presentation.Web.Models
{
    public class AddressFormViewModel
    {
        public int AddressId { get; set; }
        public string StreetName { get; set; }
        public string Complement { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public static AddressFormViewModel Create(Address address)
        {

            if (address == null) return null;

            var vm = new AddressFormViewModel
            {
                AddressId = address.Id,
                StreetName = address.StreetName,
                Complement = address.Complement,
                Number = address.Number,
                District = address.District,
                PostalCode = address.PostalCode,
                City = address.City,
                Province = address.Province,
                Country = address.Country
            };

            if (address.GeoPosition != null)
            {
                vm.Latitude = address.GeoPosition.Latitude;
                vm.Longitude = address.GeoPosition.Longitude;
            }

            return vm;
        }

        public static Address Create(AddressFormViewModel addressFormViewModel)
        {
            if (addressFormViewModel == null) return null;

            var address = new Address
            {
                Id = addressFormViewModel.AddressId,
                StreetName = addressFormViewModel.StreetName,
                Complement = addressFormViewModel.Complement,
                Number = addressFormViewModel.Number,
                District = addressFormViewModel.District,
                PostalCode = addressFormViewModel.PostalCode,
                City = addressFormViewModel.City,
                Province = addressFormViewModel.Province,
                Country = addressFormViewModel.Country,
                GeoPosition = new GeoPosition(addressFormViewModel.Latitude, addressFormViewModel.Longitude)
            };

            return address;
        }
    }
}