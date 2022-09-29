using Newtonsoft.Json.Linq;
using Sage.SMB.API;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;
using Part = SageAPI.Models.Part;

namespace SageAPI.Controllers
{
  public class PartController : ApiController
  {
    public IEnumerable<string> Get() => (IEnumerable<string>) new string[2]
    {
      "value1",
      "value2"
    };

    public string Get(int id) => "value";

    public HttpResponseMessage Post([FromBody] JObject newParts)
    {
      Part[] partArray = newParts["parts"].ToObject<Part[]>();
      XElement xelement = XElement.Parse("<api:MBXML xmlns:api = 'http://sage100contractor.com/api'></api:MBXML>");
      XElement content1 = new XElement((XName) "MBXMLSessionRq", new object[2]
      {
        (object) new XElement((XName) "Company", (object) ConfigurationManager.AppSettings["Company"]),
        (object) new XElement((XName) "User", (object) "sageAPI")
      });
      XElement content2 = new XElement((XName) "MBXMLMsgsRq", new object[2]
      {
        (object) new XAttribute((XName) "messageSetID", (object) "1"),
        (object) new XAttribute((XName) "onError", (object) "continueOnError")
      });
      int num = 1;
      int content3 = 0;
      if (partArray[0].ObjectID != 0)
      {
        int objectId = partArray[0].ObjectID;
      }
      else
        content3 = PartController.GetLastObjectID() + 1;
      foreach (Part part in partArray)
      {
        XElement content4 = new XElement((XName) "PartAddRq", new object[32]
        {
          (object) new XAttribute((XName) "requestID", (object) num),
          (object) new XElement((XName) "ObjectRef", (object) new XElement((XName) "ObjectID", (object) content3)),
          (object) new XElement((XName) "Desc", (object) part.Desc),
          (object) new XElement((XName) "Unit", (object) part.Unit),
          (object) new XElement((XName) "BinNumber", (object) part.BinNumber),
          (object) new XElement((XName) "AlphaPart", (object) part.AlphaPart),
          (object) new XElement((XName) "MSDSNumber", (object) part.MSDSNumber),
          (object) new XElement((XName) "Manufacturer", (object) part.Manufacturer),
          (object) new XElement((XName) "ManufacturerPartNumber", (object) part.ManufacturerPartNumber),
          (object) new XElement((XName) "UserDefined1", (object) part.UserDefined1),
          (object) new XElement((XName) "UserDefined2", (object) part.UserDefined2),
          (object) new XElement((XName) "CostCodeRef", (object) new XElement((XName) "ObjectID", (object) part.CostCodeRef)),
          (object) new XElement((XName) "CostTypeRef", (object) new XElement((XName) "ObjectID", (object) part.CostTypeRef)),
          (object) new XElement((XName) "TaskRef", (object) new XElement((XName) "ObjectID", (object) part.TaskRef)),
          (object) new XElement((XName) "PartClassRef", (object) new XElement((XName) "ObjectID", (object) part.PartClassRef)),
          (object) new XElement((XName) "InventoryLocationRef", (object) new XElement((XName) "ObjectID", (object) part.InventoryLocationRef)),
          (object) new XElement((XName) "PriceLastUpdatedDate", (object) part.PriceLastUpdatedDate),
          (object) new XElement((XName) "ReorderQuantity", (object) part.ReorderQuantity),
          (object) new XElement((XName) "MinimumOrderQuantity", (object) part.MinimumOrderQuantity),
          (object) new XElement((XName) "PackagedQuantity", (object) part.PackagedQuantity),
          (object) new XElement((XName) "ShippingWeight", (object) part.ShippingWeight),
          (object) new XElement((XName) "DefaultCost", (object) part.DefaultCost),
          (object) new XElement((XName) "LaborUnitQuantity", (object) part.LaborUnitQuantity),
          (object) new XElement((XName) "BillingAmount", (object) part.BillingAmount),
          (object) new XElement((XName) "IsStockPart", (object) part.IsStockPart),
          (object) new XElement((XName) "IsSerialized", (object) part.IsSerialized),
          (object) new XElement((XName) "BillingMarkupRate", (object) part.BillingMarkupRate),
          (object) new XElement((XName) "PartRef", (object) new XElement((XName) "ObjectID", (object) part.PartRef)),
          (object) new XElement((XName) "Memo", (object) part.Memo),
          (object) new XElement((XName) "IsServiceEquipment", (object) part.IsServiceEquipment),
          (object) new XElement((XName) "OEMWarrantyDuration", (object) part.OEMWarrantyDuration),
          (object) new XElement((XName) "InventoryRequired", (object) part.InventoryRequired)
        });
        content2.Add((object) content4);
        ++num;
        ++content3;
      }
      xelement.Add((object) content1);
      xelement.Add((object) content2);
      IMBXML gobjMbapi = new IMBXML();
      Api api = new Api();
      PartController.ApiSessionStartup(api, gobjMbapi);
      string str = api.Submit(gobjMbapi, xelement.ToString());
      PartController.ApiSessionEnd(api, gobjMbapi);
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

    private static int GetLastObjectID()
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
          (object) new XElement((XName) "SQL", (object) "SELECT * FROM Part")
        })
      });
      xelement.Add((object) content1);
      xelement.Add((object) content2);
      IMBXML gobjMbapi = new IMBXML();
      Api api = new Api();
      PartController.ApiSessionStartup(api, gobjMbapi);
      string text = api.Submit(gobjMbapi, xelement.ToString());
      PartController.ApiSessionEnd(api, gobjMbapi);
      return int.Parse(XDocument.Parse(text).Descendants().Last<XElement>().Attribute((XName) "ObjectID").Value);
    }
  }
}
 