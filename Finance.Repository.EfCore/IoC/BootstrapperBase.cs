using Finance.Repository.Ef.Helpers;
using Generic.Framework.Interfaces.Entity;
using Microsoft.Practices.Unity;

namespace Finance.Repository.Ef.IoC
{
    public static class BootstrapperBase
    {
        public static IUnityContainer _container;
        private static bool _isInitialised = false;

        public static void EnsureIsInitialised()
        {
            if (!_isInitialised)
            {
                _isInitialised = true;
                InitialiseBase();
            }
        }

        public static IUnityContainer InitialiseBase()
        {
            _container = UnityContainerHelper.BuildUnityContainer();

            return _container;
        }

        public static IPersistanceFactory GetPersistanceFactory()
        {
            EnsureIsInitialised();

            var iRepository = _container.Resolve<IPersistanceFactory>();
            return iRepository;
        }
    }
}
