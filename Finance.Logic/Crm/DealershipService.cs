using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Finance.Logic.Shared;
using Generic.Framework.Enumerations;
using Generic.Framework.Helpers;
using Generic.Framework.Helpers.Interfaces;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Logic.Crm
{
    public class DealershipService : GenericService<Dealership>
    {
        public DealershipService(IPersistanceFactory persistanceFactory)
            : base(persistanceFactory)
        { }

        public DealershipDto Get(Guid id)
        {
            var entity = this.RepositoryDealership.FirstOrDefault(i => i.Id == id);
            return entity == null ? null : new DealershipDto(entity);
        }

        public List<DealershipDto> GetAll()
        {
            return this.RepositoryDealership.AllList().Select(i => new DealershipDto(i)).ToList();
        }

        public CommitResult SaveDealership(DealershipDto dto)
        {
            var commitAction = CommitAction.None;
            Dealership entity = null;
            
            var commitResult = UnitOfWork.Commit(() =>
            {
                entity = dto.Id.HasValue
                    ? this.RepositoryDealership.FirstOrDefault(i => i.Id == dto.Id)
                    : null;

                //Create a new object if needed
                if (entity == null)
                    entity = dto.ToEntity();
                else
                    //Update for any changes
                    dto.UpdateEntity(entity);
                
                commitAction = RepositoryDealership.Save(entity);

                //Set the track date fields on the view model
                dto.UpdateTracksTime(entity);
            });

            //Add the result to the commit actions
            commitResult.CommitActions.Add(entity, commitAction);

            return commitResult;
        }
    }
}