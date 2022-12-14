using System;
using System.Diagnostics;
using System.ServiceProcess;
using Ninject;
using Quartz;
using Quartz.Impl;
using TDImporterXML.Business.Scheduler;
using TDImporterXML.Core.CrossCuttingConcern.Logging.Abstract;
using TDImporterXML.WinService.DependencyResolvers.Ninject;
using TDImporterXML.WinService.SchedulerWinService;

namespace TDImporterXML.WinService
{
    public partial class TDImporterService : ServiceBase
    {
        private readonly ILoggingService _loggingService;
        
        public TDImporterService()
        {
        }

        public TDImporterService(ILoggingService loggingService)
        {
            _loggingService = loggingService;
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //BackgroundWorker bw = new BackgroundWorker();
            //bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            //bw.RunWorkerAsync();

            _loggingService.Log("Importer Servis Başlatıldı");
            try
            {
                JobScheduler.Start();
                _loggingService.Log("Zamanlanmış Görev Başlatıldı");
            }
            catch (Exception e)
            {
                _loggingService.Log("Zamanlanmış Görev Hata Oluştu");
                Console.WriteLine(e);
                throw;
            }
        }

        protected override void OnStop()
        {
            //p.Kill();
        }
        
    }
}