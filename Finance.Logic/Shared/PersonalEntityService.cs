using System;
using System.Collections.Generic;
using System.Linq;
using Finance.Logic.Counting;
using Finance.Logic.Crm;
using Finance.Logic.Helpers;
using Generic.Framework.Enumerations;
using Generic.Framework.Helpers;
using Generic.Framework.Helpers.Interfaces;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Logic.Shared
{
    public class PersonalEntityService : GenericService<PersonalEntity>
    {
        private CounterStoreService _counterStoreService;

        public CounterStoreService CounterStoreService
            => _counterStoreService ?? (_counterStoreService = new CounterStoreService(this.PersistanceFactory));

        public PersonalEntityService(IPersistanceFactory persistanceFactory)
            : base(persistanceFactory)
        { }

        public PersonalEntityDto Get(Guid id)
        {
            var entity = this.RepositoryPersonalEntity.FirstOrDefault(i => i.Id == id);
            return entity == null ? null : new PersonalEntityDto(entity);
        }

        public List<PersonalEntityDto> GetAll()
        {
            return this.RepositoryPersonalEntity.AllList().Select(i => new PersonalEntityDto(i)).ToList();
        }

        public CommitResult Save(PersonalEntityDto dto)
        {
            var commitAction = CommitAction.None;
            PersonalEntity entity = null;

            var commitResult = UnitOfWork.Commit(() =>
            {
                var saveResponce = Save(this.RepositoryPersonalEntity, this.RepositoryStreetAddress, dto);
                
                commitAction = saveResponce.Item1;
                entity = saveResponce.Item2;
            });

            //Add the result to the commit actions
            commitResult.CommitActions.Add(entity, commitAction);

            return commitResult;
        }

        public static Tuple<CommitAction, PersonalEntity> Save(IEntityRepository<PersonalEntity> repositoryPersonalEntity,
            IEntityRepository<StreetAddress> repositoryStreetAddress, PersonalEntityDto dto)
        {
            if (dto == null)
                return new Tuple<CommitAction, PersonalEntity>(CommitAction.None, null);

            var entity = dto.Id.HasValue
                ? repositoryPersonalEntity.FirstOrDefault(i => i.Id == dto.Id)
                : null;
            
            //Create a new object if needed
            if (entity == null)
                entity = dto.ToEntity();
            else
                //Update for any changes
                dto.UpdateEntity(entity);

            //Set the addresses
            var saveResponceCurrentAddress = StreetAddressService.Save(repositoryStreetAddress, dto.CurrentAddress);
            if(saveResponceCurrentAddress.Item1 != CommitAction.None)
                entity.CurrentAddress = saveResponceCurrentAddress.Item2;

            var saveResponcePreviousAddress = StreetAddressService.Save(repositoryStreetAddress, dto.PreviousAddress);
            if (saveResponcePreviousAddress.Item1 != CommitAction.None)
                entity.PreviousAddress = saveResponcePreviousAddress.Item2;

            var saveResponceNearestRelativeAddress = StreetAddressService.Save(repositoryStreetAddress, dto.NearestRelativeAddress);
            if (saveResponceNearestRelativeAddress.Item1 != CommitAction.None)
                entity.NearestRelativeAddress = saveResponcePreviousAddress.Item2;

            var commitAction = repositoryPersonalEntity.Save(entity);

            //Set the track date fields on the view model
            dto.UpdateTracksTime(entity);

            return new Tuple<CommitAction, PersonalEntity>(commitAction, entity);
        }
    }
}