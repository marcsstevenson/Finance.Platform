//MS 2017.04.12 Not sure if this will be needed but here is - surprise
//http://www.funny-cat-pictures.com/Funny-Cat-Photos/images/Cat-surprise---funny-pictures.jpg

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Finance.Logic.Applications.PersonalApplications;

//namespace Finance.Logic.Applications.PersonalApplicationForms
//{
//    public class PersonalApplicationFormSchemaHelper
//    {
//        private class SchemaVersionMapper
//        {
//            public string Version { get; set; }
//            public Func<Guid?, string, string, dynamic, PersonalApplicationFormSaveRequest> CreateSaveRequestFunc { get; set; }
//        }

//        private static readonly List<SchemaVersionMapper> KnownSchemaVersions = new List<SchemaVersionMapper>
//        {
//            new SchemaVersionMapper{Version = "1.0", CreateSaveRequestFunc = CreateSaveRequestV1}
//        };

//        private static SchemaVersionMapper GetSchemaVersionMapper(string schemaVersion)
//        {
//            return KnownSchemaVersions.FirstOrDefault(i => i.Version == schemaVersion);
//        }

//        public static bool IsKnownSchemaVersion(string schemaVersion)
//        {
//            return GetSchemaVersionMapper(schemaVersion) != null;
//        }

//        public static PersonalApplicationSaveRequest CreateSaveRequest(Guid? id, string schemaVersion, string formType, dynamic jsonData)
//        {
//            var schemaVersionMapper = GetSchemaVersionMapper(schemaVersion);

//            if (schemaVersionMapper == null) return null;

//            return schemaVersionMapper.CreateSaveRequestFunc(id, schemaVersion, formType, jsonData);
//        }

//        private static PersonalApplicationFormSaveRequest CreateSaveRequestV1(Guid? id, string schemaVersion, string formType, dynamic jsonData)
//        {
//            var saveRequest = new PersonalApplicationFormSaveRequest
//            {
//                Id = id, SchemaVersion = schemaVersion, FormType = formType, JsonData = Convert.ToString(jsonData)
//            };

//            //We may need this later...
//            //if (jsonData != null)
//            //{
//            //    if (jsonData.FormType != null)
//            //        saveRequest.FormType = Convert.ToString(jsonData.Applicant.FirstName);

//            //}

//            return saveRequest;
//        }
//    }
//}
