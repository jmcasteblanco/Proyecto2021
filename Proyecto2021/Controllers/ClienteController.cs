using Proyecto2021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto2021.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
          using (var db = new inventariop2021Entities())
            {
                return View(db.cliente.ToList());
            }  
            
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(cliente cliente)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new inventariop2021Entities())
                {
                    db.cliente.Add(cliente);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }catch(Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new inventariop2021Entities())
            {
                cliente cliente = db.cliente.Find(id);
                return View(cliente);
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                using(var db = new inventariop2021Entities())
                {
                    cliente cliente = db.cliente.Where(a => a.id == id).FirstOrDefault();
                    return View(cliente);
                }
            }catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(cliente clienteEdit)
        {
            try
            {
                using (var db = new inventariop2021Entities())
                {
                    var Cliente = db.cliente.Find(clienteEdit.id);
                    Cliente.nombre = clienteEdit.nombre;
                    Cliente.documento = clienteEdit.documento;
                    Cliente.id = clienteEdit.id;
                    Cliente.email = clienteEdit.email;
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
                var clienteDel = db.cliente.Find(id);
                db.cliente.Remove(clienteDel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
       
}