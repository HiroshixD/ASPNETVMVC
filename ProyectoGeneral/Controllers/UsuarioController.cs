using System;
using Entidades;
using Negocio.Repositorios;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace ProyectoGeneral.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioRepositorio _repo;

        public UsuarioController()
        {
            _repo = new UsuarioRepositorio();
        }
        //
        // GET: /Usuario/
        public ActionResult Index()
        {
            var data = _repo.ListarUsuarios();
            return View();
        }
        public ActionResult ListarTodos()
        {
            var data = _repo.ListarUsuarios();
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        //
        // GET: /Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                id = 1;
            var data = _repo.BuscarPorId(id);
            return View(data);
        }

        //
        // GET: /Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repo.Crear(model);
                    return Json(model, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var errors = ModelState.Values
                                                .SelectMany(v => v.Errors)
                                                .Select(e => e.ErrorMessage);
                    var listErrors = errors.ToList();
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json(listErrors, JsonRequestBehavior.AllowGet);
                }

            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Usuario/Edit/5
        public ActionResult Edit()
        {
        
            return View();

        }

        public ActionResult SearchForId(int id)
        {
            var data = _repo.BuscarPorId(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //
        // POST: /Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario model)
        {
            var id = model.Id;
            try
            {
                if (ModelState.IsValid)
                {
                    _repo.Actualizar(id, model);
                    return Json(model, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var errors = ModelState.Select(x => x.Value.Errors)
                        .Where(y => y.Count > 0)
                        .ToList();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Usuario/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        //
        // POST: /Usuario/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Usuario model)
        {
            id = model.Id;
            try
            {
                _repo.Eliminar(id);
                return Json(model, JsonRequestBehavior.AllowGet);

            }
            catch
            {
                var errors = ModelState.Values
                                            .SelectMany(v => v.Errors)
                                            .Select(e => e.ErrorMessage);
                var listErrors = errors.ToList();
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(listErrors, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
