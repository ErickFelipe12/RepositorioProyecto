﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repositorio1.Models;
using Rotativa;

namespace Repositorio1.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        [Authorize]
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
            if (!ModelState.IsValid)
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

       
        public ActionResult Details(int id)
        {
            using (var db = new inventario2021Entities1())
            {
                producto productoDetalle = db.producto.Where(a => a.id == id).FirstOrDefault();
                return View(productoDetalle);
            }
        }

        public ActionResult Delete(int id)
        {
            using (var db = new inventario2021Entities1())
            {

                var productDelete = db.producto.Find(id);
                db.producto.Remove(productDelete);
                db.SaveChanges();
                return RedirectToAction("index");
            }

        }
        
        public ActionResult Edit(int id)
        {
            try
            {
                using (var db= new inventario2021Entities1())
                {
                    producto findUser= db.producto.Where(a => a.id == id).FirstOrDefault();
                    return View(findUser);

                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                    return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(producto productoEdit)
        {
            try
            {
                using (var db = new inventario2021Entities1())
                {
                    var producto = db.producto.Find(productoEdit.id);
                    producto.nombre = productoEdit.nombre;
                    producto.percio_unitario = productoEdit.percio_unitario;
                    producto.cantidad = productoEdit.cantidad;
                    producto.descripcion = productoEdit.descripcion;
                    producto.id_proveedor = productoEdit.id_proveedor;

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

        public ActionResult Reporte()
        {
            try
            {
                var db = new inventario2021Entities1();
                var query = from tabProveedor in db.proveedor
                            join tabProducto in db.producto on tabProveedor.id equals tabProducto.id_proveedor
                            select new Reporte
                            {
                                nombreProveedor = tabProveedor.nombre,
                                telefonoProveedor = tabProveedor.telefono,
                                direccionProveedor = tabProveedor.direccion,
                                nombreProducto = tabProducto.nombre,
                                precioProducto = tabProducto.percio_unitario

                            };
                return View(query);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Error" + ex);
                return View();
            }
        }

        public ActionResult ImprimirReporte()
        {
            return new ActionAsPdf("Reporte") { FileName = "reporte.pdf" };
        }
    }
}