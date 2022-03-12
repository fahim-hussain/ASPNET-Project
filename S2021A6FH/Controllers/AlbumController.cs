using S2021A6FH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2021A6FH.Controllers
{
    public class AlbumController : Controller
    {
        Manager manager = new Manager();

        // GET: Album
        [Authorize(Roles = "Executive, Coordinator, Clerk, Staff")]
        public ActionResult Index()
        {
            return View(manager.AlbumGetAll());
        }

        // GET: Album/Details/5
        [Authorize(Roles = "Executive, Coordinator, Clerk, Staff")]
        public ActionResult Details(int id)
        {
            return View(manager.AlbumById(id));
        }

        [Authorize(Roles = "Clerk")]
        [Route("album/{id}/addtrack")]
        public ActionResult AddTrack(int? id)
        {
            var album = manager.AlbumById(id.GetValueOrDefault());

            if (album == null)
            {
                return HttpNotFound();
            }
            else
            {
                var trackAdd = new TrackAddFormViewModel();
                trackAdd.AlbumId = album.Id;
                trackAdd.AlbumName = album.Name;
                trackAdd.TrackGenreList = new SelectList(manager.GenreGetAll(), "Name", "Name");

                return View(trackAdd);
            }
        }

        [Authorize(Roles = "Clerk")]
        [Route("album/{id}/addtrack")]
        [HttpPost]
        public ActionResult AddTrack(TrackAddViewModel track)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(track);
                }

                var addedTrack = manager.TrackAdd(track);

                if (addedTrack == null)
                {
                    return View(track);
                }
                else
                {
                    return RedirectToAction("details", "Track", new { id = addedTrack.Id });
                }
            }
            catch
            {
                return View();
            }
        }

    }
}
