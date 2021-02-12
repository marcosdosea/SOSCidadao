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
    public class OcorrenciaController : Controller
    {
        IOcorrenciaService _ocorrenciaService;
        IMapper _mapper;

        public OcorrenciaController(IOcorrenciaService ocorrenciaService, IMapper mapper)
        {
            _ocorrenciaService = ocorrenciaService;
            _mapper = mapper;
        }

        //GET: OcorrenciaController
            
        public ActionResult Index()
        {
            ViewBag.title_page = "Listar Ocorrências";
            ViewBag.path = "Início / Ocorrência";

            var listaOcorrencias = _ocorrenciaService.ObterTodos();
            var listaOcorrenciasModel = _mapper.Map<List<OcorrenciaModel>>(listaOcorrencias);
            return View(listaOcorrenciasModel);
        }

        //GET OcorrenciaController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.title_page = "Detalhes Ocorrência";
            ViewBag.path = "Início / Ocorrência / Detalhes";

            Ocorrencia ocorrencias = _ocorrenciaService.Obter(id);
            OcorrenciaModel ocorrenciaModel = _mapper.Map<OcorrenciaModel>(ocorrencias);
            return View(ocorrenciaModel);
        }

        // GET: OcorrenciaController/Create
        public ActionResult Create()
        {
            ViewBag.title_page = "Detalhes Ocorrência";
            ViewBag.path = "Início / Ocorrência / Criar";

            return View();
        }

        // POST: OcorrenciaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OcorrenciaModel ocorrenciaModel)
        {
            if (ModelState.IsValid)
            {
                var ocorrencia = _mapper.Map<Ocorrencia>(ocorrenciaModel);
                _ocorrenciaService.Inserir(ocorrencia);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: OcorrenciaController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.title_page = "Detalhes Ocorrência";
            ViewBag.path = "Início / Ocorrência / Editar";

            Ocorrencia ocorrencia = _ocorrenciaService.Obter(id);
            OcorrenciaModel ocorrenciaModel = _mapper.Map<OcorrenciaModel>(ocorrencia);
            return View(ocorrenciaModel);
        }

        // POST: OcorrenciaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OcorrenciaModel ocorrenciaModel)
        {
            if (ModelState.IsValid)
            {
                var ocorrencia = _mapper.Map<Ocorrencia>(ocorrenciaModel);

                ocorrencia.IdOcorrencia = id;
                _ocorrenciaService.Atualizar(ocorrencia);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: OcorrenciaController/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.title_page = "Detalhes Ocorrência";
            ViewBag.path = "Início / Ocorrência / Remover";

            Ocorrencia ocorrencia = _ocorrenciaService.Obter(id);
            OcorrenciaModel ocorrenciaModel = _mapper.Map<OcorrenciaModel>(ocorrencia);
            return View(ocorrenciaModel);
        }

        // POST: OcorrenciaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, OcorrenciaModel ocorrenciaModel)
        {
            _ocorrenciaService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
