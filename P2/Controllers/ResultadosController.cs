using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P2.Models;

namespace P2.Controllers
{
    public class ResultadosController : Controller
    {
        private ModelResultado model;

        // GET: Resultados
        public ActionResult Index()
        {
            List<property> ListResultados = new List<property>();
            model = new ModelResultado();
            ListResultados = model.findAll();
            return View(ListResultados);
        }
        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public JsonResult Create(property _property) {
            if (ModelState.IsValid) {
                model = new ModelResultado();
                model.save(_property);
                return Json("add successufully", JsonRequestBehavior.AllowGet);
            }
            return Json("Error", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id) {
            model = new ModelResultado();
            model.delete(id);
            return RedirectToAction("Index");
        }
    }
}