
using System;
using Finance.Logic.Crm;
using Finance.Logic.Deals;


namespace Finance.Logic.DealSearch
{
    public class DealSearchResponseItem
    {
        public Guid Id { get; set; }

        public string Number { get; set; }

        public DealStatus DealStatus { get; set; }

        public Customer Customer { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
