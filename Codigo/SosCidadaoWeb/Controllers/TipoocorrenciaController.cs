using AutoMapper;
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
            ViewBag.title_page = "Tipo Ocorrência";
            ViewBag.path = "Início / Tipo Ocorrência";

            var listaTipoOcorrencia = _tipoocorrenciaService.ObterTodosDTO();
            var listaTipoOcorrenciaDTO = _mapper.Map<List<TipoocorrenciaDTO>>(listaTipoOcorrencia);

            return View("./Index_DTO", listaTipoOcorrenciaDTO);
        }

        // GET: TipoocorrenciaController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.title_page = "Tipo Ocorrência";
            ViewBag.path = "Início / Tipo Ocorrência / Detalhes";

            TipoocorrenciaDTO tipoocorrenciaDTO = _tipoocorrenciaService.ObterDTO(id);

            return View("./Details_DTO", tipoocorrenciaDTO);
        }

        // GET: TipoocorrenciaController/Create
        public ActionResult Create()
        {
            ViewBag.title_page = "Tipo Ocorrência";
            ViewBag.path = "Início / Tipo Ocorrência/ Criar ";

            IEnumerable<Organizacao> listaorganizacao = _organizacaoService.ObterTodos();
            ViewBag.idOrganizacao = new SelectList(listaorganizacao, "IdOrganizacao", "NomeFantasia", null);

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

            IEnumerable<Organizacao> listaorganizacao = _organizacaoService.ObterTodos();
            ViewBag.idOrganizacao = new SelectList(listaorganizacao, "IdOrganizacao", "NomeFantasia", null);

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
            ViewBag.title_page = "Tipo Ocorrência";
            ViewBag.path = "Início / Tipo Ocorrência / Remover";

            TipoocorrenciaDTO tipoocorrenciaDTO = _tipoocorrenciaService.ObterDTO(id);

            return View("./Delete_DTO",tipoocorrenciaDTO);
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