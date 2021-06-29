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
    public class TipoocorrenciaServiceTests
    {
		private SosCidadaoContext _context;
		private ITipoocorrenciaService _tipoocorrenciaService;

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
			var Tiposocorrencias = new List<Tipoocorrencia>
				{
					new Tipoocorrencia { Nome = "Roubo", IdOrganizacao = 1,},
					new Tipoocorrencia { Nome = "Furto", IdOrganizacao = 1,},
				};

			_context.AddRange(Tiposocorrencias);
			_context.SaveChanges();

			_tipoocorrenciaService = new TipoocorrenciaService(_context);
		}


		[TestMethod()]
		public void InserirTest()
		{
			// Act
			_tipoocorrenciaService.Inserir( new Tipoocorrencia { Nome = "Homicidio", IdOrganizacao = 1});
			// Assert
			Assert.AreEqual(3, _tipoocorrenciaService.ObterTodos().Count());
			var Tipoocorrencia = _tipoocorrenciaService.Obter(3);
			Assert.AreEqual("Homicidio", Tipoocorrencia.Nome);
		}


		[TestMethod()]
		public void RemoverTest()
		{
			// Act
			_tipoocorrenciaService.Remover(2);
            // Assert
            Assert.AreEqual(1, _tipoocorrenciaService.ObterTodos().Count());
			var Tipoocorrencia = _tipoocorrenciaService.Obter(2);
			Assert.AreEqual(null, Tipoocorrencia);
		}

		[TestMethod()]
		public void ObterTodosTest()
		{
			// Act
			var listaTipoocorrencia = _tipoocorrenciaService.ObterTodos();
			// Assert
			Assert.IsInstanceOfType(listaTipoocorrencia, typeof(IEnumerable<Tipoocorrencia>));
			Assert.IsNotNull(listaTipoocorrencia);
			Assert.AreEqual(2, listaTipoocorrencia.Count());
			Assert.AreEqual(1, listaTipoocorrencia.First().IdTipoOcorrencia);
			Assert.AreEqual("Roubo", listaTipoocorrencia.First().Nome);
		}


		[TestMethod()]
		public void ObterTest()
		{
			var Tipoocorrencia = _tipoocorrenciaService.Obter(1);
			Assert.IsNotNull(Tipoocorrencia);
			Assert.AreEqual("Roubo", Tipoocorrencia.Nome);
		}

	}
}