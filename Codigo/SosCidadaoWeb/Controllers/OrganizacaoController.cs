using AutoMapper;
using Core;
using Core.DTO;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SosCidadaoWeb.Models;
using System;
using System.Collections.Generic;

namespace SosCidadaoWeb.Controllers
{
    public class OrganizacaoController : Controller
    {

        IOrganizacaoService _organizacaoService;
        private readonly IPessoaService _pessoaService;
        IMapper _mapper;

        public OrganizacaoController(IOrganizacaoService organizacaoService, IPessoaService pessoaService, IMapper mapper)
        {
            _organizacaoService = organizacaoService;
            _pessoaService = pessoaService;
            _mapper = mapper;
        }

        // GET: OrganizacaoController
        public ActionResult Index()
        {
            ViewBag.title_page = "Listar Organização";
            ViewBag.path = "Início / Organização";

            var listaOrganizacoes = _organizacaoService.ObterTodosDTO();
            var listaOrganizacoesDTO = _mapper.Map<List<OrganizacaoDTO>>(listaOrganizacoes);

            return View("./Index_DTO", listaOrganizacoesDTO);
        }

        // GET: OrganizacaoController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.title_page = "Detalhes Organização";
            ViewBag.path = "Início / Organização / Detalhes";

            OrganizacaoDTO organizacaoDTO = _organizacaoService.ObterDTO(id);

            return View("./Details_DTO", organizacaoDTO);
        }

        // GET: OrganizacaoController/Create
        public ActionResult Create()
        {
            ViewBag.title_page = "Criar Organização";
            ViewBag.path = "Início / Organização / Criar";

            IEnumerable<Pessoa> listapessoas = _pessoaService.ObterTodos();
            ViewBag.IdPessoa = new SelectList(listapessoas, "IdPessoa", "Nome", null);

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

            IEnumerable<Pessoa> listapessoas = _pessoaService.ObterTodos();
            ViewBag.IdPessoa = new SelectList(listapessoas, "IdPessoa", "Nome", null);

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

            OrganizacaoDTO organizacaoDTO = _organizacaoService.ObterDTO(id);

            return View("./Delete_DTO", organizacaoDTO);

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