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
    public class PessoaController : Controller
    {

        private readonly IPessoaService _pessoaService;
        private readonly IOrganizacaoService _organizacaoService;
        private readonly IMapper _mapper;

        public PessoaController(IPessoaService pessoaService, IOrganizacaoService organizacaoService, IMapper mapper)
        {
            _pessoaService = pessoaService;
            _organizacaoService = organizacaoService;
            _mapper = mapper;
        }

        // GET: Pessoa
        public ActionResult Index()
        {
            ViewBag.title_page = "Pessoa";
            ViewBag.path = "Início / Pessoa";

            ViewBag.isBannerHidden = false;
            ViewBag.isBannerFull = true;

            var listaPessoa = _pessoaService.ObterTodosDTO();
            var listaPessoaDTO = _mapper.Map<List<PessoaDTO>>(listaPessoa);

            return View("./Index_DTO", listaPessoaDTO);

        }

        // GET: Pessoa/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.title_page = "Pessoa";
            ViewBag.path = "Início / Pessoa / Detalhes";

            PessoaDTO pessoaDTO = _pessoaService.ObterDTO(id);

            return View("./Details_DTO", pessoaDTO);
        }

        // GET: Pessoa/Create
        public ActionResult Create()
        {
            ViewBag.title_page = "Pessoa";
            ViewBag.path = "Início / Pessoa / Criar";

            ViewBag.isBannerHidden = false;
            ViewBag.isBannerFull = true;

            IEnumerable<Organizacao> listaorganizacao = _organizacaoService.ObterTodos();
            ViewBag.idOrganizacao = new SelectList(listaorganizacao, "IdOrganizacao", "NomeFantasia", null);

            return View();
        }

        // POST: Pessoa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PessoaModel pessoaModel)
        {
            if (ModelState.IsValid)
            {
                var pessoa = _mapper.Map<Pessoa>(pessoaModel);
                pessoa.TipoPessoa = "Pessoa";
                pessoa.StatusPessoa = "Ativo";
                pessoa.DataCadastro = DateTime.Now;

                _pessoaService.Inserir(pessoa);

            }
            return RedirectToAction(nameof(Index));

        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.title_page = "Pessoa";
            ViewBag.path = "Início / Pessoa / Editar";

            ViewBag.isBannerHidden = false;

            Pessoa pessoa = _pessoaService.Obter(id);
            PessoaModel pessoaModel = _mapper.Map<PessoaModel>(pessoa);

            IEnumerable<Organizacao> listaorganizacao = _organizacaoService.ObterTodos();
            ViewBag.idOrganizacao = new SelectList(listaorganizacao, "IdOrganizacao", "NomeFantasia", null);

            return View(pessoaModel);
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PessoaModel pessoaModel)
        {

            if (ModelState.IsValid)
            {
                var pessoa = _mapper.Map<Pessoa>(pessoaModel);
                pessoa.IdPessoa = id;
                pessoa.StatusPessoa = "Ativo";
                pessoa.TipoPessoa = "Pessoa";

                _pessoaService.Atualizar(pessoa);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.title_page = "Pessoa";
            ViewBag.path = "Início / Pessoa / Remover";

            PessoaDTO pessoaDTO = _pessoaService.ObterDTO(id);

            return View("./Delete_DTO", pessoaDTO);
        }

        // POST: Pessoa/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PessoaModel pessoaModel)
        {
            _pessoaService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
