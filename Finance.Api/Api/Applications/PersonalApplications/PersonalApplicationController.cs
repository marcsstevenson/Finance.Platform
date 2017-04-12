using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Web.Http;
using Finance.Api.Api.@base;
using Finance.Api.Helpers;
using Finance.Logic.Applications.PersonalApplications;
using Generic.Framework.Interfaces.Entity;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;

namespace Finance.Api.Api.Applications.PersonalApplications
{
    [Route("api/PersonalApplication")]
    public class PersonalApplicationController : BaseController
    {
        public PersonalApplicationController()
        {
        }

        public PersonalApplicationController(IPersistanceFactory persistanceFactory) : base(persistanceFactory)
        {
        }

        [HttpGet]
        public PersonalApplicationDetails Get(Guid id)
        {
            return this.PersonalApplicationService.GetPersonalApplicationDetails(id);
        }

        [HttpPost]
        public HttpResponseMessage Save(dynamic jsonData)
        {
            if (jsonData == null) return Request.NullParameterResponse();

            string idString = jsonData.Id == null ? null : Convert.ToString(jsonData.Id);
            
            var schemaVersion = Convert.ToString(jsonData.SchemaVersion);
            
            if (!PersonalApplicationSchemaHelper.IsKnownSchemaVersion(schemaVersion))
                return Request.NullParameterResponse();

            Guid? id = null;
            if(idString != null && !idString.IsNullOrWhiteSpace())
                id = Guid.Parse(idString);

            PersonalApplicationSaveRequest saveRequest = PersonalApplicationSchemaHelper.CreateSaveRequest(id, schemaVersion, jsonData);

            var commitResult = this.PersonalApplicationService.Save(saveRequest);
            return commitResult.ToHttpResponseMessage(this.Request);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(Guid id)
        {
            var commitResult = this.PersonalApplicationService.Delete(id);
            return commitResult.ToHttpResponseMessage(this.Request);
        }
    }
}