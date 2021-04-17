using System.Web;

namespace Demo3.Modules.Modules
{
    public class DeflectModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication app)
        {
            app.BeginRequest += (src, args) =>
            {
                app.Response.StatusCode = 500;
                app.Response.StatusDescription = "Site Currently Under Maintenance";

                //Directly jump on LogRequest event, bypassing the other request pipeline events
                app.CompleteRequest();
            };
        }
    }
}