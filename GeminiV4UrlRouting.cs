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
            //View Documents
            routes.MapRoute(null, "project/documents/getdocument.aspx", new { controller = "OldIssueUrl", action = "Document" });

            //View Issues
            routes.MapRoute(null, "default.aspx", new { controller = "OldIssueUrl", action = "Resolve"});
            routes.MapRoute(null, "issue/viewissue.aspx", new { controller = "OldIssueUrl", action = "Resolve" });
            routes.MapRoute(null, "project/{projectcode}/{projectid}/item/{issueid}", new { controller = "OldIssueUrl", action = "Resolve" }, new { projectid = @"\d{1,10}", issueid = @"\d{1,10}" });
        }
    }

    public class OldIssueUrlController : BaseController
    {
        public ActionResult Resolve(int? id, int? i, int? issueid)
        {
            base.LogManager.LogDebug("G4Routing", "resolve url hit: " + Request.Form );

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

        public ActionResult Document(int? projectid, int? documentid)
        {

            base.LogManager.LogDebug( "G4Routing", "resolve document hit: " + Request.Form );

            /*var preview =
                "~/project/ALL/item/attachment/preview?issueid2=465&fileid=527&height=0&width=0";

            if (documentid.HasValue)
            {
                
                var doc = ProjectDocumentManager.Get(documentid.Value);
                    if(doc.Entity.ShortFileName.EndsWith(".png") ||
                        doc.Entity.ShortFileName.EndsWith(".jpg") ||
                        doc.Entity.ShortFileName.EndsWith(".tiff") ||
                        doc.Entity.ShortFileName.EndsWith(".jpeg") ||
                        doc.Entity.ShortFileName.EndsWith( ".bmp" ) )
                    {
                        var d = ProjectDocumentManager.GeminiContext.ProjectDocuments.Get(1);

                    return Redirect( "~/project/ALL/item/attachment/preview?issueid2=465&fileid=527&height=0&width=0";)
                }
            }*/
            var url = "~/project/ALL/0/documents/download/" + documentid;
            return Redirect(url);
        }
    }
}
