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
                return View();
            }
        }

        public static string Nombreproveedor(int idProveedor)
        {
            using (var db = new inventario2021Entities1())
            {
                return db.producto.Find(idProveedor).nombre;
            }
        }
    }
}