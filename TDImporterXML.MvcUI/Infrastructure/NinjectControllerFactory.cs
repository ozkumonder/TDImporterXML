using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using TDImporterXML.Business.DependencyResolvers.Ninject;

namespace TDImporterXML.MvcUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _kernel;

        public NinjectControllerFactory()
        {
            _kernel = new StandardKernel(new BusinessModule());
        }

        /// <summary>
        /// Web api DI çözümü Kernel'a ihtiyaç duyuyor. Daha iyi bir çözüm implemente edilebilir. Şimdilik uygun.
        /// </summary>
        public IKernel Kernel
        {
            get { return _kernel; }
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)_kernel.Get(controllerType);
        }
    }
}