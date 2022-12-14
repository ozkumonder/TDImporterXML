using System.ServiceProcess;
using TDImporterXML.Business.DependencyResolvers.Ninject;
using TDImporterXML.WinService.DependencyResolvers.Ninject;

namespace TDImporterXML.WinService
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        private static void Main()
        {

            //NinjectJobFactory.Wire(new BusinessModule());
            //ServiceBase[] ServicesToRun;
            //ServicesToRun = new ServiceBase[]
            //{
            //    NinjectJobFactory.Resolve<TDImporterService>()
            //};
            //ServiceBase.Run(ServicesToRun);
            CompositionRoot.Wire(new BusinessModule());
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                CompositionRoot.Resolve<TDImporterService>()
            };
            ServiceBase.Run(ServicesToRun);



        }
    }
}