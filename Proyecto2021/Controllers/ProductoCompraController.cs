using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto2021.Models;

namespace Proyecto2021.Controllers
{
    public class ProductoCompraController : Controller
    {
        // GET: ProductoCompra
        public ActionResult Index()
        {
            using (var db = new inventariop2021Entities())
            {
                return View(db.producto_compra.ToList());
            }
                
        }
        public static int CompraProducto(int idCompra)
        {
            using (var db = new inventariop2021Entities())
            {
                return db.compra.Find(idCompra).total;
            }
        }

        public ActionResult ListarCompra()
        {
            using (var db = new inventariop2021Entities())
            {
                return PartialView(db.compra.ToList());
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

        public ActionResult Create(producto_compra producto_compra)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new inventariop2021Entities())
                {
                    db.producto_compra.Add(producto_compra);
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
                producto_compra producto_compra = db.producto_compra.Find(id);
                return View(producto_compra);
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                using (var db = new inventariop2021Entities())
                {
                    producto_compra producto_compra = db.producto_compra.Where(a => a.id == id).FirstOrDefault();
                    return View(producto_compra);
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

        public ActionResult Edit(producto_compra producto_compraEdit)
        {
            try
            {
                using (var db = new inventariop2021Entities())
                {
                    var producto_compra = db.producto_compra.Find(producto_compraEdit.id);
                    producto_compra.id = producto_compraEdit.id;
                    producto_compra.id_compra = producto_compraEdit.id_compra;
                    producto_compra.id_producto = producto_compraEdit.id_producto;
                    producto_compra.cantidad = producto_compra.cantidad;
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
                var producto_compraDel = db.producto_compra.Find(id);
                db.producto_compra.Remove(producto_compraDel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
}