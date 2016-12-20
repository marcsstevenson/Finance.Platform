using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Generic.Framework.AbstractClasses;
using Generic.Framework.Interfaces;
using Generic.Framework.Interfaces.Comms;

namespace Finance.Logic.Crm
{
    public class CustomerStreetAddressDto : IGenericDto<CustomerStreetAddress>, IGuidNullableId, IName
    {
        public Guid? Id { get; set; }
        
        public Guid CustomerId { get; set; }
        
        public string Region { get; set; }
        public string Name { get; set; }
        //public string ContactPhoneNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public bool IsDefault { get; set; }
        public string Type { get; set; }
        public string OtherInformation { get; set; }

        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        #region IGenericDto
        static CustomerStreetAddressDto()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<CustomerStreetAddressDto, CustomerStreetAddress>()
                //These properties are managed by the repository;
                .ForMember(x => x.DateCreated, opt => opt.Ignore())
                .ForMember(x => x.DateModified, opt => opt.Ignore())
                );

            Mapper.Initialize(cfg => cfg.CreateMap<CustomerStreetAddress, CustomerStreetAddressDto>());
        }
        public CustomerStreetAddressDto() { }

        public CustomerStreetAddressDto(CustomerStreetAddress entity)
        {
            Mapper.Map(entity, this);
        }

        //public void Populate(CustomerStreetAddress entity)

        //}

        public CustomerStreetAddress ToEntity()
        {
            var entity = Mapper.Map<CustomerStreetAddress>(this);
            return entity;
        }

        public void UpdateEntity(CustomerStreetAddress entity)
        {
            Mapper.Map(this, entity);
        }

        #endregion
    }
}
