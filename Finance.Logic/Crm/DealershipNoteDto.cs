using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Generic.Framework.Interfaces;

namespace Finance.Logic.Crm
{
    public class DealershipNoteDto : IGenericDto<DealershipNote>, IGuidNullableId
    {
        #region Fields

        public Guid? Id { get; set; }

        [Required]
        public string Note { get; set; }

        [Required]
        public Guid DealershipId { get; set; }
        
        public string EnteredBy { get; set; }

        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        #endregion

        #region IGenericDto
        static DealershipNoteDto()
        {
            Mapper.CreateMap<DealershipNoteDto, DealershipNote>()
                .ForMember(x => x.DateCreated, opt => opt.Ignore())
                .ForMember(x => x.DateModified, opt => opt.Ignore());
            
            Mapper.CreateMap<DealershipNote, DealershipNoteDto>();
        }
        public DealershipNoteDto() { }

        public DealershipNoteDto(DealershipNote entity)
        {
            Mapper.Map(entity, this);
        }
        
        public DealershipNote ToEntity()
        {
            var entity = Mapper.Map<DealershipNote>(this);
            return entity;
        }

        public void UpdateEntity(DealershipNote entity)
        { 
            Mapper.Map(this, entity);
        }

        #endregion
    }
}
