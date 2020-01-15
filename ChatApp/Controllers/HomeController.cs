using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PusherServer;
using System.Net;
using System.Threading.Tasks;

namespace ChatApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
            public async Task<ActionResult> Pushermessage(string message)
        {
            var options = new PusherOptions();
            options.Cluster = "mt1";
            var pusher = new Pusher("932166", "e19424c57e2df62ff676", "3ebdf5f715c1973b537a", options);
            ITriggerResult result = await pusher.TriggerAsync("my_channel", "my_event", new { message = message, name = "Anonymous" });

            return new HttpStatusCodeResult((int)HttpStatusCode.OK);
        }
    }
}