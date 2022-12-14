using Ninject;
using Ninject.Modules;
using TDImporterXML.Business.DependencyResolvers.Ninject;

namespace TDImporterXML.WinService
{
    public class CompositionRoot
    {
        private static IKernel _ninjectKernel;

        public static void Wire(INinjectModule module)
        {
            _ninjectKernel = new StandardKernel(new BusinessModule());
        }

        public static T Resolve<T>()
        {
            return _ninjectKernel.Get<T>();
        }
    }
}