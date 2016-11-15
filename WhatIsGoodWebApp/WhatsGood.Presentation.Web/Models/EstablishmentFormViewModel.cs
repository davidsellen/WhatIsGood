using System;
using System.Collections.Generic;
using WhatsGood.Domain.Entities;

namespace WhatsGood.Presentation.Web.Models
{
    [Serializable]
    public class EstablishmentFormViewModel
    {
        public int EstablishmentId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string WebSiteUrl { get; set; }
        public int EstablishmentTypeId { get; set; }
        public bool OwnParking { get; set; }
        public bool Accessibility { get; set; }
        public int Capacity { get; set; }
        public AddressFormViewModel Address { get; set; }
        public ContactFormViewModel Contact { get; set; }
        public ParkingFormViewModel Parking { get; set; }
        public List<FileInformationFormViewModel> Photos { get; set; }

        public static EstablishmentFormViewModel Create(Establishment establishment)
        {
            if (establishment == null) return null;

            var vm = new EstablishmentFormViewModel
            {
                EstablishmentId = establishment.Id,                
                Name= establishment.Name,
                ImageUrl = establishment.ImageUrl,
                WebSiteUrl = establishment.WebSiteUrl,
                OwnParking = establishment.OwnParking,
                Capacity=establishment.Capacity,
                Accessibility = establishment.Accessibility
            };

            if (establishment.Type != null)
            {
                vm.EstablishmentTypeId = establishment.Type.Id;
            }

            vm.Parking = ParkingFormViewModel.Create(establishment.Parking);
            vm.Address = AddressFormViewModel.Create(establishment.Address);
            vm.Contact = ContactFormViewModel.Create(establishment.Contact);
            vm.Photos = FileInformationFormViewModel.Create(establishment.Photos);
            return vm;

        }        

        internal static Establishment Create(EstablishmentFormViewModel establishmentVm)
        {

            if (establishmentVm == null) return null;

            var entity = new Establishment
            {
                Id = establishmentVm.EstablishmentId,
                Name=establishmentVm.Name,
                ImageUrl = establishmentVm.ImageUrl,
                WebSiteUrl = establishmentVm.WebSiteUrl,
                OwnParking = establishmentVm.OwnParking,
                Capacity = establishmentVm.Capacity,
                Accessibility = establishmentVm.Accessibility
            };

            if (establishmentVm.EstablishmentTypeId > 0)
            {
                entity.Type = new EstablishmentType { Id = establishmentVm.EstablishmentTypeId };
            }

            entity.Parking = ParkingFormViewModel.Create(establishmentVm.Parking);
            entity.Address = AddressFormViewModel.Create(establishmentVm.Address);
            entity.Contact = ContactFormViewModel.Create(establishmentVm.Contact);
            entity.Photos = FileInformationFormViewModel.Create(establishmentVm.Photos);
            return entity;
        }
    }

    public class ParkingFormViewModel
    {
        public int ParkingId { get; set; }
        public int Capacity { get; set; }
        public double Price { get; set; }

        public static ParkingFormViewModel Create(Parking parking)
        {
            if (parking == null) return null;
            return new ParkingFormViewModel
            {
                ParkingId=parking.Id,
                Capacity = parking.Capacity,
                Price = parking.Price
            };
        }

        public static Parking  Create(ParkingFormViewModel parkingVm)
        {
            if (parkingVm == null) return null;
            return new Parking
            {
                Id = parkingVm.ParkingId,
                Capacity = parkingVm.Capacity,
                Price = parkingVm.Price
            };
        }
    }
}