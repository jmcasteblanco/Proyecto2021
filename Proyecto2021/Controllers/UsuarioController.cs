using Proyecto2021.Models;
using System;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;

namespace Proyecto2021.Controllers
{
    public class UsuarioController : Controller
    {

        [Authorize]
        // GET: Usuario
        public ActionResult Index()

        {
            using (var db = new inventariop2021Entities())
            {
                return View(db.usuario.ToList());
            }

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(usuario usuario)
        {
            if (!ModelState.IsValid)
                return View();

            try { 
                using (var db = new inventariop2021Entities())
                {
                    usuario.password = UsuarioController.HashSHA1(usuario.password);
                    db.usuario.Add(usuario);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                 }
            }catch(Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }

        public static string HashSHA1(string value)
        {
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var inputBytes = Encoding.ASCII.GetBytes(value);
            var hash = sha1.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }

            return sb.ToString();
        }

        public ActionResult Edit(int id)
        {
            try
            {
                using (var db = new inventariop2021Entities())
                {
                    usuario findUser = db.usuario.Where(a => a.id == id).FirstOrDefault();
                    return View(findUser);
                }
            }
            catch(Exception ex)
              
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(usuario usuarioedit)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventariop2021Entities())
                {
                    usuario user = db.usuario.Find(usuarioedit.id);

                    user.nombre = usuarioedit.nombre;
                    user.apellido = usuarioedit.apellido;
                    user.email = usuarioedit.email;
                    user.fecha_nacimiento = usuarioedit.fecha_nacimiento;
                    user.password = usuarioedit.password;

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
                usuario user = db.usuario.Find(id);
                return View(user);
            }
        }


        public ActionResult Delete(int id)
        {
            using (var db = new inventariop2021Entities())
            {
                var usuario = db.usuario.Find(id);
                db.usuario.Remove(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Login(string message ="")
        {
            ViewBag.Message = message; 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email,string password)
        {
            string passEncrip = UsuarioController.HashSHA1(password);
            using (var db = new inventariop2021Entities())
            {
                var userLogin = db.usuario.FirstOrDefault(e => e.email == email && e.password == passEncrip);
                if(userLogin != null)
                {
                    FormsAuthentication.SetAuthCookie(userLogin.email, true);
                    Session["User"] = userLogin;
                    return RedirectToAction("Index");
                }
                else
                {
                    return Login("Verifique sus datos");
                }
            }
        }

        [Authorize]

        public ActionResult CloseSession()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}