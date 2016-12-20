using System;
using AutoMapper;
using Generic.Framework.Interfaces;

namespace Finance.Logic.Crm
{
    public class StreetAddressDto : IGenericDto<StreetAddress>, IGuidNullableId
    {
        public Guid? Id { get; set; }
        
        public string Region { get; set; }

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
        static StreetAddressDto()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<StreetAddressDto, StreetAddress>()
                //These properties are managed by the repository;
                .ForMember(x => x.DateCreated, opt => opt.Ignore())
                .ForMember(x => x.DateModified, opt => opt.Ignore())
                );

            Mapper.Initialize(cfg => cfg.CreateMap<StreetAddress, StreetAddressDto>());
        }
        public StreetAddressDto() { }

        public StreetAddressDto(StreetAddress entity)
        {
            Mapper.Map(entity, this);
        }

        //public void Populate(StreetAddress entity)

        //}

        public StreetAddress ToEntity()
        {
            var entity = Mapper.Map<StreetAddress>(this);
            return entity;
        }

        public void UpdateEntity(StreetAddress entity)
        {
            Mapper.Map(this, entity);
        }

        #endregion
    }
}
