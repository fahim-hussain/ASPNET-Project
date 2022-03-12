using S2021A6FH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2021A6FH.Controllers
{
    public class TrackController : Controller
    {
        Manager manager = new Manager();

        // GET: Track
        [Authorize(Roles = "Executive, Coordinator, Clerk, Staff")]
        public ActionResult Index()
        {
            return View(manager.TrackGetAll());
        }

        // GET: Track/Details/5
        [Authorize(Roles = "Executive, Coordinator, Clerk, Staff")]
        public ActionResult Details(int id)
        {
            return View(manager.TrackGetOne(id));
        }

        [Authorize(Roles = "Executive, Coordinator, Clerk, Staff")]
        public ActionResult Clip(int? id)
        {
            var clip = manager.TrackGetAudio(id.GetValueOrDefault());

            if (clip == null)
            {
                return HttpNotFound();
            }
            else
            {

                if (clip.AudioContentType != null)
                {
                    return File(clip.Audio, clip.AudioContentType);
                }
                else
                {

                    return Content("No audio");
                }
            }
        }

        // GET: Track/Edit/5
        [Authorize(Roles = "Clerk")]
        public ActionResult Edit(int? id)
        {
            var track = manager.TrackGetOne(id.GetValueOrDefault());

            if (track == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = manager.mapper.Map<TrackWithDetailViewModel, TrackEditFormViewModel>(track);
                return View(form);
            }
        }

        // POST: Track/Edit/5
        [HttpPost]
        [Authorize(Roles = "Clerk")]
        public ActionResult Edit(int? id, TrackEditViewModel editTrack)
        {
            try
            {
                // TODO: Add update logic here

                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Edit", new { id = editTrack.Id });
                }
                else if (id.GetValueOrDefault() != editTrack.Id)
                {
                    return RedirectToAction("Index");
                }

                var editedTrack = manager.TrackEdit(editTrack);

                if (editTrack == null)
                {
                    return RedirectToAction("Edit", new { id = editTrack.Id });
                }
                else
                {
                    return RedirectToAction("Details", new { id = editTrack.Id });
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Track/Delete/5
        [Authorize(Roles = "Clerk")]
        public ActionResult Delete(int? id)
        {
            var trackDelete = manager.TrackGetOne(id.GetValueOrDefault());

            if (trackDelete == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(trackDelete);
            }
        }

        // POST: Track/Delete/5
        [HttpPost]
        [Authorize(Roles = "Clerk")]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                manager.TrackDelete(id.GetValueOrDefault());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
