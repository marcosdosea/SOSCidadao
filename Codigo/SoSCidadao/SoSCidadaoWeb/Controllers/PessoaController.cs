using System;
using System.Collections.Generic;
using AutoMapper;
using Core;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using SoSCidadaoWeb.Models;

namespace SoSCidadaoWeb.Controllers
{
    public class PessoaController : Controller
    {

        IPessoaService _pessoaService;
        IMapper _mapper;

        public PessoaController(IPessoaService pessoaService, IMapper mapper)
        {
            _pessoaService = pessoaService;
            _mapper = mapper;
        }

        // GET: Pessoa
        public ActionResult Index()
        {
            var listaPessoas = _pessoaService.ObterTodos();
            var listaPessoasModel = _mapper.Map<List<PessoaModel>>(listaPessoas);
            ViewBag.isBannerHidden = 0;
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
            ViewBag.isBannerHidden = 0;
            return View();
        }

        // POST: Pessoa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PessoaModel pessoaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var pessoa = _mapper.Map<Pessoa>(pessoaModel);
                    _pessoaService.Inserir(pessoa);

                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(int id)
        {
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