using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using SosCidadaoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SosCidadaoWeb.Controllers
{
    public class PessoaController : Controller
    {

        private readonly IPessoaService _pessoaService;
        private readonly IMapper _mapper;

        public PessoaController(IPessoaService pessoaService, IMapper mapper)
        {
            _pessoaService = pessoaService;
            _mapper = mapper;
        }

        // GET: Pessoa
        public ActionResult Index()
        {
            ViewBag.isBannerHidden = false;
            ViewBag.isBannerFull = true;
            var listaPessoas = _pessoaService.ObterTodos();
            var listaPessoasModel = _mapper.Map<List<PessoaModel>>(listaPessoas);
            ViewBag.isBannerHidden = false;
            return View(listaPessoasModel);
        }

        // GET: Pessoa/Details/5
        public ActionResult Details(int id)
        {
            Pessoa pessoa = _pessoaService.Obter(id);
            PessoaModel pessoaModel = _mapper.Map<PessoaModel>(pessoa);
            return View(pessoaModel);
        }

        // GET: Pessoa/Create
        public ActionResult Create()
        {
            ViewBag.isBannerHidden = false;
            ViewBag.isBannerFull = true;    
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
                pessoa.StatusPessoa = "Ativo";
                pessoa.TipoPessoa = "Pessoa";

                _pessoaService.Inserir(pessoa);
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.isBannerHidden = false;
            Pessoa pessoa = _pessoaService.Obter(id);
            PessoaModel pessoaModel = _mapper.Map<PessoaModel>(pessoa);

            return View(pessoaModel);
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PessoaModel pessoaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var pessoa = _mapper.Map<Pessoa>(pessoaModel);
                    pessoa.IdPessoa = id;
                    pessoa.StatusPessoa = "Ativo";
                    pessoa.TipoPessoa = "Pessoa";
                    pessoa.IdOrganizacao = 1;

                    _pessoaService.Atualizar(pessoa);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(int id)
        {
            Pessoa pessoa = _pessoaService.Obter(id);
            PessoaModel pessoaModel = _mapper.Map<PessoaModel>(pessoa);
            return View(pessoaModel);
        }

        // POST: Pessoa/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PessoaModel pessoaModel)
        {
            try
            {
                _pessoaService.Remover(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
