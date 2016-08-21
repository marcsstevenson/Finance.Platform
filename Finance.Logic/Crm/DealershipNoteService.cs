using System;
using System.Collections.Generic;
using System.Linq;
using Finance.Logic.Shared;
using Generic.Framework.Enumerations;
using Generic.Framework.Helpers;
using Generic.Framework.Helpers.Interfaces;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Logic.Crm
{
    public class DealershipNoteService : GenericService<DealershipNote>
    {
        public DealershipNoteService(IPersistanceFactory persistanceFactory)
            : base(persistanceFactory)
        { }

        public DealershipNoteDto Get(Guid id)
        {
            var entity = this.RepositoryDealershipNote.FirstOrDefault(i => i.Id == id);
            return entity == null ? null : new DealershipNoteDto(entity);
        }

        public List<DealershipNoteDto> GetForDealership(Guid customerId)
        {
            //var test = this.RepositoryDealershipNote.Where(i => i.Dealership.Id == customerId).ToList();

            return this.RepositoryDealershipNote.Where(i => i.Dealership.Id == customerId).ToList().Select(i => new DealershipNoteDto(i)).ToList();
        }

        public CommitResult Save(DealershipNoteDto dto)
        {
            var commitAction = CommitAction.None;
            DealershipNote entity = null;
            
            var commitResult = UnitOfWork.Commit(() =>
            {
                entity = dto.Id.HasValue
                    ? this.RepositoryDealershipNote.FirstOrDefault(i => i.Id == dto.Id)
                    : null;

                //Create a new object if needed
                if (entity == null)
                {
                    entity = dto.ToEntity();

                    //Link the Dealership - required and unalterable
                    entity.Dealership = this.RepositoryDealership.FirstOrDefault(i => i.Id == dto.DealershipId);
                }
                else
                    //Update for any changes
                    dto.UpdateEntity(entity);
                
                commitAction = RepositoryDealershipNote.Save(entity);

                //Set the track date fields on the view model
                dto.UpdateTracksTime(entity);
            });

            //Add the result to the commit actions
            commitResult.CommitActions.Add(entity, commitAction);

            return commitResult;
        }
    }
}