using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Checkpoint01.AspNet.CoreMVC.Ambers.Models;
using Checkpoint01.AspNet.CoreMVC.Ambers.Persistencia;
using Microsoft.AspNetCore.Mvc;

namespace Checkpoint01.AspNet.CoreMVC.Ambers.Controllers
{
    public class RecheioController : Controller
    {

        private IChurrosContext _context;

        public RecheioController(IChurrosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Recheio Recheio)
        {
            //Mensagem de sucesso
            _context.Recheios.Add(Recheio);
            _context.SaveChanges();
            TempData["msg"] = "Item adicionado ao cardápio!";
            return RedirectToAction("cadastrar");
        }

        public IActionResult Editar(int id)
        {
            var Recheio = _context.Recheios.Where(c => c.RecheioId == id).FirstOrDefault();
            return View(Recheio);
        }

        public IActionResult Editar(Recheio Recheio)
        {
            _context.Recheios.Update(Recheio);
            _context.SaveChanges();
            return View(Recheio);
        }

        public IActionResult Remover(int id)
        {
            var Recheio = _context.Recheios.Where(c => c.RecheioId == id).FirstOrDefault();
            _context.Recheios.Remove(Recheio);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
