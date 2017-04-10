using System;
using Finance.Logic.Crm;
using Finance.Logic.Shared.Enums;
using Finance.Logic.Shared.Interfaces;
using Generic.Framework.AbstractClasses;
using Generic.Framework.Enumerations;
using Generic.Framework.Interfaces.Comms;
using Generic.Framework.Interfaces.Personal;

namespace Finance.Logic.Shared
{
    public class PersonalEntity : Entity, IPerson, IDiversLicenceDetails, ICell, IPhone, IFax, IOccupationalDetails
    {
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

        public StreetAddress CurrentAddress { get; set; }

        public AddressArrangement CurrentAddressArrangement { get; set; }

        /// <summary>
        /// If CurrentAddressArrangement == other then we need an other reason
        /// </summary>
        public string CurrentAddressArrangementOther { get; set; }

        public StreetAddress PreviousAddress { get; set; }

        public string NearestRelativeName { get; set; }

        public string NearestRelativeRelationship { get; set; }

        public string NearestRelativePhoneNumber { get; set; }

        public StreetAddress NearestRelativeAddress { get; set; }
        
        /// MS 2017.03.26: Make this a list of reference objects
        
        /// <summary>
        /// MS 2016.09.18: A simple name of a person acting as a referee?
        /// </summary>
        public string Reference1Name { get; set; }

        /// <summary>
        /// MS 2016.09.18: A simple name of a person acting as a referee?
        /// </summary>
        public string Reference2Name { get; set; }

        /// <summary>
        /// MS 2016.09.18: I have no idea what this is
        /// </summary>
        public string Bankers { get; set; }
    }
}