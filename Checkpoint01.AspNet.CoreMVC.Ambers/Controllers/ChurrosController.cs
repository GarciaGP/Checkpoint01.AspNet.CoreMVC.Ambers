using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Checkpoint01.AspNet.CoreMVC.Ambers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Checkpoint01.AspNet.CoreMVC.Ambers.Controllers
{
    public class ChurrosController : Controller
    {
        private static List<Churros> _banco = new List<Churros>();
        private static int id;

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
            churros.Id = ++id;
            churros.DataDeCriacao = DateTime.Now;
            _banco.Add(churros);
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
            _banco[_banco.FindIndex(churros => churros.Id == churros.Id)] = churros;
            TempData["msg"] = "Cardápio atualizado!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            CarregarCoberturas();
            CarregarRecheios();
            var churros = _banco.Find(carro => carro.Id == id);
            return View(churros);
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            _banco.RemoveAt(_banco.FindIndex(v => v.Id == id));
            TempData["msg"] = "Item removido do cardápio!";
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View(_banco);
        }

        #region Métodos auxiliares
        private void CarregarCoberturas()
        {
            // Preencher através de consulta do banco
            ViewBag.Coberturas = new SelectList(new List<string>(new string[] { "Chocolate", "Doce de Leite", "Prestígio" }));
        }

        private void CarregarRecheios()
        {
            // Preencher através de consulta do banco
            ViewBag.Recheios = new SelectList(new List<string>(new string[] { "Chocolate", "Doce de Leite", "Prestígio", "Morango" }));
        }
        #endregion


    }
}
