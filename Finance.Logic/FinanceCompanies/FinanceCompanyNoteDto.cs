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

        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        #endregion

        #region IGenericDto
        private static void Map()
        {
            Mapper.CreateMap<FinanceCompanyNoteDto, FinanceCompanyNote>()
                .ForMember(x => x.DateCreated, opt => opt.Ignore())
                .ForMember(x => x.DateModified, opt => opt.Ignore());
            
            Mapper.CreateMap<FinanceCompanyNote, FinanceCompanyNoteDto>();
        }
        public FinanceCompanyNoteDto() { }

        public FinanceCompanyNoteDto(FinanceCompanyNote entity)
        {
            Map();
            Mapper.Map(entity, this);
        }
        
        public FinanceCompanyNote ToEntity()
        {
            Map();
            var entity = Mapper.Map<FinanceCompanyNote>(this);
            return entity;
        }

        public void UpdateEntity(FinanceCompanyNote entity)
        { 
            Map();
            Mapper.Map(this, entity);
        }

        #endregion
    }
}
