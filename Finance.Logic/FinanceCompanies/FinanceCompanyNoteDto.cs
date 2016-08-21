using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Generic.Framework.Interfaces;

namespace Finance.Logic.FinanceCompanies
{
    public class FinanceCompanyNoteDto : IGenericDto<FinanceCompanyNote>, IGuidNullableId
    {
        #region Fields

        public Guid? Id { get; set; }

        [Required]
        public string Note { get; set; }

        [Required]
        public Guid FinanceCompanyId { get; set; }
        
        public string EnteredBy { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        #endregion

        #region IGenericDto
        static FinanceCompanyNoteDto()
        {
            Mapper.CreateMap<FinanceCompanyNoteDto, FinanceCompanyNote>()
                .ForMember(x => x.DateCreated, opt => opt.Ignore())
                .ForMember(x => x.DateModified, opt => opt.Ignore());
            
            Mapper.CreateMap<FinanceCompanyNote, FinanceCompanyNoteDto>();
        }
        public FinanceCompanyNoteDto() { }

        public FinanceCompanyNoteDto(FinanceCompanyNote entity)
        {
            Mapper.Map(entity, this);
        }
        
        public FinanceCompanyNote ToEntity()
        {
            var entity = Mapper.Map<FinanceCompanyNote>(this);
            return entity;
        }

        public void UpdateEntity(FinanceCompanyNote entity)
        { 
            Mapper.Map(this, entity);
        }

        #endregion
    }
}
