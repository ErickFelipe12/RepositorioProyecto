using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repositorio1.Models;

namespace Repositorio1.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            using (var db = new inventario2021Entities1())
            {
                return View(db.producto.ToList());
            }
        }

        public static string Nombreproveedor(int idProveedor)
        {
            using (var db = new inventario2021Entities1())
            {
                return db.proveedor.Find(idProveedor).nombre;
            }
        }

        public ActionResult ListarProveedores()
        {
            using (var db = new inventario2021Entities1())
            {
                return PartialView(db.proveedor.ToList());
            }
        }
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(producto newProducto)
        {
            if (ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario2021Entities1())
                {
                    db.producto.Add(newProducto);
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
                var producto = db.producto.Find(id);
                db.producto.Remove(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Details(int id)
        {
            using (var db = new inventario2021Entities1())
            {
                producto productoDetalle = db.producto.Where(a => a.id == id).FirstOrDefault();
                return View(productoDetalle);
            }
        }
        public ActionResult Edit(int id)
        {
            try
            {
                using (var db= new inventario2021Entities1())
                {
                    producto producto = db.producto.Where(a => a.id == id).FirstOrDefault();
                    return View(producto);

                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "ERROR" + ex);
                    return View();
            }
        }
    }
}