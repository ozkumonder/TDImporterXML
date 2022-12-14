using System;
using System.Configuration;
using Ninject;
using Quartz;
using Quartz.Impl;
using TDImporterXML.Business.DependencyResolvers.Ninject;
using TDImporterXML.Core.CrossCuttingConcern.Logger;
using TDImporterXML.Core.Utilities.ExtensionMethods;

namespace TDImporterXML.Business.Scheduler
{
    public  class JobScheduler
    {
        public static void Start()
        {
            Logger.Log("JobScheduler Başlatıldı");
            IKernel kernel = new StandardKernel();
            kernel.Bind<IJob>().To<ImporterJob>();

            #region QuartzNet

            // 24 saatte bir çalışacak SimpleTrigger Örneğidir
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            var scheduler = schedulerFactory.GetScheduler();
            //sched.Clear();
            scheduler.JobFactory = new NinjectJobFactory(kernel);
            scheduler.Start();
            var job = JobBuilder.Create<ImporterJob>().Build();
            // Dakikalık trigger
            var hour = ConfigurationManager.AppSettings["Hour"].ToInt32();
            var minute = ConfigurationManager.AppSettings["Minute"].ToInt32();
            var trigger = TriggerBuilder.Create().ForJob(job)
                .WithIdentity("trigger1").WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(hour, minute))
                .Build();

            //ITrigger trigger = TriggerBuilder.Create()//    .WithSimpleSchedule(a => a.WithIntervalInMinutes(5).RepeatForever())
            //    .Build();

            //Günlük belirli zaman
            //ITrigger trigger = TriggerBuilder.Create()
            //    .WithDailyTimeIntervalSchedule
            //    (s =>
            //        s.WithIntervalInHours(24)
            //            .OnEveryDay()//            .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(23, 00))
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
        //public static void Start()
        //{
        //    IKernel kernel = new StandardKernel();
        //    kernel.Bind<IJob>().To<ImporterJob>();

        //    #region QuartzNet

        //    // 24 saatte bir çalışacak SimpleTrigger Örneğidir
        //    ISchedulerFactory schedulerFactory = new StdSchedulerFactory();

        //    IScheduler scheduler = schedulerFactory.GetScheduler();
        //    //sched.Clear();
        //    //scheduler.JobFactory = new NinjectJobFactory(kernel);
        //    //scheduler.Start();
        //    //IJobDetail job = JobBuilder.Create<ImporterJob>().Build();




        //    //ITrigger trigger = TriggerBuilder.Create()
        //    //    .WithIdentity("myTrigger", "group1")
        //    //    .StartNow()
        //    //    .WithSimpleSchedule(x => x
        //    //        .WithIntervalInMinutes(40)
        //    //        .RepeatForever())
        //    //    //.EndAt(DateBuilder.DateOf(11, 30, 0))
        //    //    .Build();
        //    //var trigger = TriggerBuilder.Create().ForJob(job)
        //    //    .WithIdentity("trigger1")
        //    //    .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(17,44))
        //    //    .Build();




        //    //ITrigger trigger = TriggerBuilder.Create()
        //    //    .WithDailyTimeIntervalSchedule
        //    //    (s =>
        //    //        s.WithIntervalInHours(24)
        //    //            .OnEveryDay()
        //    //            .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(23, 00))
        //    //    )
        //    //    .Build();
        //    //scheduler.ScheduleJob(job, trigger);

        //    #endregion


        //}
    }
}