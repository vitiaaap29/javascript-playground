using System;
using System.Linq;
using System.Threading;
using System.Web;

namespace JS.Modules
{
    public class DelayModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += OnBeginRequest;
        }

        public void Dispose() { }


        private void OnBeginRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;

            if (context.Request.Params.AllKeys.Contains("delay"))
            {
                int delay = int.Parse(context.Request.Params["delay"]);
                Thread.Sleep(delay);
            }
        }
    }
}