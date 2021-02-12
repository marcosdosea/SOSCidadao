using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using SosCidadaoWeb.Models;
using System.Collections.Generic;

namespace SosCidadaoWeb.Controllers
{
    public class LocalController : Controller
    {
        private readonly ILocalService _localService;
        private readonly IMapper _mapper;

        public LocalController(ILocalService localService, IMapper mapper)
        {
            _localService = localService;
            _mapper = mapper;
        }

        // GET: LocalController
        public ActionResult Index()
        {
            ViewBag.title_page = "Local";
            ViewBag.path = "Início / Local";

            var listaLocal = _localService.ObterTodos();
            var listalocalModel = _mapper.Map<List<LocalModel>>(listaLocal);
            return View(listalocalModel);
        }

        // GET: LocalController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.title_page = "Local";
            ViewBag.path = "Início / Local / Detalhes";

            Local local = _localService.Obter(id);
            LocalModel localModel = _mapper.Map<LocalModel>(local);
            return View(localModel);
        }

        // GET: LocalController/Create
        public ActionResult Create()
        {
            ViewBag.title_page = "Local";
            ViewBag.path = "Início / Local / Criar";

            return View();
        }

        // POST: LocalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocalModel localModel)
        {
            if (ModelState.IsValid)
            {
                var local = _mapper.Map<Local>(localModel);
                _localService.Inserir(local);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: LocalController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.title_page = "Local";
            ViewBag.path = "Início / Local / Editar";

            Local local = _localService.Obter(id);
            LocalModel localModel = _mapper.Map<LocalModel>(local);
            return View(localModel);
        }

        // POST: LocalController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LocalModel localModel)
        {
            if (ModelState.IsValid)
            {
                var local = _mapper.Map<Local>(localModel);

                local.IdLocal = id;
                _localService.Atualizar(local);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: LocalController/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.title_page = "Local";
            ViewBag.path = "Início / Local / Remover";

            Local local = _localService.Obter(id);
            LocalModel localModel = _mapper.Map<LocalModel>(local);
            return View(localModel);
        }

        // POST: LocalController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, LocalModel localModel)
        {
            _localService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
