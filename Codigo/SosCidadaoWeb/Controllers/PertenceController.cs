using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        ITipopertenceService _tipopertenceService;
        IMapper _mapper;

        public PertenceController(IPertenceService pertenceService, ITipopertenceService tipopertenceService, IMapper mapper)
        {
            _pertenceService = pertenceService;
            _tipopertenceService = tipopertenceService;
            _mapper = mapper;
        }
        // GET: Pertence
        public ActionResult Index()
        {
            ViewBag.title_page = "Pertence";
            ViewBag.path = "Início / Pertence";

            var listaPertence = _pertenceService.ObterTodos();
            var listaPertenceModel = _mapper.Map<List<PertenceModel>>(listaPertence);
            return View(listaPertenceModel);
        }

        // GET: Pertence/Details/5
        public ActionResult Details(int id)
        {
            Pertence pertence = _pertenceService.Obter(id);
            PertenceModel pertenceModel = _mapper.Map<PertenceModel>(pertence);
            return View(pertenceModel);
        }

        // GET: Pertence/Create
        public ActionResult Create()
        {
            IEnumerable<Tipopertence> listaTipoPertence = _tipopertenceService.ObterTodos();
            ViewBag.idTipoPertence = new SelectList(listaTipoPertence, "IdTipoPertence", "Nome", null);
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

                pertence.StatusPertence = "Em Analise";
                _pertenceService.Inserir(pertence);
             }
             return RedirectToAction(nameof(Index));
        }

        // GET: Pertence/Edit/5
        public ActionResult Edit(int id)
        {
            IEnumerable<Tipopertence> listaTipoPertence = _tipopertenceService.ObterTodos();
            ViewBag.idTipoPertence = new SelectList(listaTipoPertence, "IdTipoPertence", "Nome", null);

            Pertence pertence = _pertenceService.Obter(id);
            PertenceModel pertenceModel = _mapper.Map<PertenceModel>(pertence);
            return View(pertenceModel);
        }

        // POST: Pertence/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PertenceModel pertenceModel)
        {
            if (ModelState.IsValid)
            {
                 var pertence = _mapper.Map<Pertence>(pertenceModel);
                pertence.IdPertence = id;
                _pertenceService.Atualizar(pertence);
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: Pertence/Delete/5
        public ActionResult Delete(int id)
        {
            Pertence pertence = _pertenceService.Obter(id);
            PertenceModel pertenceModel = _mapper.Map<PertenceModel>(pertence);
            return View(pertenceModel);
        }

        // POST: Pertence/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PertenceModel pertenceModel)
        {
            _pertenceService.Remover(id);
          return RedirectToAction(nameof(Index));
        
        }
    }
}
