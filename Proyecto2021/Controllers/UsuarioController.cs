using Proyecto2021.Models;
using System.Linq;
using System.Web.Mvc;

namespace Proyecto2021.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()

        {
            using (var db = new inventariop2021Entities())
            {
                return View(db.usuario.ToList());
            }

        }
    }
}