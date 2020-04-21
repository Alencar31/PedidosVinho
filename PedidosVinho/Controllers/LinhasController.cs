using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PedidosVinho.Models;

namespace PedidosVinho.Controllers
{
    public class LinhasController : Controller
    {
        public IActionResult Index()
        {
            List<Linha> list = new List<Linha>();
            list.Add(new Linha { Id = 1, Codigo = 1, Nome = "CASTELLAMARE" });
            list.Add(new Linha { Id = 2, Codigo = 2, Nome = "SAN DIEGO" });

            return View(list);
        }
    }
}