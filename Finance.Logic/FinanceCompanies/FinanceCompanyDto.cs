using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Generic.Framework.Interfaces;

namespace Finance.Logic.FinanceCompanies
{
    public class FinanceCompanyDto : IGenericDto<FinanceCompany>, IGuidNullableId, IName
    {
        public Guid? Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        #region IGenericDto
        static FinanceCompanyDto()
        {
            Mapper.CreateMap<FinanceCompanyDto, FinanceCompany>()
                //These properties are managed by the repository;
                .ForMember(x => x.DateCreated, opt => opt.Ignore())
                .ForMember(x => x.DateModified, opt => opt.Ignore());

            Mapper.CreateMap<FinanceCompany, FinanceCompanyDto>();
        }
        public FinanceCompanyDto() { }

        public FinanceCompanyDto(FinanceCompany entity)
        {
            Mapper.Map(entity, this);
        }
        
        public FinanceCompany ToEntity()
        {
            var entity = Mapper.Map<FinanceCompany>(this);
            return entity;
        }

        public void UpdateEntity(FinanceCompany entity)
        {
            Mapper.Map(this, entity);
        }

        #endregion
    }
}
