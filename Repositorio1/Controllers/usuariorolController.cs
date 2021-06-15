using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repositorio1.Models;

namespace Repositorio1.Controllers
{
    public class usuariorolController : Controller
    {
        // GET: usuariorol

        
        
            // GET: producto_compra
            public ActionResult Index()
            {
                using (var db = new inventario2021Entities1())
                    return View(db.usuariorol.ToList());
            }
            public ActionResult Create()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(usuariorol newusuariorol)
            {
                if (!ModelState.IsValid)
                    return View();

                try
                {
                    using (var db = new inventario2021Entities1())
                    {
                        db.usuariorol.Add(newusuariorol);
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
                using (var db = new inventario2021Entities1())
                {
                    var usuariorol = db.usuariorol.Find(id);
                    db.usuariorol.Remove(usuariorol);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            public ActionResult Details(int id)
            {
                using (var db = new inventario2021Entities1())
                {
                    usuariorol usuariorolDetalle = db.usuariorol.Where(a => a.id == id).FirstOrDefault();
                    return View(usuariorolDetalle);
                }


            }
            public ActionResult Edit(int id)
            {
                try
                {
                    using (var db = new inventario2021Entities1())
                    {
                        usuariorol usuariorol = db.usuariorol.Where(a => a.id == id).FirstOrDefault();
                        return View(usuariorol);

                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "ERROR" + ex);
                    return View();
                }
            }
            public ActionResult Edit(usuariorol usuariorolEdit)
            {
                try
                {
                    using (var db = new inventario2021Entities1())
                    {
                        var usuariorol = db.usuariorol.Find(usuariorolEdit.id);
                        usuariorol.idUsuario = usuariorolEdit.idUsuario;
                        usuariorol.idUsuario = usuariorolEdit.idUsuario;
                        usuariorol.idRol = usuariorolEdit.idRol;


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