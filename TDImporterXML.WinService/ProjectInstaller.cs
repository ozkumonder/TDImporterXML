using System.ComponentModel;
using System.Configuration.Install;

namespace TDImporterXML.WinService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
    }
}