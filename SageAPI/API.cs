using Sage.SMB.API;

namespace SageAPI
{
    public class Api
    {
        public void InitializeApi(IMBXML gobjMbapi)
        {
            if (gobjMbapi.IntializeAPI() == 0)
                return;
            DeinitializeApi(gobjMbapi);
        }

        public void SetDataSource(IMBXML gobjMbapi)
        {
            if (gobjMbapi.SetDataSource("DPQD1\\SAGE100CON") == 0)
                return;
            DeinitializeApi(gobjMbapi);
        }

        public void EnableRequests(IMBXML gobjMbapi)
        {
            if (gobjMbapi.EnableRequests() == 0)
                return;
            DeinitializeApi(gobjMbapi);
        }

        public string Submit(IMBXML gobjMbapi, string xml)
        {
            var str = gobjMbapi.submitXML(xml, "password");
            
            if (str.Length != 0)
                return str;
            DeinitializeApi(gobjMbapi);
            return (string) null;
        }

        public void DisableRequests(IMBXML gobjMbapi) => gobjMbapi.DisableRequests();

        public IMBXML DeinitializeApi(IMBXML gobjMbapi)
        {
            gobjMbapi.DeIntializeAPI();
            return (IMBXML) null;
        }

        public string Request(IMBXML gobjMbapi, string xmlRq)
        {
            this.InitializeApi(gobjMbapi);
            this.DisableRequests(gobjMbapi);
            this.SetDataSource(gobjMbapi);
            this.EnableRequests(gobjMbapi);
            string str = this.Submit(gobjMbapi, xmlRq);
            this.DisableRequests(gobjMbapi);
            DeinitializeApi(gobjMbapi);
            
            return str;
        } 
    }
}