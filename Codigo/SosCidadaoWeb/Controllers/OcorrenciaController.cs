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
    public class OcorrenciaController : Controller
    {
        private readonly IPessoaService _pessoaService;
        private readonly IOcorrenciaService _ocorrenciaService;
        private readonly IMapper _mapper;

        public OcorrenciaController(IOcorrenciaService ocorrencia, IOcorrenciaService ocorrenciaService, IMapper mapper)
        {
            _ocorrenciaService = ocorrencia;
            _ocorrenciaService = ocorrenciaService;
            _mapper = mapper;
        }

        // GET: OcorrenciaController
        public ActionResult Index()
        {
            ViewBag.title_page = "Ocorrência";
            ViewBag.path = "Início / Ocorrência";

            var listaOcorrencia = _ocorrenciaService.ObterTodosDTO();
            var listaOcorrenciaDTO = _mapper.Map<List<Ocorrencia>>(listaOcorrencia);
            return View("./Index_DTO", listaOcorrenciaDTO);
        }

        // GET: OcorrenciaController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.title_page = "Ocorrência";
            ViewBag.path = "Início / Ocorrência / Detalhes";

            OcorrenciaDTO ocorrenciaDto = _ocorrenciaService.ObterDTO(id);

            return View("./Details_DTO", ocorrenciaDto);
        }

        // GET: OcorrenciaController/Create
        public ActionResult Create()
        {
            ViewBag.title_page = "Ocorrência";
            ViewBag.path = "Início / Ocorrência / Criar";

            IEnumerable<Ocorrencia> listaOcorrencia = _ocorrenciaService.ObterTodos();
            ViewBag.idOcorrencia = new SelectList(listaOcorrencia, "Id Ocorrência");

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
                _ocorrenciaService.Editar(ocorrencia);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: OcorrenciaController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.title_page = "Ocorrência";
            ViewBag.path = "Início / Ocorrência / Editar";
            Ocorrencia ocorrencia = _ocorrenciaService.Obter(id);
            OcorrenciaModel ocorrenciaModel = _mapper.Map<OcorrenciaModel>(ocorrencia);

            return View(ocorrenciaModel);
        }

        // POST: OcorrenciaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OcorrenciaModel ocorrenciaModel)
        {
            if (ModelState.IsValid)
            {
                var ocorrencia = _mapper.Map<Ocorrencia>(ocorrenciaModel);
                _ocorrenciaService.Editar(ocorrencia);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: OcorrenciaController/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.title_page = "Ocorrência";
            ViewBag.path = "Início / Ocorrência / Remover";

            //Ocorrencia ocorrencia = _ocorrenciaService.Obter(id);
            //OcorrenciaModel ocorrenciaModel = _mapper.Map<OcorrenciaModel>(ocorrencia);
            OcorrenciaDTO ocorrenciaDTO = _ocorrenciaService.ObterDTO(id);
            return View("./Delete_DTO", ocorrenciaDTO);
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
