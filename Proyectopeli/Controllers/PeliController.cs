﻿using Proyectopeli.Controllers;
using Proyectopeli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyectopeli.Controllers
{
    [ValueReporter]
    public class PeliController : Controller
    {
        private Peliculadb context = new Peliculadb();

        // GET: Photo
        public ActionResult Index()
        {
            return View("Index");
        }

        [ChildActionOnly]
        public ActionResult _PhotoGallery(int number = 0)
        {
            List<Pelicula> pelicula;
            if (number == 0)
            {
                pelicula = context.Pelicula.ToList();
            }
            else
            {
                pelicula = (from p in context.Pelicula orderby p.Fecha_estreno descending select p).Take(number).ToList();
            }

            return PartialView("_PhotoGallery", pelicula);
        }

        public ActionResult Display(int id)
        {
            Pelicula pelicula = context.Pelicula.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }

            return View("Display", pelicula);
        }

        public ActionResult Create()
        {
            Pelicula newpelicula = new Pelicula();
            newpelicula.Fecha_estreno = DateTime.Today;

            return View("Create", newpelicula);
        }

        [HttpPost]
        public ActionResult Create(Pelicula pelicula, HttpPostedFileBase image)
        {
            pelicula.Fecha_estreno = DateTime.Today;

            if (!ModelState.IsValid)
            {
                return View("Create", pelicula);
            }
            else
            {
                if (image != null)
                {
                    pelicula.ImageMimeType = image.ContentType;
                    pelicula.Poster = new byte[image.ContentLength];
                    image.InputStream.Read(pelicula.Poster, 0, image.ContentLength);
                }

                context.Pelicula.Add(pelicula);
                context.SaveChanges();
                return RedirectToAction("Index");

            }
        }

        public ActionResult Delete(int id)
        {
            Pelicula pelicula = context.Pelicula.Find(id);

            if (pelicula == null)
            {
                return HttpNotFound();
            }

            return View("Delete", pelicula);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Pelicula pelicula = context.Pelicula.Find(id);

            context.Pelicula.Remove(pelicula);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        public FileContentResult GetImage(int id)
        {
            Pelicula pelicula = context.Pelicula.Find(id);

            if (pelicula != null)
            {
                return File(pelicula.Poster, pelicula.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}