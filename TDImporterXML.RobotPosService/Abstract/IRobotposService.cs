using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TDImporterXML.RobotPosService.Abstract
{
   public interface IRobotposService
   {
       string GetXmlDataString(string securityKey, int dataTypeId, string appName, string branchList, string startDate, string endDate, string sendAll);

       XmlDocument GetDataXml(string securityKey, int dataTypeId, string appName, string branchList, string startDate,string endDate, string sendAll);
   }
}
