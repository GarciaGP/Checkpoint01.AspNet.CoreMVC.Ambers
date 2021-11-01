using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Checkpoint01.AspNet.CoreMVC.Ambers.Models;
using Checkpoint01.AspNet.CoreMVC.Ambers.Persistencia;
using Microsoft.AspNetCore.Mvc;

namespace Checkpoint01.AspNet.CoreMVC.Ambers.Controllers
{
    public class CoberturaController : Controller
    {
        private IChurrosContext _context;

        public CoberturaController(IChurrosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Cobertura cobertura)
        {
            _context.Coberturas.Add(cobertura);
            _context.SaveChanges();
            TempData["msg"] = "Item adicionado ao cardápio!";
            return RedirectToAction("cadastrar");
        }

        public IActionResult Editar(int id)
        {
            var cobertura = _context.Coberturas.Where(c => c.CoberturaId == id).FirstOrDefault();
            return View(cobertura);
        }

        public IActionResult Editar(Cobertura cobertura)
        {
            _context.Coberturas.Update(cobertura);
            _context.SaveChanges();
            return View(cobertura);
        }

        public IActionResult Remover(int id)
        {
            var cobertura = _context.Coberturas.Where(c => c.CoberturaId == id).FirstOrDefault();
            _context.Coberturas.Remove(cobertura);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
