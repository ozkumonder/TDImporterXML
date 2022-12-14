using System;
using System.Collections.Generic;

namespace TDImporterXML.Core.CrossCuttingConcern.Logging.Abstract
{
    public interface ILoggingService
    {
        void Log(string message);
        void Log(Exception ex);
        void Initialise(int maxLogSize);
        IList<LogEntry> ListLogFile();
        void Recycle();
        void ClearLogFiles();
    }
}