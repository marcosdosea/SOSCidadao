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
    public class PertenceController : Controller
    {
        IPertenceService _pertenceService;
        IMapper _mapper;

        public PertenceController(IPertenceService pertenceService, IMapper mapper)
        {
            _pertenceService = pertenceService;
            _mapper = mapper;
        }
        // GET: PertenceController
        public ActionResult Index()
        {
            var listaPertence = _pertenceService.ObterTodos();
            var listaPertenceModel = _mapper.Map<List<PertenceModel>>(listaPertence);
            return View(listaPertenceModel);
        }

        // GET: PertenceController/Details/5
        public ActionResult Details(int id)
        {
            Pertence pertence = _pertenceService.Obter(id);
            PertenceModel pertenceModel = _mapper.Map<PertenceModel>(pertence);
            return View(pertenceModel);
        }

        // GET: PertenceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PertenceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PertenceModel pertenceModel)
        {
             if (ModelState.IsValid)
             {
                var pertence = _mapper.Map<Pertence>(pertenceModel);
                _pertenceService.Inserir(pertence);
             }
             return RedirectToAction(nameof(Index));
        }

        // GET: PertenceController/Edit/5
        public ActionResult Edit(int id)
        {
            Pertence pertence = _pertenceService.Obter(id);
            PertenceModel pertenceModel = _mapper.Map<PertenceModel>(pertence);
            return View(pertenceModel);
        }

        // POST: PertenceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PertenceModel pertenceModel)
        {
            if (ModelState.IsValid)
            {
                 var pertence = _mapper.Map<Pertence>(pertenceModel);
                _pertenceService.Atualizar(pertence);
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: PertenceController/Delete/5
        public ActionResult Delete(int id)
        {
            Pertence pertence = _pertenceService.Obter(id);
            PertenceModel pertenceModel = _mapper.Map<PertenceModel>(pertence);
            return View(pertenceModel);
        }

        // POST: PertenceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PertenceModel pertenceModel)
        {
            _pertenceService.Remover(id);
          return RedirectToAction(nameof(Index));
        
        }
    }
}
