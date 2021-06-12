using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repositorio1.Models;

namespace Repositorio1.Controllers
{
    public class producto_compraController : Controller
    {
        // GET: producto_compra
        public ActionResult Index()
        {
            using (var db = new inventario2021Entities1())
                return View(db.producto_compra.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(producto_compra newproducto_Compra)
        {
            if (ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario2021Entities1())
                {
                    db.producto_compra.Add(newproducto_Compra);
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
                var producto_compra = db.producto_compra.Find(id);
                db.producto_compra.Remove(producto_compra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Details(int id)
        {
            using (var db = new inventario2021Entities1())
            {
                producto_compra producto_compraDetalle = db.producto_compra.Where(a => a.id == id).FirstOrDefault();
                return View(producto_compraDetalle);
            }


        }
        public ActionResult Edit(int id)
        {
            try
            {
                using (var db = new inventario2021Entities1())
                {
                    producto_compra producto_compra = db.producto_compra.Where(a => a.id == id).FirstOrDefault();
                    return View(producto_compra);

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "ERROR" + ex);
                return View();
            }
        }
        public ActionResult Edit(producto_compra producto_compraEdit)
        {
            try
            {
                using (var db = new inventario2021Entities1())
                {
                    var producto_compra = db.producto_compra.Find(producto_compraEdit.id);
                    producto_compra.id_compra = producto_compraEdit.id_compra;
                    producto_compra.id_producto = producto_compraEdit.id_producto;
                    producto_compra.cantidad = producto_compraEdit.cantidad;

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