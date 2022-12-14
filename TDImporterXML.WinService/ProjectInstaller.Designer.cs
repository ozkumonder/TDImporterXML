namespace TDImporterXML.WinService
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sPITDImporterXml = new System.ServiceProcess.ServiceProcessInstaller();
            this.TDImporterXmlService = new System.ServiceProcess.ServiceInstaller();
            // 
            // sPITDImporterXml
            // 
            this.sPITDImporterXml.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.sPITDImporterXml.Password = null;
            this.sPITDImporterXml.Username = null;
            // 
            // TDImporterXmlService
            // 
            this.TDImporterXmlService.Description = "Tavuk Dünyası Robotpos Web servisten alınan xml dosyalarını logoya import eder";
            this.TDImporterXmlService.DisplayName = "TDImporterXmlService";
            this.TDImporterXmlService.ServiceName = "TDImporterXmlService";
            this.TDImporterXmlService.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.sPITDImporterXml,
            this.TDImporterXmlService});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller sPITDImporterXml;
        private System.ServiceProcess.ServiceInstaller TDImporterXmlService;
    }
}