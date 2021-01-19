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
    public class TipopertenceController : Controller
    {
        private readonly ITipopertenceService _tipopertenceService;
        private readonly IMapper _mapper;

        public TipopertenceController(ITipopertenceService tipopertenceService, IMapper mapper)
        {
            _tipopertenceService = tipopertenceService;
            _mapper = mapper;
        }
        // GET: TipopertenceController
        public ActionResult Index()
        {
            var listaTipopertence = _tipopertenceService.ObterTodos();
            var listaTipopertenceModel = _mapper.Map<List<TipopertenceModel>>(listaTipopertence);
            return View(listaTipopertenceModel);
        }

        // GET: TipopertenceController/Details/5
        public ActionResult Details(int id)
        {
            Tipopertence tipopertence = _tipopertenceService.Obter(id);
            TipopertenceModel tipopertenceModel = _mapper.Map<TipopertenceModel>(tipopertence);
            return View(tipopertenceModel);
        }

        // GET: TipopertenceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipopertenceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipopertenceModel tipopertenceModel)
        {
             if (ModelState.IsValid)
             {
                var tipopertence = _mapper.Map<Tipopertence>(tipopertenceModel);
                 _tipopertenceService.Inserir(tipopertence);
             }
             return RedirectToAction(nameof(Index));
        }

        // GET: TipopertenceController/Edit/5
        public ActionResult Edit(int id)
        {
            Tipopertence tipopertence = _tipopertenceService.Obter(id);
            TipopertenceModel tipopertenceModel = _mapper.Map<TipopertenceModel>(tipopertence);
            return View(tipopertenceModel);
        }

        // POST: TipopertenceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TipopertenceModel tipopertenceModel)
        {
            if (ModelState.IsValid)
            {
                 var tipopertence = _mapper.Map<Tipopertence>(tipopertenceModel);
                 _tipopertenceService.Atualizar(tipopertence);
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: TipopertenceController/Delete/5
        public ActionResult Delete(int id)
        {
            Tipopertence tipopertence = _tipopertenceService.Obter(id);
            TipopertenceModel tipopertenceModel = _mapper.Map<TipopertenceModel>(tipopertence);
            return View(tipopertenceModel);
        }

        // POST: TipopertenceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TipopertenceModel tipopertenceModel)
        {
          _tipopertenceService.Remover(id);
          return RedirectToAction(nameof(Index));
        
        }
    }
}
