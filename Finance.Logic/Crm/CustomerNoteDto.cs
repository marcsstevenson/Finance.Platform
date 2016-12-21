using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Generic.Framework.Interfaces;

namespace Finance.Logic.Crm
{
    public class CustomerNoteDto : IGenericDto<CustomerNote>, IGuidNullableId
    {
        #region Fields

        public Guid? Id { get; set; }

        [Required]
        public string Note { get; set; }

        [Required]
        public Guid CustomerId { get; set; }
        
        public string EnteredBy { get; set; }

        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        #endregion

        #region IGenericDto
        private static void Map()
        {
            Mapper.CreateMap<CustomerNoteDto, CustomerNote>()
                .ForMember(x => x.DateCreated, opt => opt.Ignore())
                .ForMember(x => x.DateModified, opt => opt.Ignore());
            
            Mapper.CreateMap<CustomerNote, CustomerNoteDto>();
        }
        public CustomerNoteDto() { }

        public CustomerNoteDto(CustomerNote entity)
        {
            Map();
            Mapper.Map(entity, this);
        }
        
        public CustomerNote ToEntity()
        {
            Map();
            var entity = Mapper.Map<CustomerNote>(this);
            return entity;
        }

        public void UpdateEntity(CustomerNote entity)
        {
            Map();
            Mapper.Map(this, entity);
        }

        #endregion
    }
}
