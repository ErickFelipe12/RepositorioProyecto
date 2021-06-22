using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repositorio1.Models;

namespace Repositorio1.Controllers
{
    public class producto_imagenController : Controller
    {
        // GET: producto_imagen
        public ActionResult Index()
        {
            using (var db = new inventario2021Entities1())
                return View(db.producto_imagen.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(producto_imagen newproducto_imagen)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario2021Entities1())
                {
                    db.producto_imagen.Add(newproducto_imagen);
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
        public static string Nombreproducto(int idproducto)
        {
            using (var db = new inventario2021Entities1())
            {
                return db.producto.Find(idproducto).nombre;
            }
        }
        public ActionResult Listarproducto()
        {
            using (var db = new inventario2021Entities1())
            {
                return PartialView(db.producto.ToList());
            }
        }

        public ActionResult Delete(int id)
        {
            using (var db = new inventario2021Entities1())
            {
                var producto_imagenDelete = db.producto_imagen.Find(id);
                db.producto_imagen.Remove(producto_imagenDelete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Details(int id)
        {
            using (var db = new inventario2021Entities1())
            {
                producto_imagen producto_imagenDetalle = db.producto_imagen.Where(a => a.id == id).FirstOrDefault();
                return View(producto_imagenDetalle);
            }


        }
        public ActionResult Edit(int id)
        {
            try
            {
                using (var db = new inventario2021Entities1())
                {
                    producto_imagen producto_imagen = db.producto_imagen.Where(a => a.id == id).FirstOrDefault();
                    return View(producto_imagen);

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "ERROR" + ex);
                return View();
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(producto_imagen producto_imagenEdit)
        {
            try
            {
                using (var db = new inventario2021Entities1())
                {
                    var producto_imagen = db.producto_imagen.Find(producto_imagenEdit.id);
                    producto_imagen.imagen = producto_imagenEdit.imagen;
                    producto_imagen.id_producto = producto_imagenEdit.id_producto;
                    

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