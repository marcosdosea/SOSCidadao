using Core;
using Core.DTO;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Tests
{
    [TestClass()]
    public class ComentarioServiceTests
    {
		private SosCidadaoContext _context;
		private IComentarioService _comentarioService;

		[TestInitialize]
		public void Initialize()
		{
            //Arrange
            var builder = new DbContextOptionsBuilder<SosCidadaoContext>();
			builder.UseInMemoryDatabase("SosCidadaoContext");
			var options = builder.Options;

			_context = new SosCidadaoContext(options);
			_context.Database.EnsureDeleted();
			_context.Database.EnsureCreated();
			var autores = new List<Comentario>
				{
					new Comentario { IdOcorrencia = 1, Descricao = "Carro havia uma porta amassada" , DataCadastro = DateTime.Parse("2021-12-31")},
					new Comentario { IdOcorrencia = 1, Descricao = "FOi visto pela última vez do posto Santo Bello." , DataCadastro = DateTime.Parse("2021-01-25")},
				};

			_context.AddRange(autores);
			_context.SaveChanges();

			_comentarioService = new ComentarioService(_context);
		}


		[TestMethod()]
		public void InserirTest()
		{
			// Act
			_comentarioService.Inserir(new Comentario () { IdOcorrencia = 1, Descricao = "Carro com o vidro trincado", DataCadastro = DateTime.Parse("2021-12-31") });
			// Assert
			Assert.AreEqual(3, _comentarioService.ObterTodos().Count());
			var comentario = _comentarioService.Obter(3);
			Assert.AreEqual("Carro com o vidro trincado", comentario.Descricao);
			Assert.AreEqual(DateTime.Parse("2021-12-31"), comentario.DataCadastro);
		}


		[TestMethod()]
		public void RemoverTest()
		{
			// Act
			_comentarioService.Remover(2);
			// Assert
			Assert.AreEqual(1, _comentarioService.ObterTodos().Count());
			var autor = _comentarioService.Obter(2);
			Assert.AreEqual(null, autor);
		}

		[TestMethod()]
		public void ObterTodosTest()
		{
			// Act
			var listaComentario = _comentarioService.ObterTodos();
			// Assert
			Assert.IsInstanceOfType(listaComentario, typeof(IEnumerable<Comentario>));
			Assert.IsNotNull(listaComentario);
			Assert.AreEqual(2, listaComentario.Count());
			Assert.AreEqual(1, listaComentario.First().IdComentario);
			Assert.AreEqual("Carro havia uma porta amassada", listaComentario.First().Descricao);
		}


		[TestMethod()]
		public void ObterTest()
		{
			var comentario = _comentarioService.Obter(1);
			Assert.IsNotNull(comentario);
			Assert.AreEqual("Carro havia uma porta amassada", comentario.Descricao);
		}



	}
}