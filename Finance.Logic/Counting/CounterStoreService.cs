using System;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Logic.Counting
{
    public class CounterStoreService
    {
        private IPersistanceFactory _persistanceFactory;
        private IRepository<CounterStore> _repositoryCounterStore;

        private IRepository<CounterStore> CounterStoreRepository
            => _repositoryCounterStore ?? (_repositoryCounterStore = _persistanceFactory.BuildEntityRepository<CounterStore>());

        public CounterStoreService(IPersistanceFactory persistanceFactory)
        {
            _persistanceFactory = persistanceFactory;
        }

        public int GetCurrentCounterCustomer()
        {
            var counterStore = this.CounterStoreRepository.FirstOrDefault();

            if(counterStore == null)
                throw new Exception("We have no counter store");

            return counterStore.CustomerCounter;
        }

        /// <note>
        /// This method should only be called within the session of a unit of work
        /// </note>
        public void IntcrementCounterCustomer_InSession()
        {
            var counterStore = this.CounterStoreRepository.FirstOrDefault();

            if(counterStore == null)
                throw new Exception("We have no counter store");

            counterStore.CustomerCounter++;

            this._repositoryCounterStore.Update(counterStore);
        }
        public int GetCurrentCounterPersonalApplication()
        {
            var counterStore = this.CounterStoreRepository.FirstOrDefault();

            if(counterStore == null)
                throw new Exception("We have no counter store");

            return counterStore.PersonalApplicationCounter;
        }

        /// <note>
        /// This method should only be called within the session of a unit of work
        /// </note>
        public void IntcrementCounterPersonalApplication_InSession()
        {
            var counterStore = this.CounterStoreRepository.FirstOrDefault();

            if(counterStore == null)
                throw new Exception("We have no counter store");

            counterStore.PersonalApplicationCounter++;

            this._repositoryCounterStore.Update(counterStore);
        }

        public int GetCurrentCounterDeal()
        {
            var counterStore = this.CounterStoreRepository.FirstOrDefault();

            if(counterStore == null)
                throw new Exception("We have no counter store");

            return counterStore.DealCounter;
        }

        /// <note>
        /// This method should only be called within the session of a unit of work
        /// </note>
        public void IntcrementCounterDeal_InSession()
        {
            var counterStore = this.CounterStoreRepository.FirstOrDefault();

            if (counterStore == null)
                throw new Exception("We have no counter store");

            counterStore.DealCounter++;

            this._repositoryCounterStore.Update(counterStore);
        }
    }
}