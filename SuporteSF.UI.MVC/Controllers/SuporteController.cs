using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuporteSF.Application.Interfaces;
using SuporteSF.Application.ViewModels;

namespace SuporteSF.UI.MVC.Controllers
{
    public class SuporteController : Controller
    {
        private readonly ISuporteAppService _suporteApp;

        public SuporteController(ISuporteAppService suporteApp)
        {
            _suporteApp = suporteApp;
        }

        // GET: Suporte
        public ActionResult Index()
        {
            return View(_suporteApp.GetAll());
        }

        // GET: Suporte/Details/5
        public ActionResult Details(int id)
        {
            var produtoViewModel = _suporteApp.GetByIdTipoInteiro(id);
            return View(produtoViewModel);
        }

        // GET: Suporte/Create
        public ActionResult Create()
        {
            //ViewBag.FornecedorId = new SelectList(_fornecedorApp.GetAll(), "FornecedorId", "Nome");
            return View();
        }

        // POST: Suporte/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuporteViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                _suporteApp.Add(produtoViewModel);
                return RedirectToAction("Index");
            }

            //ViewBag.FornecedorId = new SelectList(_fornecedorApp.GetAll(), "FornecedorId", "Nome", produtoViewModel.FornecedorId);
            return View(produtoViewModel);
        }

        // GET: Suporte/Edit/5
        public ActionResult Edit(int id)
        {
            var produtoViewModel = _suporteApp.GetByIdTipoInteiro(id);
            //ViewBag.FornecedorId = new SelectList(_fornecedorApp.GetAll(), "FornecedorId", "Nome", produtoViewModel.FornecedorId);
            return View(produtoViewModel);
        }

        // POST: Suporte/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SuporteViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                _suporteApp.Update(produtoViewModel);
                return RedirectToAction("Index");
            }

            //ViewBag.ClienteId = new SelectList(_fornecedorApp.GetAll(), "ClienteId", "Nome", produtoViewModel.FornecedorId);
            return View(produtoViewModel);
        }

        // GET: Suporte/Delete/5
        public ActionResult Delete(int id)
        {
            var produtoViewModel = _suporteApp.GetByIdTipoInteiro(id);
            return View(produtoViewModel);
        }

        // POST: Suporte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _suporteApp.Remove(_suporteApp.GetByIdTipoInteiro(id));
            return RedirectToAction("Index");
        }
    }
}
