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
    public class ComentarioController : Controller
    {
        private readonly IComentarioService _comentarioService;
        private readonly IPessoaService _pessoaService;
        private readonly IMapper _mapper;

        public ComentarioController(IComentarioService comentario, IPessoaService pessoaService, IMapper mapper)
        {
            _comentarioService = comentario;
            _pessoaService = pessoaService;
            _mapper = mapper;
        }

        // GET: ComentarioController
        public ActionResult Index()
        {
            ViewBag.title_page = "Comentario";
            ViewBag.path = "Início / Comentario";

            var listaComentarios = _comentarioService.ObterTodosDTO();
            var listaComentariosDTO = _mapper.Map<List<ComentarioDTO>>(listaComentarios);

            return View("./Index_DTO", listaComentariosDTO);
        }

        // GET: ComentarioController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.title_page = "Comentario";
            ViewBag.path = "Início / Comentario / Detalhes";

            ComentarioDTO comentarioDTO = _comentarioService.ObterDTO(id);

            return View("./Details_DTO", comentarioDTO);
        }

        // GET: ComentarioController/Create
        public ActionResult Create()
        {
            ViewBag.title_page = "Comentario";
            ViewBag.path = "Início / Comentario / Criar";

            IEnumerable<Pessoa> listapessoas = _pessoaService.ObterTodos();
            ViewBag.IdPessoa = new SelectList(listapessoas, "IdPessoa", "Nome", null);

            return View();
        }

        // POST: ComentarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ComentarioModel comentarioModel)
        {
            if (ModelState.IsValid)
            {
                var comentario = _mapper.Map<Comentario>(comentarioModel);

                comentario.DataCadastro = DateTime.Now;
                _comentarioService.Inserir(comentario);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ComentarioController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.title_page = "Comentario";
            ViewBag.path = "Início / Comentario / Editar";

            IEnumerable<Pessoa> listapessoas = _pessoaService.ObterTodos();
            ViewBag.IdPessoa = new SelectList(listapessoas, "IdPessoa", "Nome", null);

            Comentario comentario = _comentarioService.Obter(id);
            ComentarioModel comentarioModel = _mapper.Map<ComentarioModel>(comentario);

            return View(comentarioModel);
        }

        // POST: ComentarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ComentarioModel comentarioModel)
        {
            if (ModelState.IsValid)
            {
                var comentario = _mapper.Map<Comentario>(comentarioModel);

                comentario.IdComentario = id;
                comentario.DataCadastro = DateTime.Now;
                _comentarioService.Atualizar(comentario);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ComentarioController/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.title_page = "Comentario";
            ViewBag.path = "Início / Comentario / Remover";

            ComentarioDTO comentarioDTO = _comentarioService.ObterDTO(id);

            return View("./Delete_DTO", comentarioDTO);
        }

        // POST: ComentarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ComentarioModel comentario)
        {
            _comentarioService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}