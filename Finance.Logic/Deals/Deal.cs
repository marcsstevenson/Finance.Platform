using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Finance.Logic.Crm;
using Finance.Logic.FinanceCompanies;
using Finance.Logic.Internal;
using Generic.Framework.AbstractClasses;

namespace Finance.Logic.Deals
{
    public class Deal : Entity
    {
        /// <summary>
        /// A customer is the person who finances a vehicle
        /// </summary>
        [Required]
        public Customer Customer { get; set; }

        /// <summary>
        /// The number for a given time period (month)
        /// </summary>
        [Required]
        public string Number { get; set; }

        /// <summary>
        /// TODO: What is this
        /// </summary>
        [Required]
        public int LoanNumber { get; set; }

        /// <summary>
        /// The staff memeber who is assigned to this deal
        /// </summary>
        public StaffMember AssignedTo { get; set; }

        [Required]
        public DealStatus DealStatus { get; set; }

        /// <summary>
        /// The company that is providing finance for this deal
        /// </summary>
        public FinanceCompany FinanceCompany { get; set; }

        /// <summary>
        /// The dealership that was the source of this deal
        /// </summary>
        /// <remarks>Can be null which would indicate a direct customer sale</remarks>
        public Dealership Source { get; set; }

        /// <summary>
        /// What is being used as security for the deal.
        /// </summary>
        /// <example>02 Audi A3</example>
        /// <example>Refinance</example>
        public string SecurityDescription { get; set; }

        public int TermInMonths { get; set; }

        /// <summary>
        /// The percentage rate of the finance
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// The dollar amount of the deal?
        /// </summary>
        public decimal FinanceVolume { get; set; }

        public decimal Commission { get; set; }

        public decimal DocumentationFee { get; set; }

        /// <summary>
        /// This is a Payment Protection Insurance or Credit Contract Indemnity Insurance for job loss etc
        /// </summary>
        public decimal PaymentProtectionInsurance { get; set; }

        /// <summary>
        /// Insurance against any Loss or Shortfall in the case of where a vehicle is written off or stolen and the amount still owing is greater than the insurance settlement or what the vehicle is assessed to be worth.
        /// </summary>
        public decimal GuaranteedAssetProtection { get; set; }

        /// <summary>
        /// A Mechanical Warranty to insure against any mechanical issues
        /// </summary>
        public decimal MechanicalBreakDownInsurance { get; set; }

        public decimal Insurance { get; set; }

        public decimal Other { get; set; }

        public string OtherNote { get; set; }

        public decimal DealershipCommission { get; set; }

        public decimal DealershipClawbackNotes { get; set; }

        /// <summary>
        /// The date that the deal was set to a settled status
        /// </summary>
        public DateTime? SettlementDate { get; set; }

        #region 1:M Relationships

        public IList<DealNote> DealNotes { get; set; }

        #endregion
    }
}
