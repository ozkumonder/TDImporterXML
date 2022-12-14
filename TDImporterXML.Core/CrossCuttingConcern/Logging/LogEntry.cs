using System;

namespace TDImporterXML.Core.CrossCuttingConcern.Logging
{
    public class LogEntry
    {
        public DateTime Date { get; set; }
        public string Module { get; set; }
        public string Method { get; set; }
        public string DeclaringType { get; set; }
        public string LineNumber { get; set; }
        public string ErrorMessage { get; set; }
    }
}