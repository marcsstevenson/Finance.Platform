using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Finance.Logic.Crm;
using Finance.Logic.Shared.Enums;
using Finance.Logic.Shared.Interfaces;
using Generic.Framework.Enumerations;
using Generic.Framework.Interfaces;
using Generic.Framework.Interfaces.Comms;
using Generic.Framework.Interfaces.Personal;

namespace Finance.Logic.Shared
{
    public class PersonalEntityDto : Generic.Framework.Interfaces.IGenericDto<PersonalEntity>, IGuidNullableId
        , IPerson, IDiversLicenceDetails, ICell, IPhone, IFax, ICellBusiness, IPhoneBusiness, IFaxBusiness, IOccupationalDetails
    {
        #region Fields

        public Guid? Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleNames { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public Gender? Gender { get; set; }

        public MaritalStatusOption MaritalStatus { get; set; }

        public string OriginCountry { get; set; }

        public DiversLicenceOption DiversLicenceStatus { get; set; }

        public string OverseasDiversLicence { get; set; }

        public string LicenceNumberSa { get; set; }

        public string LicenceNumberSb { get; set; }

        public string MobileNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string CellNumberBusiness { get; set; }
        public string PhoneNumberBusiness { get; set; }
        public string FaxNumberBusiness { get; set; }

        public string OccupationEmployer { get; set; }
        public string Occupation { get; set; }
        public string OccupationAddressStreet { get; set; }
        public string OccupationAddressSuburb { get; set; }
        public string OccupationAddressPostcode { get; set; }
        public string OccupationAddressCity { get; set; }
        public int? OccupationDurationInMonths { get; set; }

        public string PreviousEmployer { get; set; }
        public string PreviousOccupation { get; set; }
        public int? PreviousOccupationDurationInMonths { get; set; }
        
        public StreetAddressDto CurrentAddress { get; set; }

        public AddressArrangement CurrentAddressArrangement { get; set; }

        public string CurrentAddressArrangementOther { get; set; }

        public StreetAddressDto PreviousAddress { get; set; }

        public string NearestRelativeName { get; set; }

        public string NearestRelativeRelationship { get; set; }

        public string NearestRelativePhoneNumber { get; set; }

        public StreetAddressDto NearestRelativeAddress { get; set; }
        
        public string Reference1Name { get; set; }
        
        public string Reference2Name { get; set; }
        
        public string Bankers { get; set; }

        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        #endregion

        #region IGenericDto
        static PersonalEntityDto()
        {
            Mapper.CreateMap<PersonalEntityDto, PersonalEntity>()
                //These properties are managed by the service
                .ForMember(x => x.DateCreated, opt => opt.Ignore())
                .ForMember(x => x.DateModified, opt => opt.Ignore());

            Mapper.CreateMap<PersonalEntity, PersonalEntityDto>();
        }
        public PersonalEntityDto() { }

        public PersonalEntityDto(PersonalEntity entity)
        {
            Mapper.Map(entity, this);
        }

        public PersonalEntity ToEntity()
        {
            var entity = Mapper.Map<PersonalEntity>(this);
            return entity;
        }

        public void UpdateEntity(PersonalEntity entity)
        {
            Mapper.Map(this, entity);
        }

        #endregion
    }
}
