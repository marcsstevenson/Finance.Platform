using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Generic.Framework.AbstractClasses;
using Generic.Framework.Interfaces;
using Generic.Framework.Interfaces.Comms;

namespace Finance.Logic.Crm
{
    public class DealershipDto : IGenericDto<Dealership>, IGuidNullableId, IName
    {
        public Guid? Id { get; set; }

        [Required]
        public bool IsEnabled { get; set; } = true;

        [Required]
        public string Name { get; set; }
        
        /// <summary>
        /// The name of the main contact at this dealership
        /// </summary>
        public string ContactName { get; set; }

        public string Website { get; set; }
        public string Email { get; set; }

        // Phone number fields
        public string PhoneCountry { get; set; }
        public string PhoneArea { get; set; }
        public string PhoneNumber { get; set; }

        // Cell number fields
        public string CellCountry { get; set; }
        public string CellArea { get; set; }
        public string CellNumber { get; set; }

        // Fax number fields
        public string FaxCountry { get; set; }
        public string FaxArea { get; set; }
        public string FaxNumber { get; set; }

        //Bank account details
        public string BankingCompany { get; set; }
        public string BankAccountName { get; set; }
        public string BankBranchName { get; set; }
        public string BankAccountNumber { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        #region IGenericDto
        static DealershipDto()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<DealershipDto, Dealership>()
                //These properties are managed by the repository;
                .ForMember(x => x.DateCreated, opt => opt.Ignore())
                .ForMember(x => x.DateModified, opt => opt.Ignore())
                );

            Mapper.CreateMap<Dealership, DealershipDto>();
        }
        public DealershipDto() { }

        public DealershipDto(Dealership entity)
        {
            Mapper.Map(entity, this);
        }

        //public void Populate(Dealership entity)

        //}

        public Dealership ToEntity()
        {
            var entity = Mapper.Map<Dealership>(this);
            return entity;
        }

        public void UpdateEntity(Dealership entity)
        {
            Mapper.Map(this, entity);
        }

        #endregion
    }
}
