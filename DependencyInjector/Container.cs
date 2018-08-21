using AcmeRemote.DataAccess;
using AcmeRemote.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace DependencyInjector
{
    public class Container
    {
        private Container()
        {
        }
        private static object _lock = new object();
        private static UnityContainer _unityContainer;
        private static Container _container;

        
        public static UnityContainer DependencyResolver
        {
            get
            {
                lock (_lock)
                {
                    if (_unityContainer == null)
                    {
                        _unityContainer = new UnityContainer();
                        Container.BuildUnityContainer();
                    }
                }
                return _unityContainer;
            }
        }

        private static void BuildUnityContainer()
        {
            _unityContainer.RegisterType<IHelicopterRepository, HelicopterRepository>(new ContainerControlledLifetimeManager());
            _unityContainer.RegisterType<IFlightRepository, FlightRepository>(new ContainerControlledLifetimeManager());
            _unityContainer.RegisterType<ICityRepository, CityRepository>(new ContainerControlledLifetimeManager());
            _unityContainer.RegisterType<IService, Service>(new ContainerControlledLifetimeManager());
        }
    }
}
