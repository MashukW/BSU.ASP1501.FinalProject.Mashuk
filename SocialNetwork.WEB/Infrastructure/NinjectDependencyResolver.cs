using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DependencyResolver;
using Ninject;

namespace SocialNetwork.WEB.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectDependencyResolver()
        {
            _kernel = new StandardKernel(new ResolverModule());
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}