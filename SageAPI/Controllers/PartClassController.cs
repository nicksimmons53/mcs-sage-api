using Newtonsoft.Json.Linq;
using Sage.SMB.API;
using SageAPI.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;

namespace SageAPI.Controllers
{
  public class PartClassController : ApiController
  {
    public IEnumerable<string> Get()
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
          (object) new XElement((XName) "SQL", (object) "SELECT * FROM PartClass")
        })
      });
      xelement.Add((object) content1);
      xelement.Add((object) content2);
      IMBXML gobjMbapi = new IMBXML();
      Api api = new Api();
      PartClassController.ApiSessionStartup(api, gobjMbapi);
      string str = api.Submit(gobjMbapi, xelement.ToString());
      PartClassController.ApiSessionEnd(api, gobjMbapi);
      return (IEnumerable<string>) new string[1]
      {
        str
      };
    }

    public string Get(int id)
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
        (object) new XElement((XName) "PartClassQryRq", new object[2]
        {
          (object) new XAttribute((XName) "requestID", (object) 1),
          (object) new XElement((XName) "ObjectRef", (object) new XElement((XName) "ObjectID", (object) id))
        })
      });
      xelement.Add((object) content1);
      xelement.Add((object) content2);
      IMBXML gobjMbapi = new IMBXML();
      Api api = new Api();
      PartClassController.ApiSessionStartup(api, gobjMbapi);
      string str = api.Submit(gobjMbapi, xelement.ToString());
      PartClassController.ApiSessionEnd(api, gobjMbapi);
      return str;
    }

    public HttpResponseMessage Post([FromBody] JObject newPartClass)
    {
      PartClass partClass = newPartClass["info"].ToObject<PartClass>();
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
        (object) new XElement((XName) "PartClassAddRq", new object[4]
        {
          (object) new XAttribute((XName) "requestID", (object) 1),
          (object) new XElement((XName) "ObjectRef", (object) new XElement((XName) "ObjectID", (object) partClass.ObjectID)),
          (object) new XElement((XName) "Name", (object) partClass.Name),
          (object) new XElement((XName) "IndentLevel", (object) partClass.IndentLevel)
        })
      });
      xelement.Add((object) content1);
      xelement.Add((object) content2);
      IMBXML gobjMbapi = new IMBXML();
      Api api = new Api();
      PartClassController.ApiSessionStartup(api, gobjMbapi);
      string str = api.Submit(gobjMbapi, xelement.ToString());
      PartClassController.ApiSessionStartup(api, gobjMbapi);
      return this.Request.CreateResponse<string>(HttpStatusCode.Created, str);
    }

    public void Put(int id, [FromBody] string value)
    {
    }

    public void Delete(int id)
    {
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