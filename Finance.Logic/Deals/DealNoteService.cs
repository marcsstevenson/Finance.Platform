using System;
using System.Collections.Generic;
using System.Linq;
using Finance.Logic.Shared;
using Generic.Framework.Enumerations;
using Generic.Framework.Helpers;
using Generic.Framework.Helpers.Interfaces;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Logic.Deals
{
    public class DealNoteService : GenericService<DealNote>
    {
        public DealNoteService(IPersistanceFactory persistanceFactory)
            : base(persistanceFactory)
        { }

        public DealNoteDto Get(Guid id)
        {
            var entity = this.RepositoryDealNote.FirstOrDefault(i => i.Id == id);
            return entity == null ? null : new DealNoteDto(entity);
        }

        public List<DealNoteDto> GetForDeal(Guid dealId)
        {
            //var test = this.RepositoryDealNote.Where(i => i.Deal.Id == customerId).ToList();

            return this.RepositoryDealNote.Where(i => i.Deal.Id == dealId).ToList().Select(i => new DealNoteDto(i)).ToList();
        }

        public CommitResult Save(DealNoteDto dto)
        {
            var commitAction = CommitAction.None;
            DealNote entity = null;
            
            var commitResult = UnitOfWork.Commit(() =>
            {
                entity = dto.Id.HasValue
                    ? this.RepositoryDealNote.FirstOrDefault(i => i.Id == dto.Id)
                    : null;

                //Create a new object if needed
                if (entity == null)
                {
                    entity = dto.ToEntity();

                    //Link the Deal - required and unalterable
                    entity.Deal = this.RepositoryDeal.FirstOrDefault(i => i.Id == dto.DealId);
                }
                else
                    //Update for any changes
                    dto.UpdateEntity(entity);
                
                commitAction = RepositoryDealNote.Save(entity);

                //Set the track date fields on the view model
                dto.UpdateTracksTime(entity);
            });

            //Add the result to the commit actions
            commitResult.CommitActions.Add(entity, commitAction);

            return commitResult;
        }
    }
}