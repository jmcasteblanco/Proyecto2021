using Proyecto2021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto2021.Controllers
{
    public class CompraController : Controller
    {
        // GET: Compra
        public ActionResult Index()
        {
            using (var db = new inventariop2021Entities())
            {
                return View(db.compra.ToList());
            }
                
        }

        public static string NombreUsuario(int idUsuario)
        {
            using (var db= new inventariop2021Entities())
            {
                return db.usuario.Find(idUsuario).nombre;
            }
        }

          public ActionResult ListarUsuario()
        {
            using (var db = new inventariop2021Entities())
            {
                return PartialView(db.usuario.ToList());
            }
        }

          public static string NombreCliente(int idcliente)
        {
            using (var db = new inventariop2021Entities())
            {
                return db.cliente.Find(idcliente).nombre;
            }
        }

           public ActionResult ListarCliente()
        {
            using (var db = new inventariop2021Entities())
            {
                return PartialView(db.cliente.ToList());
            }
        }

          public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public ActionResult Create(compra compra)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new inventariop2021Entities())
                {
                    db.compra.Add(compra);
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
                compra compra = db.compra.Find(id);
                return View(compra);
            }
        }
          
         public ActionResult Edit(int id)
        {
            try
            {
                using (var db = new inventariop2021Entities())
                {
                    compra compra = db.compra.Where(a => a.id == id).FirstOrDefault();
                    return View(compra);
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

        public ActionResult Edit(compra compraEdit)
        {
            try
            {
                using (var db = new inventariop2021Entities())
                {
                    var compra = db.compra.Find(compraEdit.id);
                    compra.id = compraEdit.id;
                    compra.fecha = compraEdit.fecha;
                    compra.id_cliente = compraEdit.id_cliente;
                    compra.id_usuario = compraEdit.id_usuario;
                    compra.total = compraEdit.total;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

                   catch(Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }

             public ActionResult Delete(int id)
        {
            using (var db = new inventariop2021Entities())
            {
                var compraDel = db.compra.Find(id);
                db.compra.Remove(compraDel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
         

    }
}