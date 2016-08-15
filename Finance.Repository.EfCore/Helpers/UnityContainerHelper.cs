using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finance.Repository.EfCore.Repository;
using Generic.Framework.Interfaces.Entity;
using Microsoft.Practices.Unity;

namespace Finance.Repository.EfCore.Helpers
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
