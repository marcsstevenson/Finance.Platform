using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Generic.Framework.Interfaces;

namespace Finance.Logic.Deals
{
    public class DealDto : IGenericDto<Deal>, IGuidNullableId
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// A customer is the person who finances a vehicle
        /// </summary>
        [Required]
        public Guid CustomerId { get; set; }

        /// <summary>
        /// The number for a given time period (month)
        /// </summary>
        //[Required]
        public string Number { get; set; }

        /// <summary>
        /// TODO: What is this
        /// </summary>
        [Required]
        public int CashManagerReference { get; set; }

        /// <summary>
        /// The staff memeber who is assigned to this deal
        /// </summary>
        public Guid? AssignedToId { get; set; }

        [Required]
        public DealStatus DealStatus { get; set; }

        /// <summary>
        /// The company that is providing finance for this deal
        /// </summary>
        public Guid? FinanceCompanyId { get; set; }

        /// <summary>
        /// The dealership that was the source of this deal
        /// </summary>
        /// <remarks>Can be null which would indicate a direct customer sale</remarks>
        public Guid? SourceDealershipId { get; set; }

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

        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        #region IGenericDto
        private static void Map()
        {

            Mapper.CreateMap<DealDto, Deal>()
                //These properties are managed by the service
                .ForMember(x => x.Number, opt => opt.Ignore())
                .ForMember(x => x.DateCreated, opt => opt.Ignore())
                .ForMember(x => x.DateModified, opt => opt.Ignore());

            Mapper.CreateMap<Deal, DealDto>();
        }
        public DealDto() { }

        public DealDto(Deal entity)
        {
            Map();
            Mapper.Map(entity, this);
        }

        //public void Populate(Deal entity)

        //}

        public Deal ToEntity()
        {
            Map();
            var entity = Mapper.Map<Deal>(this);
            return entity;
        }

        public void UpdateEntity(Deal entity)
        {
            Map();
            Mapper.Map(this, entity);
        }

        public static Func<Deal, DealDto> GetentityToDtoFunc()
        {
            Func<Deal, DealDto> func = i => new DealDto
            {
                Id = i.Id,
                CustomerId = i.Customer.Id,
                Number = i.Number,
                CashManagerReference = i.CashManagerReference,
                AssignedToId = i.AssignedTo == null ? null : (Guid?)i.AssignedTo.Id,
                DealStatus = i.DealStatus,
                FinanceCompanyId = i.FinanceCompany == null ? null : (Guid?)i.FinanceCompany.Id,
                SourceDealershipId = i.Source == null ? null : (Guid?)i.Source.Id,
                SecurityDescription = i.SecurityDescription,
                TermInMonths = i.TermInMonths,
                Rate = i.Rate,
                FinanceVolume = i.FinanceVolume,
                Commission = i.Commission,
                DocumentationFee = i.DocumentationFee,
                PaymentProtectionInsurance = i.PaymentProtectionInsurance,
                GuaranteedAssetProtection = i.GuaranteedAssetProtection,
                MechanicalBreakDownInsurance = i.MechanicalBreakDownInsurance,
                Insurance = i.Insurance,
                Other = i.Other,
                OtherNote = i.OtherNote,
                DealershipCommission = i.DealershipCommission,
                DealershipClawbackNotes = i.DealershipClawbackNotes,
                DateCreated = i.DateCreated,
                DateModified = i.DateModified
            };

            return func;
        }
        #endregion
    }
}
