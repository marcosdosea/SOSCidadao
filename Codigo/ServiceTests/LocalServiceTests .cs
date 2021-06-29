using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Service.Tests
{
    [TestClass()]
    public class LocalServiceTests
    {
		private SosCidadaoContext _context;
		private ILocalService _localService;

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
			var tiposLocais = new List<Local>
				{
					new Local { Nome = "UFS", IdOrganizacao = 1,},
					new Local { Nome = "IFS", IdOrganizacao = 1,},
				};

			_context.AddRange(tiposLocais);
			_context.SaveChanges();

			_localService = new LocalService(_context);
		}


		[TestMethod()]
		public void InserirTest()
		{
			// Act
			_localService.Inserir( new Local { Nome = "UFA", IdOrganizacao = 1});
			// Assert
			Assert.AreEqual(3, _localService.ObterTodos().Count());
			var local = _localService.Obter(3);
			Assert.AreEqual("UFA", local.Nome);
		}


		[TestMethod()]
		public void RemoverTest()
		{
			// Act
			_localService.Remover(2);
            // Assert
            Assert.AreEqual(1, _localService.ObterTodos().Count());
			var local = _localService.Obter(2);
			Assert.AreEqual(null, local);
		}

		[TestMethod()]
		public void ObterTodosTest()
		{
			// Act
			var listaLocal = _localService.ObterTodos();
			// Assert
			Assert.IsInstanceOfType(listaLocal, typeof(IEnumerable<Local>));
			Assert.IsNotNull(listaLocal);
			Assert.AreEqual(2, listaLocal.Count());
			Assert.AreEqual(1, listaLocal.First().IdLocal);
			Assert.AreEqual("UFS", listaLocal.First().Nome);
		}


		[TestMethod()]
		public void ObterTest()
		{
			var local = _localService.Obter(1);
			Assert.IsNotNull(local);
			Assert.AreEqual("UFS", local.Nome);
		}

	}
}