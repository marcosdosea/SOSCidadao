﻿using AutoMapper;
using Core;
using Core.DTO;
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
    public class TipoocorrenciaController : Controller
    {
        private readonly ITipoocorrenciaService _tipoocorrenciaService;
        private readonly IOrganizacaoService _organizacaoService;

        private readonly IMapper _mapper;
        
        public TipoocorrenciaController(ITipoocorrenciaService tipoocorrenciaService,  IOrganizacaoService organizacaoService, IMapper mapper)
        {
            _tipoocorrenciaService = tipoocorrenciaService;
            _organizacaoService = organizacaoService;
            _mapper = mapper;
        }

        // GET: TipoocorrenciaController
        public ActionResult Index()
        {
            ViewBag.title_page = "Tipo Pertence";
            ViewBag.path = "Início / Tipo Pertence";

            var listaTipoocorrencia = _tipoocorrenciaService.TipoOcorrenciaOrganizacao();
            var listaTipoocorrenciaDTO = _mapper.Map<List<TipoocorrenciaDTO>>(listaTipoocorrencia);
            return View("./Index_DTO", listaTipoocorrenciaDTO);
        }

        // GET: TipoocorrenciaController/Details/5
        public ActionResult Details(int id)
        {
            Tipoocorrencia tipoocorrencia = _tipoocorrenciaService.Obter(id);
            TipoocorrenciaModel tipoocorrenciaModel = _mapper.Map<TipoocorrenciaModel>(tipoocorrencia);
            return View(tipoocorrenciaModel);
        }

        // GET: TipoocorrenciaController/Create
        public ActionResult Create()
        {
            IEnumerable<Organizacao> listaOrganizacao = _organizacaoService.ObterTodos();
            ViewBag.Organizacao = new SelectList(listaOrganizacao, "IdOrganizacao", "NomeFantasia", null);
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
      
            Tipoocorrencia tipoocorrencia = _tipoocorrenciaService.Obter(id);
            TipoocorrenciaModel tipoocorrenciaModel = _mapper.Map<TipoocorrenciaModel>(tipoocorrencia);

            IEnumerable<Organizacao> listaOrganizacao = _organizacaoService.ObterTodos();
            ViewBag.Organizacao = new SelectList(listaOrganizacao, "IdOrganizacao", "NomeFantasia", tipoocorrenciaModel.IdOrganizacao );

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
                tipoocorrencia.IdTipoOcorrencia = id;
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
