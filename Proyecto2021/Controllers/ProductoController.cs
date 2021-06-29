using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto2021.Models;

namespace Proyecto2021.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            using (var db = new inventariop2021Entities())
            {
                return View(db.producto.ToList());
            }
            
        }

        public static string NombreProveedor(int idProveedor)
        {
            using (var db = new inventariop2021Entities())
            {
                return db.proveedor.Find(idProveedor).nombre;
            }
        }

        public ActionResult ListarProveedores()
        {
            using (var db = new inventariop2021Entities())
            {
                return PartialView(db.proveedor.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(producto newProducto)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventariop2021Entities())
                {
                    db.producto.Add(newProducto);
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


    }
}