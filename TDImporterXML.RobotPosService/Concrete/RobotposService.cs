using System.Configuration;
using System.Xml;
using TDImporterXML.RobotPosService.Abstract;
using TDImporterXML.RobotPosService.RobotposServices;

namespace TDImporterXML.RobotPosService.Concrete
{
    public class RobotposService : IRobotposService
    {
        public string GetXmlDataString(string securityKey, int dataTypeId, string appName, string branchList,string startDate, string endDate, string sendAll)
        {
            var service = new integrationService
            {
                Url = ConfigurationManager.AppSettings["RobotposServicesUrl"]
            };
            var result = service.getXmlData(securityKey, dataTypeId, appName, branchList, startDate, endDate, sendAll);

            return result;
        }

        public XmlDocument GetDataXml(string securityKey, int dataTypeId, string appName, string branchList,
            string startDate, string endDate, string sendAll)
        {
            var service = new integrationService
            {
                Url = ConfigurationManager.AppSettings["RobotposServicesUrl"]
            };
            var result = service.getXmlData(securityKey, dataTypeId, appName, branchList, startDate, endDate, sendAll);
            if (result!="error:")
            {
                
            }
            var xmlResult = new XmlDocument();
            xmlResult.LoadXml(result);
            return xmlResult;
        }
    }
}