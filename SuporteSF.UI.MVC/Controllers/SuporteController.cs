using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuporteSF.Application.Interfaces;
using SuporteSF.Application.ViewModels;
using PagedList;


using SuporteSF.Infra.CrossCutting.Identity;
using SuporteSF.Infra.CrossCutting.Identity.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

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
            var suporteViewModel = _suporteApp.GetByIdTipoInteiro(id);
            return View(suporteViewModel);
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
        public ActionResult Create(SuporteViewModel suporteViewModel)
        {
            if (ModelState.IsValid)
            {
                _suporteApp.Add(suporteViewModel);
                return RedirectToAction("Index");
            }

            //ViewBag.FornecedorId = new SelectList(_fornecedorApp.GetAll(), "FornecedorId", "Nome", produtoViewModel.FornecedorId);
            return View(suporteViewModel);
        }

        // GET: Suporte/Edit/5
        public ActionResult Edit(int id)
        {
            var suporteViewModel = _suporteApp.GetByIdTipoInteiro(id);
            //ViewBag.FornecedorId = new SelectList(_fornecedorApp.GetAll(), "FornecedorId", "Nome", produtoViewModel.FornecedorId);
            return View(suporteViewModel);
        }

        // POST: Suporte/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SuporteViewModel suporteViewModel)
        {
            if (ModelState.IsValid)
            {
                _suporteApp.Update(suporteViewModel);
                return RedirectToAction("Index");
            }

            //ViewBag.ClienteId = new SelectList(_fornecedorApp.GetAll(), "ClienteId", "Nome", produtoViewModel.FornecedorId);
            return View(suporteViewModel);
        }

        // GET: Suporte/Delete/5
        public ActionResult Delete(int id)
        {
            var suporteViewModel = _suporteApp.GetByIdTipoInteiro(id);
            return View(suporteViewModel);
        }

        // POST: Suporte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _suporteApp.Remove(_suporteApp.GetByIdTipoInteiro(id));
            return RedirectToAction("Index");
        }







        public ActionResult Solicitar()
        {
            return View();
        }



        // POST: Tab_Suporte/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Solicitar([Bind(Include = "Descricao,SistemaOperacional,ProblemaRecorrente,Prioridade,Email,DddTelefone,Telefone,MelhorHorarioAtendimento,Status,FlgTermoAceito,DtAbertura,IdUsuarioCadastro")] SuporteViewModel suporteViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!suporteViewModel.FlgTermoAceito)
                    ModelState.AddModelError(string.Empty, "É Necessário concordar com os termos de suporte remoto.");
                else
                {
                    _suporteApp.Add(suporteViewModel);
                    
                    //try
                    //{
                    //    db2.Suportes.Add(tab_Suporte);
                    //    db2.SaveChanges();
                    //}
                    //catch
                    //{
                    //    ModelState.AddModelError(string.Empty, "Ocorreu um erro. Favor tentar novamente.");
                    //    return View(suporteViewModel);
                    //}

                    return RedirectToAction("Acompanhar");
                }
            }
            else
            {
                //ModelState.AddModelError(string.Empty, "Ocorreu um erro.");
            }

            return View(suporteViewModel);
        }


        public ActionResult Acompanhar(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Código" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var tab = _suporteApp.GetAll(); //db2.Suportes.AsQueryable();
            if (!String.IsNullOrEmpty(searchString))
            {
                tab = tab.Where(s => s.Descricao.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "Descrição":
                    tab = tab.OrderBy(s => s.Descricao);
                    break;
                case "Slug":
                    tab = tab.OrderBy(s => s.Descricao);
                    break;
                default:
                    tab = tab.OrderBy(s => s.Descricao);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(tab.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult Detalhes2(int id = 0)
        {
            var suporteVielModel = _suporteApp.GetByIdTipoInteiro(id);
            return PartialView(suporteVielModel);
        }


        public ActionResult Cancelar2(int id = 0)
        {
            var model = _suporteApp.GetByIdTipoInteiro(id);
            if (ModelState.IsValid)
            {
                _suporteApp.CancelarSuporte(model, new Guid(User.Identity.GetUserId()));
                return RedirectToAction("Acompanhar");
            }
            return View("Acompanhar");
            

            //if (ModelState.IsValid)
            //{
            //    //db2.Entry(model).State = EntityState.Modified;
            //    //db2.SaveChanges();
            //    //return RedirectToAction("Acompanhar");
            //}
            //return View("Acompanhar");
        }
    }
}
