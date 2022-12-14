using Ninject.Modules;
using Quartz;
using TDImporterXML.Business.Abstract;
using TDImporterXML.Business.Concrete;
using TDImporterXML.Business.Scheduler;
using TDImporterXML.Core.CrossCuttingConcern.Logging.Abstract;
using TDImporterXML.Core.CrossCuttingConcern.Logging.Concrete;
using TDImporterXML.DataLayer.Abstract;
using TDImporterXML.DataLayer.Concrete.EntityFramework;
using TDImporterXML.RobotPosService.Abstract;
using TDImporterXML.RobotPosService.Concrete;
using TDImporterXML.WinService.SchedulerWinService;

namespace TDImporterXML.WinService.DependencyResolvers.Ninject
{
    public class ServiceBusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnTransferredDataService>().To<UnTransferredDataService>();
            Bind<ILoggingService>().To<LoggingService>().InSingletonScope();
            Bind<ITransferredDataService>().To<TransferredDataService>();
            Bind<IUsersService>().To<UsersService>().InSingletonScope();
            Bind<IFirmsService>().To<FirmsService>().InSingletonScope();
            Bind<IBranchPairingService>().To<BranchPairingService>();
            Bind<IDocumentTypeService>().To<DocumentTypeService>();
            Bind<IRobotposService>().To<RobotposService>();
            Bind<ILogoService>().To<LogoService>();

            Bind<ILogoDal>().To<LogoDal>();
            Bind<IUsersDal>().To<EfUsersDal>().InSingletonScope();
            Bind<IFirmsDal>().To<EfFirmsDal>().InSingletonScope();
            Bind<IDocumentTypeDal>().To<EfDocumentTypeDal>().InSingletonScope();
            Bind<IBranchPairingDal>().To<EfBranchPairingDal>().InSingletonScope();
            Bind<ITransferredDataDal>().To<EfTransferredDataDal>().InSingletonScope();
            Bind<IUnTransferredDataDal>().To<EfUnTranferredDataDal>().InSingletonScope();

            Bind<IJob>().To<ServiceImporterJob>().InSingletonScope();
        }
    }
}