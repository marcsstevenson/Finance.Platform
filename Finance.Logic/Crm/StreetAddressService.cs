using System;
using System.Collections.Generic;
using System.Linq;
using Finance.Logic.Counting;
using Finance.Logic.Shared;
using Generic.Framework.Enumerations;
using Generic.Framework.Helpers;
using Generic.Framework.Helpers.Interfaces;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Logic.Crm
{
    public class StreetAddressService : GenericService<StreetAddress>
    {
        private CounterStoreService _counterStoreService;

        public CounterStoreService CounterStoreService
            => _counterStoreService ?? (_counterStoreService = new CounterStoreService(this.PersistanceFactory));

        public StreetAddressService(IPersistanceFactory persistanceFactory)
            : base(persistanceFactory)
        { }

        public StreetAddressDto Get(Guid id)
        {
            var entity = this.RepositoryStreetAddress.FirstOrDefault(i => i.Id == id);
            return entity == null ? null : new StreetAddressDto(entity);
        }

        public List<StreetAddressDto> GetAll()
        {
            return this.RepositoryStreetAddress.AllList().Select(i => new StreetAddressDto(i)).ToList();
        }

        public CommitResult Save(StreetAddressDto dto)
        {
            var commitAction = CommitAction.None;
            StreetAddress entity = null;

            var commitResult = UnitOfWork.Commit(() =>
            {
                var saveResponce = Save(this.RepositoryStreetAddress, dto);
                
                commitAction = saveResponce.Item1;
                entity = saveResponce.Item2;
            });

            //Add the result to the commit actions
            commitResult.CommitActions.Add(entity, commitAction);

            return commitResult;
        }

        public static Tuple<CommitAction, StreetAddress> Save(IEntityRepository<StreetAddress> repositoryStreetAddress, 
            StreetAddressDto dto)
        {
            if(dto == null)
                return new Tuple<CommitAction, StreetAddress>(CommitAction.None, null);

            var entity = dto.Id.HasValue
                ? repositoryStreetAddress.FirstOrDefault(i => i.Id == dto.Id)
                : null;

            //Create a new object if needed
            if (entity == null)
                entity = dto.ToEntity();
            else
                //Update for any changes
                dto.UpdateEntity(entity);

            var commitAction = repositoryStreetAddress.Save(entity);

            //Set the track date fields on the view model
            dto.UpdateTracksTime(entity);

            return new Tuple<CommitAction, StreetAddress>(commitAction, entity);
        }
    }
}