using Ninject;
using Quartz;
using Quartz.Impl;
using TDImporterXML.Core.CrossCuttingConcern.Logger;
using TDImporterXML.WinService.DependencyResolvers.Ninject;

namespace TDImporterXML.WinService.SchedulerWinService
{
    public class ServiceJobScheduler
    {
        public static void Start()
        {
            Logger.Log("ServiceJobScheduler start");
            IKernel kernel = new StandardKernel();
            kernel.Bind<IJob>().To<ServiceImporterJob>();

            #region QuartzNet

            // 24 saatte bir çalışacak SimpleTrigger Örneğidir
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();

            var scheduler = schedulerFactory.GetScheduler();
            //sched.Clear();
            scheduler.JobFactory = new NinjectServiceJobFactory(kernel);
            scheduler.Start();
            var job = JobBuilder.Create<ServiceImporterJob>().Build();
            // Dakikalık trigger
            var trigger = TriggerBuilder.Create().ForJob(job)
                .WithIdentity("trigger1")
                .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(13, 55))
                .Build();

            //ITrigger trigger = TriggerBuilder.Create()
            //    .WithSimpleSchedule(a => a.WithIntervalInMinutes(5).RepeatForever())
            //    .Build();

            //Günlük belirli zaman
            //ITrigger trigger = TriggerBuilder.Create()
            //    .WithDailyTimeIntervalSchedule
            //    (s =>
            //        s.WithIntervalInHours(24)
            //            .OnEveryDay()
            //            .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(23, 00))
            //    )
            //    .Build();
            scheduler.ScheduleJob(job, trigger);

            #endregion
        }
        public void Stop()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Shutdown();
        }
    }
}