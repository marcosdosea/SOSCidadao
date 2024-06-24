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
    public class TipopertenceController : Controller
    {
        private readonly ITipopertenceService _tipopertenceService;
        private readonly IOrganizacaoService _organizacaoService;
        private readonly IMapper _mapper;

        public TipopertenceController(ITipopertenceService tipopertenceService, IOrganizacaoService organizacaoService, IMapper mapper)
        {
            _tipopertenceService = tipopertenceService;
            _organizacaoService = organizacaoService;
            _mapper = mapper;
        }

        // GET: Tipopertence
        public ActionResult Index()
        {
            ViewBag.title_page = "Tipo Pertence";
            ViewBag.path = "Início / Tipo Pertence";

            var listaTipoPertences = _tipopertenceService.ObterTodosDTO();
            var listaTipoPertencesDTO = _mapper.Map<List<TipopertenceDTO>>(listaTipoPertences);

            return View("./Index_DTO", listaTipoPertencesDTO);
        }

        // GET: Tipopertence/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.title_page = "Tipo Pertence";
            ViewBag.path = "Início / Tipo Pertence / Detalhes";

            TipopertenceDTO tipopertenceDTO = _tipopertenceService.ObterDTO(id);

            return View("./Details_DTO", tipopertenceDTO);
        }

        // GET: Tipopertence/Create
        public ActionResult Create()
        {
            ViewBag.title_page = "Tipo Pertence";
            ViewBag.path = "Início / Tipo Pertence / Criar";

            IEnumerable<Organizacao> listaorganizacao = _organizacaoService.ObterTodos();
            ViewBag.idOrganizacao = new SelectList(listaorganizacao, "IdOrganizacao", "NomeFantasia", null);

            return View();
        }

        // POST: Tipopertence/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipopertenceModel tipopertenceModel)
        {
            if (ModelState.IsValid)
            {
                var tipopertence = _mapper.Map<Tipopertence>(tipopertenceModel);

                tipopertence.IdOrganizacao = 1;
                _tipopertenceService.Inserir(tipopertence);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Tipopertence/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.title_page = "Tipo Pertence";
            ViewBag.path = "Início / Tipo Pertence / Editar";

            Tipopertence tipopertence = _tipopertenceService.Obter(id);
            TipopertenceModel tipopertenceModel = _mapper.Map<TipopertenceModel>(tipopertence);

            IEnumerable<Organizacao> listaorganizacao = _organizacaoService.ObterTodos();
            ViewBag.idOrganizacao = new SelectList(listaorganizacao, "IdOrganizacao", "NomeFantasia", null);

            return View(tipopertenceModel);
        }

        // POST: Tipopertence/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TipopertenceModel tipopertenceModel)
        {
            if (ModelState.IsValid)
            {
                var tipopertence = _mapper.Map<Tipopertence>(tipopertenceModel);
                tipopertence.IdTipoPertence = id;
                _tipopertenceService.Atualizar(tipopertence);
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: Tipopertence/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.title_page = "Tipo Pertence";
            ViewBag.path = "Início / Tipo Pertence / Remover";

            TipopertenceDTO tipopertenceDTO = _tipopertenceService.ObterDTO(id);

            return View("./Delete_DTO", tipopertenceDTO);
        }

        // POST: Tipopertence/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TipopertenceModel tipopertenceModel)
        {
            _tipopertenceService.Remover(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
