using S2021A6FH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2021A6FH.Controllers
{
    public class ArtistController : Controller
    {
        Manager manager = new Manager();

        // GET: Artist
        [Authorize(Roles = "Executive, Coordinator, Clerk, Staff")]
        public ActionResult Index()
        {
            return View(manager.ArtistGetAll());
        }

        // GET: Artist/Details/5
        [Authorize(Roles = "Executive, Coordinator, Clerk, Staff")]
        public ActionResult Details(int id)
        {
            return View(manager.ArtistByID(id));
        }

        // GET: Artist/Create
        [Authorize(Roles = "Executive")]
        public ActionResult Create()
        {
            var artist = new ArtistAddFormViewModel();

            artist.Executive = User.Identity.Name;
            artist.ArtistGenreList = new SelectList(manager.GenreGetAll(), "Name", "Name");
            return View(artist);
        }

        // POST: Artist/Create
        [HttpPost]
        [Authorize(Roles = "Executive")]
        public ActionResult Create(ArtistAddViewModel artist)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View(artist);
                }

                var addedArtist = manager.ArtistAdd(artist);

                if (addedArtist == null)
                {
                    return View(addedArtist);
                }
                else
                {
                    return RedirectToAction("details", new { id = addedArtist.Id });
                }
            }
            catch
            {
                return View(artist);
            }
        }


        // GET: Artists/Create
        [Authorize(Roles = "Coordinator")]
        [Route("artists/{id}/addalbum")]
        public ActionResult AddAlbum(int? id)
        {
            var artist = manager.ArtistByID(id.GetValueOrDefault());

            if (artist == null)
            {
                return HttpNotFound();
            }
            else
            {
                var albumAdd = new AlbumAddFormViewModel();
                albumAdd.ArtistId = artist.Id;
                albumAdd.ArtistName = artist.Name;
                albumAdd.AlbumGenreList = new SelectList(manager.GenreGetAll(), "Name", "Name");

                return View(albumAdd);
            }
        }

        // POST: Artists/Create
        //Once user input on the page, this function will be triggered.

        [Authorize(Roles = "Coordinator")]
        [Route("artists/{id}/addalbum")]
        [HttpPost]
        public ActionResult AddAlbum(AlbumAddViewModel album)
        {
            if (!ModelState.IsValid)
            {
                return View(album);
            }
            var addedAlbum = manager.AlbumAdd(album);

            if (addedAlbum == null)
            {
                return View(album);
            }
            else
            {
                return RedirectToAction("details", "Album", new { id = addedAlbum.Id });
            }
        }

        [Authorize(Roles = "Executive, Coordinator")]
        [Route("artist/{id}/addmedia")]
        public ActionResult ArtistAddMedia(int? id)
        {
            var artist = manager.ArtistByID(id.GetValueOrDefault());

            if (artist == null)
            {
                return HttpNotFound();
            }
            else
            {
                var mediaForm = new ArtistMediaItemAddFormViewModel();

                mediaForm.ArtistId = artist.Id;
                mediaForm.ArtistName = artist.Name;

                return View(mediaForm);
            }

        }

        [HttpPost]
        [Authorize(Roles = "Executive, Coordinator"), Route("artist/{id}/addmedia")]
        public ActionResult ArtistAddMedia(int? id, ArtistMediaItemAddViewModel newMedia)
        {
            try
            {
                if (!ModelState.IsValid && id.GetValueOrDefault() == newMedia.ArtistId)
                {
                    return View(newMedia);
                }

                var artistMedia = manager.ArtistMediaAdd(newMedia);

                if (artistMedia == null)
                {
                    return View(newMedia);
                }
                else
                {
                    return RedirectToAction("details", "artist", new { id = artistMedia.Id });
                }

            }
            catch
            {
                return View();
            }

        }



    }
}
