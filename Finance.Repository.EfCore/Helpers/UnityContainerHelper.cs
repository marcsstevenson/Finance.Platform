using Finance.Repository.Ef.Repository;
using Generic.Framework.Interfaces.Entity;
using Microsoft.Practices.Unity;

namespace Finance.Repository.Ef.Helpers
{
    public static class UnityContainerHelper
    {
        //Builds the container for EF based repositories
        public static IUnityContainer BuildUnityContainer()
        {
            var unityContainer = new UnityContainer();

            AddRegistrations(unityContainer);

            return unityContainer;
        }

        public static void AddRegistrations(UnityContainer unityContainer)
        {
            unityContainer.RegisterType(typeof(IPersistanceFactory), typeof(PersistanceFactory));
            //unityContainer.RegisterType(typeof(IBlobStorageHelper), typeof(AzureBlobHelper));
        }
    }
}
