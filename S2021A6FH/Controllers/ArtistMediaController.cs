using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2021A6FH.Controllers
{
    public class ArtistMediaController : Controller
    {
        Manager manager = new Manager();

        public ActionResult Index()
        {
            return RedirectToAction("index", "home");
        }

        [Route("artistmedia/{stringId}")]
        public ActionResult media(string stringId = "")
        {
            var media = manager.ArtistMediabyID(stringId);

            if (media == null)
            {
                return HttpNotFound();
            }
            else
            {
                return File(media.Content, media.ContentType);
            }
        }
        [Route("artistmedia/{stringId}/download")]
        public ActionResult mediaDownload(string stringId = "")
        {
            var media = manager.ArtistMediabyID(stringId);

            if (media == null)
            {
                return HttpNotFound();
            }
            else
            {
                // Working variables
                string extension;
                RegistryKey key;
                object value;

                // Open the Registry, attempt to locate the key
                key = Registry.ClassesRoot.OpenSubKey(@"MIME\Database\Content Type\" + media.ContentType, false);
                // Attempt to read the value of the key
                value = (key == null) ? null : key.GetValue("Extension", null);
                // Build/create the file extension string
                extension = (value == null) ? string.Empty : value.ToString();

                // Create a new Content-Disposition header
                var cd = new System.Net.Mime.ContentDisposition
                {
                    // Assemble the file name + extension
                    FileName = $"img-{stringId}{extension}",
                    // Force the media item to be saved (not viewed)
                    Inline = false
                };
                // Add the header to the response
                Response.AppendHeader("Content-Disposition", cd.ToString());

                return File(media.Content, media.ContentType);
            }
        }

    }
}
