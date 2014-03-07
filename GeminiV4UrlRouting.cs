using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Countersoft.Gemini.Extensibility.Apps;
using System.Web.Routing;
using System.Web.Http;
using System.Web.Mvc;
using Countersoft.Gemini.Infrastructure;

namespace GeminiV4UrlRouting
{
    public class OldIssueUrlRoutes : IAppRoutes
    {
        public void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(null, "default.aspx", new { controller = "OldIssueUrl", action = "Resolve"});
            routes.MapRoute(null, "issue/viewissue.aspx", new { controller = "OldIssueUrl", action = "Resolve" });
            routes.MapRoute(null, "project/{projectcode}/{projectid}/item/{issueid}", new { controller = "OldIssueUrl", action = "Resolve" }, new { projectid = @"\d{1,10}", issueid = @"\d{1,10}" });
        }
    }

    public class OldIssueUrlController : BaseController
    {
        public ActionResult Resolve(int? id, int? i, int? issueid)
        {
            int theIssueId = 0;

            if (id.GetValueOrDefault() > 0)
            {
                theIssueId = id.Value;
            }
            else if (i.GetValueOrDefault() > 0)
            {
                theIssueId = i.Value;
            }
            else if(issueid.GetValueOrDefault() > 0)
            {
                theIssueId = issueid.Value;
            }

            return Redirect(string.Concat("~/workspace/0/item/", theIssueId));
        }
    }
}
