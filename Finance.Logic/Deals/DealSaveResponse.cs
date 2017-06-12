using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Framework.Helpers;

namespace Finance.Logic.Deals
{
    public class DealSaveResponse
    {
        public CommitResult CommitResult { get; set; }

        public string Number { get; set; }
        public DateTime? SettlementDate { get; set; }
    }
}
