using System;
using Finance.Logic.Shared.Enums;
using Finance.Logic.Shared.Interfaces;
using Generic.Framework.AbstractClasses;
using Generic.Framework.Enumerations;
using Generic.Framework.Interfaces.Comms;
using Generic.Framework.Interfaces.Personal;

namespace Finance.Logic.Shared
{
    public class PersonalEntity : Entity, IPerson, IDiversLicenceDetails, ICell, IPhone, IFax, ICellBusiness, IPhoneBusiness, IFaxBusiness, IOccupationalDetails
    {
        public string FirstName { get; set; }

        public string MiddleNames { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender? Gender { get; set; }

        public MaritalStatusOption MaritalStatus { get; set; }

        public string OriginCountry { get; set; }
        
        public DiversLicenceOption DiversLicenceStatus { get; set; }

        public string OverseasDiversLicence { get; set; }

        public string LicenceNumberSa { get; set; }

        public string LicenceNumberSb { get; set; }
        
        public string CellNumber { get; set; }
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
    }
}