using AutoMapper;
using Core;
using Core.DTO;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SosCidadaoWeb.Models;
using System.Collections.Generic;

namespace SosCidadaoWeb.Controllers
{
    public class LocalController : Controller
    {
        private readonly ILocalService _localService;
        private readonly IOrganizacaoService _organizacaoService;
        private readonly IMapper _mapper;

        public LocalController(ILocalService localService, IOrganizacaoService organizacaoService, IMapper mapper)
        {
            _localService = localService;
            _organizacaoService = organizacaoService;
            _mapper = mapper;
        }

        // GET: LocalController
        public ActionResult Index()
        {
            ViewBag.title_page = "Local";
            ViewBag.path = "Início / Local";

            var listaLocais = _localService.ObterTodosDTO();
            var listaLocaisDTO = _mapper.Map<List<LocalDTO>>(listaLocais);

            return View("./Index_DTO", listaLocaisDTO);
        }

        // GET: LocalController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.title_page = "Local";
            ViewBag.path = "Início / Local / Detalhes";

            LocalDTO localDTO = _localService.ObterDTO(id);

            return View("./Details_DTO", localDTO);
        }

        // GET: LocalController/Create
        public ActionResult Create()
        {
            ViewBag.title_page = "Local";
            ViewBag.path = "Início / Local / Criar";

            IEnumerable<Organizacao> listaorganizacao = _organizacaoService.ObterTodos();
            ViewBag.idOrganizacao = new SelectList(listaorganizacao, "IdOrganizacao", "NomeFantasia", null);

            return View();
        }

        // POST: LocalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocalModel localModel)
        {
            if (ModelState.IsValid)
            {
                var local = _mapper.Map<Local>(localModel);
                _localService.Inserir(local);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: LocalController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.title_page = "Local";
            ViewBag.path = "Início / Local / Editar";

            Local local = _localService.Obter(id);
            LocalModel localModel = _mapper.Map<LocalModel>(local);

            IEnumerable<Organizacao> listaorganizacao = _organizacaoService.ObterTodos();
            ViewBag.idOrganizacao = new SelectList(listaorganizacao, "IdOrganizacao", "NomeFantasia", null);

            return View(localModel);
        }

        // POST: LocalController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LocalModel localModel)
        {
            if (ModelState.IsValid)
            {
                var local = _mapper.Map<Local>(localModel);

                local.IdLocal = id;
                _localService.Atualizar(local);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: LocalController/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.title_page = "Local";
            ViewBag.path = "Início / Local / Remover";

            LocalDTO pessoaDTO = _localService.ObterDTO(id);

            return View("./Delete_DTO", pessoaDTO);
        }

        // POST: LocalController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, LocalModel localModel)
        {
            _localService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
