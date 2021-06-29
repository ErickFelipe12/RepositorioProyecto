using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repositorio1.Models;
using Rotativa;

namespace Repositorio1.Controllers
{
    public class CompraController : Controller
    {
        // GET: Compra
        public ActionResult Index()
        {
            using (var db = new inventario2021Entities1())
                return View(db.compra.ToList());
        }
        //public static string Nombreproveedor(int idProveedor)
        //{
        //    using (var db = new inventario2021Entities1())
        //    {
        //        return db.proveedor.Find(idProveedor).nombre;
        //    }
        //}
        public static string Nombrecliente(int idcliente)
        {
            using (var db = new inventario2021Entities1())
            {
                return db.cliente.Find(idcliente).nombre;
            }
        }
        public static string Nombreusuario(int idusuario)
        {
            using (var db = new inventario2021Entities1())
            {
                return db.usuario.Find(idusuario).nombre;
            }
        }
        public ActionResult ListarClientes()
        {
            using (var db = new inventario2021Entities1())
            {
                return PartialView(db.cliente.ToList());
            }
        }

        public ActionResult ListarUsuarios()
        {
            using (var db = new inventario2021Entities1())
            {
                return PartialView(db.usuario.ToList());
            }
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(compra newCompra)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario2021Entities1())
                {
                    db.compra.Add(newCompra);
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
                var compraDelete = db.compra.Find(id);
                db.compra.Remove(compraDelete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Details(int id)
        {
            using (var db = new inventario2021Entities1())
            {
                compra compraDetalle = db.compra.Where(a => a.id == id).FirstOrDefault();
                return View(compraDetalle);
            }
        }
        public ActionResult Edit(int id)
        {
            try
            {
                using (var db = new inventario2021Entities1())
                {
                    compra compra = db.compra.Where(a => a.id == id).FirstOrDefault();
                    return View(compra);

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
        public ActionResult Edit(compra compraEdit)
        {
            try
            {
                using (var db = new inventario2021Entities1())
                {
                    var compra = db.compra.Find(compraEdit.id);
                    compra.fecha = compraEdit.fecha;
                    compra.total = compraEdit.total;
                    compra.id_usuario = compraEdit.id_usuario;
                    compra.cliente = compraEdit.cliente;

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

        public ActionResult ReporteCompra()
        {
            try
            {
                var db = new inventario2021Entities1();
                var query = from tabCliente in db.cliente
                            join tabCompra in db.compra on tabCliente.id equals tabCompra.id_cliente
                            select new ReporteCompra
                            {
                                nombreCliente = tabCliente.nombre,
                                documentoCliente = tabCliente.documento,
                                emailCliente = tabCliente.email,
                                fechaCompra = tabCompra.fecha,
                                totalCompra = tabCompra.total
                            };
                return View(query);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error" + ex);
                return View();
            }
        }
        public ActionResult ImprimirReporteCompra()
        {
            return new ActionAsPdf("ReporteCompra") { FileName = "ReporteCompra.pdf" };
        }
    }
}