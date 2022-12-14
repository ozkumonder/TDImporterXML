using System;
using Ninject;
using Ninject.Modules;
using Quartz;
using Quartz.Simpl;
using Quartz.Spi;
using TDImporterXML.Business.DependencyResolvers.Ninject;

namespace TDImporterXML.WinService.DependencyResolvers.Ninject
{
    public class NinjectServiceJobFactory : SimpleJobFactory
    {
        private static IKernel _kernel;
        private static IKernel _ninjectKernel;

        public NinjectServiceJobFactory(IKernel kernel)
        {
            _kernel = new StandardKernel(new BusinessModule());
        }
        public static void Wire(INinjectModule module)
        {
            _ninjectKernel = new StandardKernel(new BusinessModule());
        }
        public override IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            try
            {
                // this will inject dependencies that the job requires
                return (IJob) _kernel.Get(bundle.JobDetail.JobType);
            }
            catch (Exception e)
            {
                throw new SchedulerException(
                    string.Format("Problem while instantiating job '{0}' from the NinjectJobFactory.",
                        bundle.JobDetail.Key), e);
            }
        }
        public static T Resolve<T>()
        {
            return _ninjectKernel.Get<T>();
        }
    }
}