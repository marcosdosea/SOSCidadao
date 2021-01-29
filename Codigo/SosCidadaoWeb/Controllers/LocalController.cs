using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SosCidadaoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        // GET: LocalController1
        public ActionResult Index()
        {
            var listaLocal = _localService.ObterTodos();
            var listalocalModel = _mapper.Map<List<LocalModel>>(listaLocal);
            return View(listalocalModel);
        }

        // GET: LocalController1/Details/5
        public ActionResult Details(int id)
        {
            Local local = _localService.Obter(id);
            LocalModel localModel = _mapper.Map<LocalModel>(local);
            return View(localModel);
        }

        // GET: LocalController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LocalController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocalModel localModel)
        {
            if (ModelState.IsValid)
            {
                var local = _mapper.Map<Local>(localModel);

                local.IdOrganizacao = 1;
                _localService.Inserir(local);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: LocalController1/Edit/5
        public ActionResult Edit(int id)
        {
            Local local = _localService.Obter(id);
            LocalModel localModel = _mapper.Map<LocalModel>(local);
            return View(localModel);
        }

        // POST: LocalController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LocalModel localModel)
        {
            if (ModelState.IsValid)
            {
                var local = _mapper.Map<Local>(localModel);
                local.IdLocal = id;
                local.IdOrganizacao = 1;
                _localService.Atualizar(local);

            }
            return RedirectToAction(nameof(Index));
        }

        // GET: LocalController1/Delete/5
        public ActionResult Delete(int id)
        {
            Local local = _localService.Obter(id);
            LocalModel localModel = _mapper.Map<LocalModel>(local);
            return View(localModel);
        }

        // POST: LocalController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _localService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
