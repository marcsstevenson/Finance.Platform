using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http.ModelBinding;
using Finance.Api.Models;

namespace Finance.Api.Helpers
{
    public static class ResultHelper
    {
        public static HttpResponseMessage NullParameterResponse(this HttpRequestMessage request)
        {
            var apiControllerResponse = new ApiPostResponse
            {
                ModelStateErrors = new List<string> { "A null parameter was supplied" }
            };

            return request.CreateResponse(HttpStatusCode.NotAcceptable, apiControllerResponse);
        }

        public static HttpResponseMessage InvalidModelStateResponse(this HttpRequestMessage request, ModelStateDictionary modelStateDictionary)
        {
            var apiControllerResponse = new ApiPostResponse(modelStateDictionary);
            return request.CreateResponse(HttpStatusCode.NotAcceptable, apiControllerResponse);
        }
    }
}
