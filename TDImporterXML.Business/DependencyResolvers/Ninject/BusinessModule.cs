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

namespace TDImporterXML.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUsersService>().To<UsersService>().InSingletonScope();
            Bind<IFirmsService>().To<FirmsService>().InSingletonScope();
            Bind<ITransferredDataService>().To<TransferredDataService>();
            Bind<IUnTransferredDataService>().To<UnTransferredDataService>();
            Bind<IDocumentTypeService>().To<DocumentTypeService>();
            Bind<IBranchPairingService>().To<BranchPairingService>();
            Bind<IRobotposService>().To<RobotposService>();
            Bind<ILogoService>().To<LogoService>();

            Bind<ILogoDal>().To<LogoDal>();
            Bind<IUsersDal>().To<EfUsersDal>().InSingletonScope();
            Bind<IFirmsDal>().To<EfFirmsDal>().InSingletonScope();
            Bind<IDocumentTypeDal>().To<EfDocumentTypeDal>().InSingletonScope();
            Bind<IBranchPairingDal>().To<EfBranchPairingDal>().InSingletonScope();
            Bind<ITransferredDataDal>().To<EfTransferredDataDal>().InSingletonScope();
            Bind<IUnTransferredDataDal>().To<EfUnTranferredDataDal>().InSingletonScope();

            Bind<ILoggingService>().To<LoggingService>().InSingletonScope();

            Bind<IJob>().To<ImporterJob>().InSingletonScope();
        }
    }
}