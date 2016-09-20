using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Generic.Framework.AbstractClasses;
using Generic.Framework.Enumerations;
using Generic.Framework.Interfaces;
using Generic.Framework.Interfaces.Comms;
using Generic.Framework.Interfaces.Personal;

namespace Finance.Logic.Crm
{
    public class CustomerDto : IGenericDto<Customer>, IGuidNullableId, IPerson, IEmail, IBankAccount
    {
        #region Fields

        public Guid? Id { get; set; }

        public Gender? Gender { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string DriversLicenceNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// The customer's visible reference - unique
        /// </summary>
        /// <example>CU0008798</example>
        //[Required]
        public string Number { get; set; }

        public string Email { get; set; }

        // Phone number fields
        public string PhoneNumber { get; set; }

        // Cell number fields
        public string CellNumber { get; set; }

        // Fax number fields
        public string FaxNumber { get; set; }

        public string SkypeName { get; set; }

        public string Website { get; set; }

        //Bank account details
        public string BankingCompany { get; set; }
        public string BankAccountName { get; set; }
        public string BankBranchName { get; set; }
        public string BankAccountNumber { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        #endregion

        #region IGenericDto
        static CustomerDto()
        {
            Mapper.CreateMap<CustomerDto, Customer>()
                //These properties are managed by the service
                .ForMember(x => x.Number, opt => opt.Ignore())
                .ForMember(x => x.DateCreated, opt => opt.Ignore())
                .ForMember(x => x.DateModified, opt => opt.Ignore());
            
            Mapper.CreateMap<Customer, CustomerDto>();
        }
        public CustomerDto() { }

        public CustomerDto(Customer entity)
        {
            Mapper.Map(entity, this);
        }
        
        public Customer ToEntity()
        {
            var entity = Mapper.Map<Customer>(this);
            return entity;
        }

        public void UpdateEntity(Customer entity)
        { 
            Mapper.Map(this, entity);
        }

        #endregion
    }
}
