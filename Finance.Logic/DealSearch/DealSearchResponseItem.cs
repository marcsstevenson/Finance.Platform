
using System;
using Finance.Logic.Crm;
using Finance.Logic.Deals;
using Generic.Framework.Helpers;


namespace Finance.Logic.DealSearch
{
    public class DealSearchResponseItem
    {
        public Guid Id { get; set; }

        public string Number { get; set; }

        public DealStatus DealStatus { get; set; }

        public string DealStatusDescription
        {
            get { return this.DealStatus.GetDescription(); }
            set
            {
                //This is only here to make serialisaiton happy
            }
        }

        public string CustomerName { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
