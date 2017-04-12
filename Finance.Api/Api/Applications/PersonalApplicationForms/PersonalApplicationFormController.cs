using System;
using System.Net.Http;
using System.Web.Http;
using Finance.Api.Api.@base;
using Finance.Api.Helpers;
using Finance.Logic.Applications.PersonalApplicationForms;
using Generic.Framework.Interfaces.Entity;
using Microsoft.Ajax.Utilities;

namespace Finance.Api.Api.Applications.PersonalApplicationForms
{
    [Route("api/PersonalApplicationForm")]
    public class PersonalApplicationFormController : BaseController
    {
        public PersonalApplicationFormController()
        {
        }

        public PersonalApplicationFormController(IPersistanceFactory persistanceFactory) : base(persistanceFactory)
        {
        }

        [HttpGet]
        public dynamic Get(Guid id)
        {
            return this.PersonalApplicationFormService.GetJsonData(id);
        }

        [HttpPost]
        public HttpResponseMessage Save(PersonalApplicationFormPost applicationFormPost)
        {
            if (applicationFormPost == null) return Request.NullParameterResponse();

            if (!ModelState.IsValid)
                return Request.InvalidModelStateResponse(ModelState);
            
            PersonalApplicationFormSaveRequest saveRequest = new PersonalApplicationFormSaveRequest
            {
                JsonData = Convert.ToString(applicationFormPost.Form),
                FormType = applicationFormPost.FormType,
                Id = applicationFormPost.Id,
                PersonalApplicationId = applicationFormPost.PersonalApplicationId,
                SchemaVersion = applicationFormPost.SchemaVersion
            };

            var commitResult = this.PersonalApplicationFormService.Save(saveRequest);
            return commitResult.ToHttpResponseMessage(this.Request);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(Guid id)
        {
            var commitResult = this.PersonalApplicationFormService.Delete(id);
            return commitResult.ToHttpResponseMessage(this.Request);
        }
    }
}