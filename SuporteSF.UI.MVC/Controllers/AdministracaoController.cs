using SuporteSF.Application.Interfaces;
using SuporteSF.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace SuporteSF.UI.MVC.Controllers
{
    public class AdministracaoController : Controller
    {
        private readonly ISuporteAppService _suporteApp;

        public AdministracaoController(ISuporteAppService suporteApp)
        {
            _suporteApp = suporteApp;
        }

        // GET: Administracao
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaSuporte(string sortOrder, string currentFilter, string searchString, int? page)
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



        public ActionResult _DetalhesSuporte(int id = 0)
        {
            var model = _suporteApp.GetByIdTipoInteiro(id);
            return PartialView(model);
        }

        public ActionResult Cancelar2(int id = 0)
        {
            var model = _suporteApp.GetByIdTipoInteiro(id);

            //model.status = "Cancelado";
            //model.data_alteracao = DateTime.Now;
            //model.data_fechamento = DateTime.Now;
            //model.idusuario_alteracao = User.Identity.GetUserId();

            //if (ModelState.IsValid)
            //{
            //    db2.Entry(model).State = EntityState.Modified;
            //    db2.SaveChanges();
            //    TempData["Success"] = "Cancelamento feito com sucesso!";
            //    //return RedirectToAction("Acompanhar");
            //}
            //else
            //{
            //    TempData["Erro"] = "Erro ao cancelar. Favor tentar novamente!";
            //}

            return RedirectToAction("ListaSuporte");
        }



        // POST: Tab_Suporte/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Salvar([Bind(Include = "idsuporte,status,data_alteracao,idusuario_alteracao,descr_solucao")] SuporteViewModel suporteViewModel)
        {
            var model = _suporteApp.GetByIdTipoInteiro(suporteViewModel.IdSuporte);
            //if (model != null)
            //{
            //    if (!model.Status.ToUpper().Equals("ABERTO"))
            //        ModelState.AddModelError(string.Empty, "É Necessário estar com suporte em aberto para alteração.");
            //    else
            //    {
            //        try
            //        {
            //            model.descr_solucao = suporteViewModel.descr_solucao;
            //            model.data_atendimento = suporteViewModel.data_alteracao;
            //            model.data_alteracao = suporteViewModel.data_alteracao;
            //            model.idusuario_alteracao = suporteViewModel.idusuario_alteracao;

            //            db2.Entry(suporte).State = EntityState.Modified;
            //            db2.SaveChanges();
            //            TempData["Success"] = "feito com sucesso!";
            //        }
            //        catch
            //        {
            //            TempData["Erro"] = "Erro ao salvar. Favor tentar novamente!";
            //            //ModelState.AddModelError(string.Empty, "Ocorreu um erro. Favor tentar novamente.");
            //            //return View(suporte);
            //        }
            //    }
            //}
            //else
            //{
            //    TempData["Erro"] = "Erro. Favor tentar novamente!";
            //}

            return RedirectToAction("ListaSuporte");
        }
    }
}