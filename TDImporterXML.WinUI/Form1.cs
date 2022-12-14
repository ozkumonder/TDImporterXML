using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.ViewInfo;
using TDImporterXML.Business.Abstract;
using TDImporterXML.Business.Concrete;
using TDImporterXML.Core.CrossCuttingConcern.Logging.Abstract;
using TDImporterXML.Core.Utilities.XmlSerilizer;
using TDImporterXML.RobotPosService.Abstract;

namespace TDImporterXML.WinUI
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IFirmsService _firmsService;
        private readonly ILoggingService _loggingService;
        private readonly IRobotposService _robotposService;

        public Form1(IFirmsService firmsService, ILoggingService loggingService, IRobotposService robotposService)
        {
            _firmsService = firmsService;
            _loggingService = loggingService;
            _robotposService = robotposService;

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }
        
    }
}
