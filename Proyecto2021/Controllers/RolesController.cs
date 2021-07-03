using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto2021.Models;

namespace Proyecto2021.Controllers
{
    public class RolesController : Controller
    {
        // GET: Roles
        public ActionResult Index()
        {
            using (var db = new inventariop2021Entities())
            {
                return View(db.roles.ToList());
            }
                
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(roles roles)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new inventariop2021Entities())
                {
                    db.roles.Add(roles);
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
                roles roles = db.roles.Find(id);
                return View(roles);
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                using (var db = new inventariop2021Entities())
                {
                    roles roles = db.roles.Where(a => a.id == id).FirstOrDefault();
                    return View(roles);
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

        public ActionResult Edit(roles rolesEdit)
        {
            try
            {
                using (var db = new inventariop2021Entities())
                {
                    var roles = db.roles.Find(rolesEdit.id);
                    roles.id = rolesEdit.id;
                    roles.descripcion = rolesEdit.descripcion;
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
                var rolesDel = db.roles.Find(id);
                db.roles.Remove(rolesDel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
}