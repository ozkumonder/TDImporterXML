using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using TDImporterXML.Business.Abstract;
using TDImporterXML.Business.Concrete;
using TDImporterXML.Business.DependencyResolvers.Ninject;
using TDImporterXML.WinUI.Infrastructure;

namespace TDImporterXML.WinUI
{
    static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CompositionRoot.Wire(new BusinessModule());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            Application.Run(CompositionRoot.Resolve<frmMain>());
        }
    }
}
