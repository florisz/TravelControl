using Microsoft.Practices.Unity;
using System;
using TravelControl.Domain;
using SIM=TravelControl.Storage;

namespace TravelControl.Common
{
    public sealed class ServiceLocator
    {
        private static volatile ServiceLocator _instance;
        private static object syncRoot = new object();
        private static IUnityContainer _container;

        private ServiceLocator() { }

        public static ServiceLocator Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new ServiceLocator();
                            _container = new UnityContainer();
                        }
                    }
                }

                return _instance;
            }
        }
        
        public void RegisterTypes(Action<IUnityContainer> register)
        {
            register(_container);
        }

        public T Resolve<T>(params ResolverOverride[] overrides)
        {
            return _container.Resolve<T>(overrides);
        }

        public T Resolve<T>(string name, params ResolverOverride[] overrides)
        {
            return _container.Resolve<T>(name, overrides);
        }

        public object BuildUp(Type t, object obj)
        {
            return _container.BuildUp(t, obj);
        }

    }
}
