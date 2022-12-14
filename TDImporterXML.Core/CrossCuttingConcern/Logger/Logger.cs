using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDImporterXML.Core.CrossCuttingConcern.Logger
{
    public class Logger
    {
        public Logger()
        {
        }

        public static void Log(string stringText)
        {
            StreamWriter streamWriter;
            string directoryName = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            directoryName = string.Concat(directoryName, "\\TDImporterXMLLogs");
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
            DateTime now = DateTime.Now;
            string str = string.Concat(directoryName, "\\TDImporterXML_Log_", now.ToString("dd-MM-yyyy"), ".txt");
            streamWriter = (File.Exists(str) ? File.AppendText(str) : new StreamWriter(str));
            streamWriter.WriteLine(string.Format("{0} {1}", DateTime.Now, stringText));
            streamWriter.Close();
            streamWriter.Dispose();
        }

        public static void LogError(string stringText)
        {
            StreamWriter streamWriter;
            string directoryName = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            directoryName = string.Concat(directoryName, "\\TDImporterXMLLogs");
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
            DateTime now = DateTime.Now;
            string str = string.Concat(directoryName, "\\TDImporterXML_ErrorLog_", now.ToString("dd-MM-yyyy"), ".txt");
            streamWriter = (File.Exists(str) ? File.AppendText(str) : new StreamWriter(str));
            streamWriter.WriteLine(string.Format("{0} {1}", DateTime.Now, stringText));
            streamWriter.Close();
            streamWriter.Dispose();
        }
    }
}
