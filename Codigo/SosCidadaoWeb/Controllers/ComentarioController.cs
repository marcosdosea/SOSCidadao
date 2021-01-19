using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IMapper _mapper;

        public ComentarioController(IComentarioService comentario, IMapper mapper)
        {
            _comentarioService = comentario;
            _mapper = mapper;
        }

        // GET: ComentarioController
        public ActionResult Index()
        {
            var listaComentarios = _comentarioService.ObterTodos();
            var listaComentariosModel = _mapper.Map<List<ComentarioModel>>(listaComentarios);
            return View(listaComentariosModel);
        }

        // GET: ComentarioController/Details/5
        public ActionResult Details(int id)
        {
            Comentario comentario = _comentarioService.Obter(id);
            ComentarioModel comentarioModel = _mapper.Map<ComentarioModel>(comentario);
            return View(comentarioModel);
        }

        // GET: ComentarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComentarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ComentarioModel comentarioModel)
        {
        
                var comentario = _mapper.Map<Comentario>(comentarioModel);
                comentario.IdComentario = 0;
                comentario.DataCadastro = DateTime.Now;
                _comentarioService.Inserir(comentario);

                return RedirectToAction(nameof(Index));
           
        }

        // GET: ComentarioController/Edit/5
        public ActionResult Edit(int id)
        {
            Comentario comentario = _comentarioService.Obter(id);
            ComentarioModel comentarioModel = _mapper.Map<ComentarioModel>(comentario);
            return View(comentarioModel);
        }

        // POST: ComentarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ComentarioModel comentarioModel)
        {
            try
            {
  
                var comentario = _mapper.Map<Comentario>(comentarioModel);
                comentarioModel.idComentario = id;
                comentario.IdOcorrencia = 0;
                comentario.DataCadastro = DateTime.Now;

                _comentarioService.Atualizar(comentario);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ComentarioController/Delete/5
        public ActionResult Delete(int id)
        {
            Comentario comentario = _comentarioService.Obter(id);
            ComentarioModel comentarioModel = _mapper.Map<ComentarioModel>(comentario);
            return View(comentarioModel);
        }

        // POST: ComentarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _comentarioService.Remover(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
