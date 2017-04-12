using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Finance.Logic.Interfaces;
using Finance.Logic.Shared;
using Generic.Framework.Interfaces;

namespace Finance.Logic.Applications.PersonalApplications
{
    public class PersonalApplicationSaveRequest : IGuidNullableId, IForm, IPersonalApplicationHeader
    {
        public Guid? Id { get; set; }

        public string SchemaVersion { get; set; }
        public string JsonData { get; set; }

        /// <summary>
        /// The status of the personal application
        /// </summary>
        public PersonalApplicationStatus Status { get; set; }

        public string FirstName { get; set; }
        public string PreferredName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string HomePhoneNumber { get; set; }
        public string LicenceNumberSa { get; set; }
        public string PersonalEmail { get; set; }
        public string BusinessEmail { get; set; }
    }
}
