using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto2021.Models;

namespace Proyecto2021.Controllers
{
    public class ProductoImagenController : Controller
    {
        // GET: ProductoImagen
        public ActionResult Index()
        {
            using (var db = new inventariop2021Entities())
            {
                return View(db.producto_imagen.ToList());
            }
                
        }

        public static string NombreProducto(int idProducto)
        {
            using (var db = new inventariop2021Entities())
            {
                return db.producto.Find(idProducto).nombre;
            }
        }

        public ActionResult ListarProducto()
        {
            using (var db = new inventariop2021Entities())
            {
                return PartialView(db.producto.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(producto_imagen producto_imagen)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new inventariop2021Entities())
                {
                    db.producto_imagen.Add(producto_imagen);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error" + ex);
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new inventariop2021Entities())
            {
                producto_imagen producto_imagen = db.producto_imagen.Find(id);
                return View(producto_imagen);
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                using (var db = new inventariop2021Entities())
                {
                    producto_imagen producto_imagen = db.producto_imagen.Where(a => a.id == id).FirstOrDefault();
                    return View(producto_imagen);
                }
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(producto_imagen producto_imagenEdit)
        {
            try
            {
                using (var db = new inventariop2021Entities())
                {
                    var producto_imagen = db.producto_imagen.Find(producto_imagenEdit.id);
                    producto_imagen.id = producto_imagen.id;
                    producto_imagen.id_producto = producto_imagen.id_producto;
                    producto_imagen.imagen = producto_imagen.imagen;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            using (var db = new inventariop2021Entities())
            {
                var producto_imagenDel = db.producto_imagen.Find(id);
                db.producto_imagen.Remove(producto_imagenDel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}