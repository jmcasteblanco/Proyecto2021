using Proyecto2021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto2021.Controllers
{
    public class ProveedorController : Controller
    {
        // GET: Proveedor
        public ActionResult Index()
        {
            using (var db =new inventariop2021Entities())
            {
                return View(db.proveedor.ToList());
            }
            
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(proveedor proveedor)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new inventariop2021Entities())
                {
                    db.proveedor.Add(proveedor);
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

        public ActionResult Details(int id)
        {
            using (var db = new inventariop2021Entities())
            {
                proveedor proveedor = db.proveedor.Find(id);
                return View(proveedor);
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                using (var db = new inventariop2021Entities())
                {
                    proveedor proveedor = db.proveedor.Where(a => a.id == id).FirstOrDefault();
                    return View(proveedor);
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

        public ActionResult Edit(proveedor proveedorEdit)
        {
            try
            {
                using (var db = new inventariop2021Entities())
                {
                    var proveedor = db.proveedor.Find(proveedorEdit.id);
                    proveedor.nombre = proveedorEdit.nombre;
                    proveedor.direccion = proveedorEdit.direccion;
                    proveedor.telefono = proveedorEdit.telefono;
                    proveedor.id = proveedorEdit.id;
                    proveedor.nombre_contacto = proveedorEdit.nombre_contacto;
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
                var proveedorDel = db.proveedor.Find(id);
                db.proveedor.Remove(proveedorDel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult uploadCSV()
        {
            return View();
        }


    }
}