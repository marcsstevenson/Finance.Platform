using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Finance.Api.Api;
using Finance.Api.Controllers;
using Finance.Api.IoC;
using Finance.Logic.Helpers;
using Finance.Logic.Indentity;
using Finance.Logic.Shared.Enums;
using Finance.Repository.Ef.Context;
using Finance.Repository.Ef.Helpers;
using Finance.Repository.Ef.IoC;
using Generic.Framework.Interfaces.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Practices.Unity;
using Unity.Mvc4;

namespace Finance.Api.App_Start
{
    public static class Bootstrapper
    {
        public static IUnityContainer _container;
        private static bool _isInitialised = false;

        public static void EnsureIsInitialised()
        {
            if (!_isInitialised)
            {
                _isInitialised = true;
                Initialise();
            }
        }

        //private static IUnityContainer Container { get { return _container; } }

        //public static IEmailService ResolveEmailService()
        //{
        //    return Container == null ? null : Container.Resolve<IEmailService>();
        //}

        public static IUnityContainer Initialise()
        {
            //Setup our container for Entity Framework
            _container = BootstrapperBase.InitialiseBase();

            //Use an application setting to determine IoC registrations
            //We could have used a unity section within the web.config instead but this does not allow for refactoring
            if (ConfigurationHelper.CurrentSystemMode == SystemMode.Live)
            {

            //    _container.RegisterType(typeof(IEmailService), typeof(SendGridRestEmailService));
            //    _container.RegisterType(typeof(ICreditCardPaymentManager), typeof(CreditCardPaymentManager));
            //}
            //else
            //{
            //    _container.RegisterType(typeof(IEmailService), typeof(InMemoryTrackerEmailService));
            //    _container.RegisterType(typeof(ICreditCardPaymentManager), typeof(CreditCardPaymentManagerMock));
            }
            _container.RegisterType<UserManager<PartyIdentityUser>>(
                new InjectionFactory(c => HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>()));
            _container.RegisterType<IRoleStore<IdentityRole, string>, RoleStore<IdentityRole>>(new InjectionConstructor(typeof(FinanceDbContext)));
            
            //_container.RegisterType(typeof(IBlobStorageHelper), typeof(AzureBlobHelper));
            _container.RegisterType(typeof(IIdentityManager), typeof(IdentityManager));
            //_container.RegisterType<IUserStore<PartyIdentityUser>, UserStore<PartyIdentityUser>>();
            _container.RegisterType<Finance.Api.Api.AccountController>(new InjectionConstructor());
            _container.RegisterType<Finance.Api.Controllers.AccountController>(new InjectionConstructor());
            _container.RegisterType<TokenTestingController>(new InjectionConstructor());
            //_container.RegisterType<RolesAdminController>(new InjectionConstructor());
            //_container.RegisterType<ManageController>(new InjectionConstructor());
            //_container.RegisterType<UsersAdminController>(new InjectionConstructor());

            //Configure the dependency resolver for Api controllers
            GlobalConfiguration.Configuration.DependencyResolver = new IoCContainer(_container);

            //Configure the dependency resolver for Mvc controllers
            DependencyResolver.SetResolver(new UnityDependencyResolver(_container));



            return _container;
        }

        public static IPersistanceFactory GetPersistanceFactory()
        {
            EnsureIsInitialised();

            var iRepository = _container.Resolve<IPersistanceFactory>();
            return iRepository;
        }
        //public static IBlobStorageHelper GetBlobStorageHelper()
        //{
        //    EnsureIsInitialised();

        //    var iRepository = _container.Resolve<IBlobStorageHelper>();
        //    return iRepository;
        //}

    }
}
