using System;
using System.Collections.Generic;
using System.Linq;

namespace Finance.Logic.Applications.PersonalApplications
{
    public class PersonalApplicationSchemaHelper
    {
        private class SchemaVersionMapper
        {
            public string Version { get; set; }
            public Func<Guid?, string, dynamic, PersonalApplicationSaveRequest> CreateSaveRequestFunc { get; set; }
        }

        private static readonly List<SchemaVersionMapper> KnownSchemaVersions = new List<SchemaVersionMapper>
        {
            new SchemaVersionMapper{Version = "1.0", CreateSaveRequestFunc = CreateSaveRequestV1}
        };

        private static SchemaVersionMapper GetSchemaVersionMapper(string schemaVersion)
        {
            return KnownSchemaVersions.FirstOrDefault(i => i.Version == schemaVersion);
        }

        public static bool IsKnownSchemaVersion(string schemaVersion)
        {
            return GetSchemaVersionMapper(schemaVersion) != null;
        }

        public static PersonalApplicationSaveRequest CreateSaveRequest(Guid? id, string schemaVersion, dynamic jsonData)
        {
            var schemaVersionMapper = GetSchemaVersionMapper(schemaVersion);

            if (schemaVersionMapper == null) return null;

            return schemaVersionMapper.CreateSaveRequestFunc(id, schemaVersion, jsonData);
        }

        private static PersonalApplicationSaveRequest CreateSaveRequestV1(Guid? id, string schemaVersion, dynamic jsonData)
        {
            var saveRequest = new PersonalApplicationSaveRequest
            {
                Id = id, SchemaVersion = schemaVersion, JsonData = Convert.ToString(jsonData)
            };

            var status = PersonalApplicationStatus.CustomerQuery;

            if (jsonData.Status != null)
            {
                int statusValue;

                int.TryParse(jsonData.Status.ToString(), out statusValue);

                status = (PersonalApplicationStatus)statusValue;
            }

            saveRequest.Status = status;
            
            if (jsonData.Applicant != null)
            {
                if (jsonData.Applicant.FirstName != null)
                    saveRequest.FirstName = Convert.ToString(jsonData.Applicant.FirstName);

                if (jsonData.Applicant.PreferredName != null)
                    saveRequest.PreferredName = Convert.ToString(jsonData.Applicant.PreferredName);

                if (jsonData.Applicant.MiddleName != null)
                    saveRequest.MiddleName = Convert.ToString(jsonData.Applicant.MiddleName);

                if (jsonData.Applicant.LastName != null)
                    saveRequest.LastName = Convert.ToString(jsonData.Applicant.LastName);

                if (jsonData.Applicant.MobilePhoneNumber != null)
                    saveRequest.MobilePhoneNumber = Convert.ToString(jsonData.Applicant.MobilePhoneNumber);

                if (jsonData.Applicant.HomePhoneNumber != null)
                    saveRequest.HomePhoneNumber = Convert.ToString(jsonData.Applicant.HomePhoneNumber);

                if (jsonData.Applicant.LicenceNumberSa != null)
                    saveRequest.LicenceNumberSa = Convert.ToString(jsonData.Applicant.LicenceNumberSa);

                if (jsonData.Applicant.PersonalEmail != null)
                    saveRequest.PersonalEmail = Convert.ToString(jsonData.Applicant.PersonalEmail);

                if (jsonData.Applicant.BusinessEmail != null)
                    saveRequest.BusinessEmail = Convert.ToString(jsonData.Applicant.BusinessEmail);
            }
            
            return saveRequest;
        }
    }
}
