using System.Collections.Generic;
using System.Linq;
using System.Web.Http.ModelBinding;

namespace Finance.Api.Helpers
{
    public static class ModelStateExtensions
    {
        public static List<string> ToModelStateErrorList(this ModelStateDictionary modelState)
        {
            var errorList = new List<string>();
            var modelErrors = modelState.Values.Where(d => d.Errors.Count > 0).ToList();
            foreach (var valueError in modelErrors.ToList())
            {
                errorList.AddRange(valueError.Errors.Select(error => string.IsNullOrEmpty(error.ErrorMessage) && error.Exception != null ? error.Exception.ToString() : error.ErrorMessage));
            }

            return errorList;
        }
    }
}
