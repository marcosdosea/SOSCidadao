using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using SosCidadaoWeb.Models;
using System;
using System.Collections.Generic;

namespace SosCidadaoWeb.Controllers
{
    public class OrganizacaoController : Controller
    {

        IOrganizacaoService _organizacaoService;
        IMapper _mapper;

        public OrganizacaoController(IOrganizacaoService organizacaoService, IMapper mapper)
        {
            _organizacaoService = organizacaoService;
            _mapper = mapper;
        }

        // GET: OrganizacaoController
        public ActionResult Index()
        {
            ViewBag.title_page = "Listar Organização";
            ViewBag.path = "Início / Organização";

            var listaOrganizacoes = _organizacaoService.ObterTodos();
            var listaOrganizacoesModel = _mapper.Map<List<OrganizacaoModel>>(listaOrganizacoes);
            return View(listaOrganizacoesModel);
        }

        // GET: OrganizacaoController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.title_page = "Detalhes Organização";
            ViewBag.path = "Início / Organização / Detalhes";

            Organizacao organizacao = _organizacaoService.Obter(id);
            OrganizacaoModel organizacaoModel = _mapper.Map<OrganizacaoModel>(organizacao);
            return View(organizacaoModel);
        }

        // GET: OrganizacaoController/Create
        public ActionResult Create()
        {
            ViewBag.title_page = "Criar Organização";
            ViewBag.path = "Início / Organização / Criar";

            return View();
        }

        // POST: OrganizacaoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrganizacaoModel organizacaoModel)
        {
            if (ModelState.IsValid)
            {
                var organizacao = _mapper.Map<Organizacao>(organizacaoModel);
                organizacao.DataRegistro = DateTime.Now;
                _organizacaoService.Inserir(organizacao);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: OrganizacaoController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.title_page = "Editar Organização";
            ViewBag.path = "Início / Organização / Editar";

            Organizacao organizacao = _organizacaoService.Obter(id);
            OrganizacaoModel organizacaoModel = _mapper.Map<OrganizacaoModel>(organizacao);
            return View(organizacaoModel);
        }

        // POST: OrganizacaoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OrganizacaoModel organizacaoModel)
        {
            if (ModelState.IsValid)
            {
                var organizacao = _mapper.Map<Organizacao>(organizacaoModel);

                organizacao.IdOrganizacao = id;
                _organizacaoService.Atualizar(organizacao);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: OrganizacaoController/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.title_page = "Remover Organização";
            ViewBag.path = "Início / Organização / Remover";

            Organizacao organizacao = _organizacaoService.Obter(id);
            OrganizacaoModel organizacaoModel = _mapper.Map<OrganizacaoModel>(organizacao);
            return View(organizacaoModel);
        }

        // POST: OrganizacaoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, OrganizacaoModel organizacaoModel)
        {
            _organizacaoService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
