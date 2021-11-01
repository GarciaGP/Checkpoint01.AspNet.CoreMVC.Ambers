using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Checkpoint01.AspNet.CoreMVC.Ambers.Models;
using Checkpoint01.AspNet.CoreMVC.Ambers.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Checkpoint01.AspNet.CoreMVC.Ambers.Controllers
{
    public class ChurrosController : Controller
    {
        private IChurrosContext _context;

        public ChurrosController(IChurrosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            CarregarCoberturas();
            CarregarRecheios();
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Churros churros)
        {
            churros.DataDeCriacao = DateTime.Now;
            _context.Churros.Add(churros);
            _context.SaveChanges();
            //Mensagem de sucesso
            TempData["msg"] = "Item adicionado ao cardápio!";
            //Redirect
            return RedirectToAction("cadastrar");
        }

        [HttpPost]
        public IActionResult Editar(Churros churros)
        {
            CarregarCoberturas();
            CarregarRecheios();
            churros.DataDeAlteracao = DateTime.Now;
            _context.Churros.Add(churros);
            _context.SaveChanges();
            TempData["msg"] = "Cardápio atualizado!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            CarregarCoberturas();
            CarregarRecheios();
            var churros = _context.Churros.Where(c => c.Id == id).FirstOrDefault();
            return View(churros);
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            var churros = _context.Churros.Where(c => c.Id == id).FirstOrDefault();
            _context.Churros.Remove(churros);
            TempData["msg"] = "Item removido do cardápio!";
            return RedirectToAction("Index");
        }

        public IActionResult Index(string coberturaBusca)
        {
            var listaChurros = _context.Churros.Where(c => c.Cobertura.Descricao.Contains(coberturaBusca) || coberturaBusca == null)
                .Include(c => c.Cobertura)
                .Include(c => c.Recheio)
                .ToList();
            return View(listaChurros);
        }

        #region Métodos auxiliares
        private void CarregarCoberturas()
        {
            // Preencher através de consulta do banco
            var coberturasFiltradas = FiltrarCoberturasDisponiveis();
            ViewBag.Coberturas = new SelectList(coberturasFiltradas, "CoberturaId", "Descricao");
        }

        private void CarregarRecheios()
        {
            // Preencher através de consulta do banco
            var recheios = _context.Recheios.ToList();
            ViewBag.Recheios = new SelectList(recheios, "RecheioId", "Descricao");
        }

        // Filtro para não exibir as coberturas que já foram utilizadas em algum churros
        private IEnumerable<Cobertura> FiltrarCoberturasDisponiveis()
        {
            var churros = _context.Churros.ToList();
            var coberturas = _context.Coberturas.ToList();
            var listaFiltrada = coberturas.Where(c => !churros.Exists(ch => ch.CoberturaId == c.CoberturaId));
            return listaFiltrada;
        }

        #endregion


    }
}
