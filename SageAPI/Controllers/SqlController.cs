using Sage.SMB.API;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;

namespace SageAPI.Controllers
{
    public class SqlController : ApiController
    {
        public HttpResponseMessage Get([FromBody] string query)
        {
            XElement xelement = XElement.Parse("<api:MBXML xmlns:api = 'http://sage100contractor.com/api'></api:MBXML>");
            XElement content1 = new XElement((XName) "MBXMLSessionRq", new object[2]
            {
                (object) new XElement((XName) "Company", (object) ConfigurationManager.AppSettings["Company"]),
                (object) new XElement((XName) "User", (object) "sageAPI")
            });
            XElement content2 = new XElement((XName) "MBXMLMsgsRq", new object[3]
            {
                (object) new XAttribute((XName) "messageSetID", (object) 1),
                (object) new XAttribute((XName) "onError", (object) "continueOnError"),
                (object) new XElement((XName) "SQLRunRq", new object[2]
                {
                    (object) new XAttribute((XName) "requestID", (object) 1),
                    (object) new XElement((XName) "SQL", (object) query)
                })
            });
            xelement.Add((object) content1);
            xelement.Add((object) content2);
            IMBXML gobjMBAPI = new IMBXML();
            Api api = new Api();
            SqlController.ApiSessionStartup(api, gobjMBAPI);
            string str = api.Submit(gobjMBAPI, xelement.ToString());
            SqlController.ApiSessionEnd(api, gobjMBAPI);
            return this.Request.CreateResponse<string>(HttpStatusCode.Created, str);
        }

        private static void ApiSessionStartup(Api api, IMBXML gobjMbapi)
        {
            api.InitializeApi(gobjMbapi);
            api.DisableRequests(gobjMbapi);
            api.SetDataSource(gobjMbapi);
            api.EnableRequests(gobjMbapi);
        }

        private static IMBXML ApiSessionEnd(Api api, IMBXML gobjMbapi)
        {
            api.DisableRequests(gobjMbapi);
            api.DeinitializeApi(gobjMbapi);
            return (IMBXML) null;
        }
    }
}