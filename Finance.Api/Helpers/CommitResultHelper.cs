using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Finance.Api.Models;
using Generic.Framework.Enumerations;
using Generic.Framework.Helpers;

namespace Finance.Api.Helpers
{
    public static class CommitResultHelper
    {
        public static HttpResponseMessage CreateUnauthorizedResponse(HttpRequestMessage request, string error)
        {
            return request.CreateResponse(HttpStatusCode.Unauthorized, new ApiPostResponse { Error = new Exception(error) });
        }

        public static HttpResponseMessage ToHttpResponseMessage(this CommitResult commitResult, HttpRequestMessage request, bool expectCommit = true)
        {
            //if (commitResult.HasError)
            //    Elmah.ErrorSignal.FromCurrentContext().Raise(commitResult.Error);

            var httpStatusCodeAndApiPostResponse = commitResult.ToHttpStatusCodeAndApiPostResponse(expectCommit);
            return request.CreateResponse(httpStatusCodeAndApiPostResponse.Item1, httpStatusCodeAndApiPostResponse.Item2);
        }

        public static Tuple<HttpStatusCode, ApiPostResponse> ToHttpStatusCodeAndApiPostResponse(this CommitResult commitResult, bool expectCommit = true)
        {
            var apiControllerResponse = new ApiPostResponse { Error = commitResult.Error };
            var httpStatusCode = HttpStatusCode.OK;

            if (commitResult.HasError)
                httpStatusCode = HttpStatusCode.InternalServerError;
            else if (commitResult.CommitActions.Any())
            {
                var first = commitResult.CommitActions.First();

                if (first.Key != null)
                {
                    apiControllerResponse.CommittedId = (first.Key).Id;
                }

                if (commitResult.CommitActions.All(i => i.Value == CommitAction.None))
                    httpStatusCode = expectCommit ? HttpStatusCode.NotAcceptable : HttpStatusCode.OK; //Return OK if we were not expecting a commit otherwise the bad news
            }
            else
                httpStatusCode = expectCommit ? HttpStatusCode.NotImplemented : HttpStatusCode.OK;

            if (commitResult.Data != null)
                apiControllerResponse.Data = commitResult.Data;

            return new Tuple<HttpStatusCode, ApiPostResponse>(httpStatusCode, apiControllerResponse);
        }

        //public static HttpResponseMessage ToBatchHttpResponseMessage(this CommitResult commitResult, HttpRequestMessage request, bool expectCommit = true)
        //{
        //    var httpStatusCodeAndApiPostResponse = commitResult.ToHttpStatusCodeAndApiBatchPostResponse(expectCommit);
        //    return request.CreateResponse(httpStatusCodeAndApiPostResponse.Item1, httpStatusCodeAndApiPostResponse.Item2);
        //}

        //public static Tuple<HttpStatusCode, ApiBatchPostResponse> ToHttpStatusCodeAndApiBatchPostResponse(this CommitResult commitResult, bool expectCommit = true)
        //{
        //    var apiControllerResponse = new ApiBatchPostResponse { Error = commitResult.Error };
        //    var httpStatusCode = HttpStatusCode.OK;

        //    if (commitResult.HasError)
        //        httpStatusCode = HttpStatusCode.InternalServerError;
        //    else if (commitResult.CommitActions.Any())
        //    {

        //        var results = commitResult.CommitActions.GroupBy(r => r.Value, r => r.Key,
        //                    (action, entities) => new KeyValuePair<string, int>(action.ToString(), entities.Count()));
        //        apiControllerResponse.ActionCounts = results.ToList();

        //        if (commitResult.CommitActions.All(i => i.Value == CommitAction.None))
        //            httpStatusCode = expectCommit ? HttpStatusCode.NotAcceptable : HttpStatusCode.OK; //Return OK if we were not expecting a commit otherwise the bad news
        //    }
        //    else
        //        httpStatusCode = HttpStatusCode.NotImplemented;

        //    return new Tuple<HttpStatusCode, ApiBatchPostResponse>(httpStatusCode, apiControllerResponse);
        //}

        public static HttpResponseMessage GetBlankOkResponseMessage(HttpRequestMessage request)
        {
            return request.CreateResponse(HttpStatusCode.OK);
        }
    }
}