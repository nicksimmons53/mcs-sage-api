using Newtonsoft.Json.Linq;
using Sage.SMB.API;
using SageAPI.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;

namespace SageAPI.Controllers
{
  public class ClientController : ApiController
  {
    public IEnumerable<string> Get() => (IEnumerable<string>) new string[2]
    {
      "value1",
      "value2"
    };
    
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
        (object) new XElement((XName) "ClientQryRq", new object[2]
        {
          (object) new XAttribute((XName) "requestID", (object) 1),
          (object) new XElement((XName) "ObjectRef", (object) new XElement((XName) "ObjectID", (object) id))
        })
      });
      xelement.Add((object) content1);
      xelement.Add((object) content2);
      IMBXML gobjMBAPI = new IMBXML();
      Api api = new Api();
      ClientController.ApiSessionStartup(api, gobjMBAPI);
      string str = api.Submit(gobjMBAPI, xelement.ToString());
      ClientController.ApiSessionEnd(api, gobjMBAPI);
      return str;
    }

    public HttpResponseMessage Post([FromBody] JObject newClient)
    {
      Client client = newClient["info"].ToObject<Client>();
      ClientContact[] clientContactArray = newClient["contacts"].ToObject<ClientContact[]>();
      XElement xelement = XElement.Parse("<api:MBXML xmlns:api = 'http://sage100contractor.com/api'></api:MBXML>");
      XElement content1 = new XElement((XName) "MBXMLSessionRq", new object[2]
      {
        (object) new XElement((XName) "Company", (object) ConfigurationManager.AppSettings["Company"]),
        (object) new XElement((XName) "User", (object) "sageAPI")
      });
      XElement content2 = new XElement((XName) "MBXMLMsgsRq", new object[3]
      {
        (object) new XAttribute((XName) "messageSetID", (object) "1"),
        (object) new XAttribute((XName) "onError", (object) "continueOnError"),
        (object) new XElement((XName) "ClientAddNextRq", new object[23]
        {
          (object) new XAttribute((XName) "requestID", (object) 1),
          (object) new XElement((XName) "ShortName", (object) client.ShortName),
          (object) new XElement((XName) "Name", (object) client.Name),
          (object) new XElement((XName) "Greeting", (object) client.Greeting),
          (object) new XElement((XName) "Addr1", (object) client.Addr1),
          (object) new XElement((XName) "Addr2", (object) client.Addr2),
          (object) new XElement((XName) "City", (object) client.City),
          (object) new XElement((XName) "State", (object) client.State),
          (object) new XElement((XName) "PostalCode", (object) client.PostalCode),
          (object) new XElement((XName) "BillingAddr1", (object) client.BillingAddr1),
          (object) new XElement((XName) "BillingAddr2", (object) client.BillingAddr2),
          (object) new XElement((XName) "BillingCity", (object) client.BillingCity),
          (object) new XElement((XName) "BillingState", (object) client.BillingState),
          (object) new XElement((XName) "BillingPostalCode", (object) client.BillingPostalCode),
          (object) new XElement((XName) "ShippingAddr1", (object) client.ShippingAddr1),
          (object) new XElement((XName) "ShippingAddr2", (object) client.ShippingAddr2),
          (object) new XElement((XName) "ShippingCity", (object) client.ShippingCity),
          (object) new XElement((XName) "ShippingState", (object) client.ShippingState),
          (object) new XElement((XName) "ShippingPostalCode", (object) client.ShippingPostalCode),
          (object) new XElement((XName) "SalespersonRef", (object) new XElement((XName) "ObjectID", (object) client.SalespersonRef)),
          (object) new XElement((XName) "ManagerRef", (object) new XElement((XName) "ObjectID", (object) client.ManagerRef)),
          (object) new XElement((XName) "ClientTypeRef", (object) new XElement((XName) "ObjectID", (object) client.ClientTypeRef)),
          (object) new XElement((XName) "ClientStatusRef", (object) new XElement((XName) "ObjectID", (object) client.ClientStatusRef))
        })
      });
      foreach (ClientContact clientContact in clientContactArray)
      {
        XElement content3 = new XElement((XName) "ClientContactAdd", new object[4]
        {
          (object) new XElement((XName) "ContactName", (object) clientContact.ContactName),
          (object) new XElement((XName) "JobTitle", (object) clientContact.JobTitle),
          (object) new XElement((XName) "Phone", (object) clientContact.Phone),
          (object) new XElement((XName) "Email", (object) clientContact.Email)
        });
        content2.Descendants((XName) "ClientAddNextRq").First<XElement>().Add((object) content3);
      }
      xelement.Add((object) content1);
      xelement.Add((object) content2);
      IMBXML gobjMbapi = new IMBXML();
      Api api = new Api();
      ClientController.ApiSessionStartup(api, gobjMbapi);
      string str = api.Submit(gobjMbapi, xelement.ToString());
      ClientController.ApiSessionEnd(api, gobjMbapi);
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