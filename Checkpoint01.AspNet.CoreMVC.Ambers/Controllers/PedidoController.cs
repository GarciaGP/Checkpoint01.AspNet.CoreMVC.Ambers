using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Checkpoint01.AspNet.CoreMVC.Ambers.Persistencia;
using Microsoft.AspNetCore.Mvc;

namespace Checkpoint01.AspNet.CoreMVC.Ambers.Controllers
{
    public class PedidoController : Controller
    {

        private IChurrosContext _context;

        public PedidoController(IChurrosContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar()
        {
            var churrosDisponiveis = _context.Churros.Where(c => c.Disponivel);
            return RedirectToAction("cadastrar");
        }
    }
}
