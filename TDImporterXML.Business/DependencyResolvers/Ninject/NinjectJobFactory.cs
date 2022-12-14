using System;
using Ninject;
using Ninject.Modules;
using Quartz;
using Quartz.Simpl;
using Quartz.Spi;

namespace TDImporterXML.Business.DependencyResolvers.Ninject
{
    public class NinjectJobFactory:SimpleJobFactory
    {
        readonly IKernel _kernel;
        private static IKernel _ninjectKernel;

        public NinjectJobFactory(IKernel kernel)
        {
            this._kernel = new StandardKernel(new BusinessModule()); 
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
                return (IJob)this._kernel.Get(bundle.JobDetail.JobType);
            }
            catch (Exception e)
            {
                throw new SchedulerException(string.Format("Problem while instantiating job '{0}' from the NinjectJobFactory.", bundle.JobDetail.Key), e);
            }
        }
        public static T Resolve<T>()
        {
            return _ninjectKernel.Get<T>();
        }
    }
}