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
    public class TipopertenceServiceTests
    {
		private SosCidadaoContext _context;
		private ITipopertenceService _tipoPertenceService;

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
			var tiposPertences = new List<Tipopertence>
				{
					new Tipopertence { Nome = "Moto", IdOrganizacao = 1,},
					new Tipopertence { Nome = "Carro", IdOrganizacao = 1,},
				};

			_context.AddRange(tiposPertences);
			_context.SaveChanges();

			_tipoPertenceService = new TipopertenceService(_context);
		}


		[TestMethod()]
		public void InserirTest()
		{
			// Act
			_tipoPertenceService.Inserir( new Tipopertence { Nome = "Celular", IdOrganizacao = 1});
			// Assert
			Assert.AreEqual(3, _tipoPertenceService.ObterTodos().Count());
			var tipoPertence = _tipoPertenceService.Obter(3);
			Assert.AreEqual("Celular", tipoPertence.Nome);
		}


		[TestMethod()]
		public void RemoverTest()
		{
			// Act
			_tipoPertenceService.Remover(2);
            // Assert
            Assert.AreEqual(1, _tipoPertenceService.ObterTodos().Count());
			var tipoPertence = _tipoPertenceService.Obter(2);
			Assert.AreEqual(null, tipoPertence);
		}

		[TestMethod()]
		public void ObterTodosTest()
		{
			// Act
			var listaTipoPertence = _tipoPertenceService.ObterTodos();
			// Assert
			Assert.IsInstanceOfType(listaTipoPertence, typeof(IEnumerable<Tipopertence>));
			Assert.IsNotNull(listaTipoPertence);
			Assert.AreEqual(2, listaTipoPertence.Count());
			Assert.AreEqual(1, listaTipoPertence.First().IdTipoPertence);
			Assert.AreEqual("Moto", listaTipoPertence.First().Nome);
		}


		[TestMethod()]
		public void ObterTest()
		{
			var comentario = _tipoPertenceService.Obter(1);
			Assert.IsNotNull(comentario);
			Assert.AreEqual("Moto", comentario.Nome);
		}

	}
}