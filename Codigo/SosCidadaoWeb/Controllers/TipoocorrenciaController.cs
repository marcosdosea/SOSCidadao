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
    public class TipoocorrenciaController : Controller
    {
        ITipoocorrenciaService _tipoocorrenciaService;
        IMapper _mapper;
        public TipoocorrenciaController(ITipoocorrenciaService tipoocorrenciaService, IMapper mapper)
        {
            _tipoocorrenciaService = tipoocorrenciaService;
            _mapper = mapper;
        }

        // GET: TipoocorrenciaController
        public ActionResult Index()
        {
            ViewBag.title_page = "Tipo Ocorrência";
            ViewBag.path = "Início / Tipo Ocorrência";

            var listaTipoocorrencia = _tipoocorrenciaService.ObterTodos();
            var listaTipoocorrenciaModel = _mapper.Map<List<TipoocorrenciaModel>>(listaTipoocorrencia);
            return View(listaTipoocorrenciaModel);
        }

        // GET: TipoocorrenciaController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.title_page = "Tipo Ocorrência";
            ViewBag.path = "Início / Tipo Ocorrência / Detalhes";

            Tipoocorrencia tipoocorrencia = _tipoocorrenciaService.Obter(id);
            TipoocorrenciaModel tipoocorrenciaModel = _mapper.Map<TipoocorrenciaModel>(tipoocorrencia);
            return View(tipoocorrenciaModel);
        }

        // GET: TipoocorrenciaController/Create
        public ActionResult Create()
        {
            ViewBag.title_page = "Tipo Ocorrência";
            ViewBag.path = "Início / Tipo Ocorrência/ Criar ";

            return View();
        }

        // POST: TipoocorrenciaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoocorrenciaModel tipoocorrenciaModel)
        {
            if (ModelState.IsValid)
            {

                var tipoocorrencia = _mapper.Map<Tipoocorrencia>(tipoocorrenciaModel);
                _tipoocorrenciaService.Inserir(tipoocorrencia);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TipoocorrenciaController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.title_page = "Tipo Ocorrência";
            ViewBag.path = "Início / Tipo Ocorrência / Editar";

            Tipoocorrencia tipoocorrencia = _tipoocorrenciaService.Obter(id);
            TipoocorrenciaModel tipoocorrenciaModel = _mapper.Map<TipoocorrenciaModel>(tipoocorrencia);
            return View(tipoocorrenciaModel);
        }

        // POST: TipoocorrenciaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TipoocorrenciaModel tipoocorrenciaModel)
        {
            if (ModelState.IsValid)
            {
                var tipoocorrencia = _mapper.Map<Tipoocorrencia>(tipoocorrenciaModel);
                _tipoocorrenciaService.Atualizar(tipoocorrencia);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TipoocorrenciaController/Delete/5
        public ActionResult Delete(int id)
        {
            Tipoocorrencia tipoocorrencia = _tipoocorrenciaService.Obter(id);
            TipoocorrenciaModel tipoocorrenciaModel = _mapper.Map<TipoocorrenciaModel>(tipoocorrencia);
            return View(tipoocorrenciaModel);
        }

        // POST: TipoocorrenciaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TipoocorrenciaModel tipoocorrenciaModel)
        {
            _tipoocorrenciaService.Remover(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
