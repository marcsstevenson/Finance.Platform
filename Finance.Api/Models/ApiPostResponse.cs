using System;
using System.Collections.Generic;
using System.Web.Http.ModelBinding;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finance.Api.Helpers;
using Generic.Framework.AbstractClasses;

namespace Finance.Api.Models
{

    public class ApiPostResponse : GenericResult
    {
        public Guid CommittedId { get; set; }
        public List<string> ModelStateErrors { get; set; }
        public Dictionary<string, object> Data { get; set; }

        public ApiPostResponse()
        {
            this.Data = new Dictionary<string, object>();
        }

        public ApiPostResponse(ModelStateDictionary modelStateDictionary) : this()
        {
            ModelStateErrors = modelStateDictionary.ToModelStateErrorList();
        }

    }
}
