using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SosCidadaoWeb.Controllers;
using SosCidadaoWeb.Mappers;
using SosCidadaoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SosCidadaoWeb.Controllers.Tests
{
	[TestClass()]
	public class TipoocorrenciaControllerTests
	{
		private static TipoocorrenciaController controller;


		[ClassInitialize]
		public static void Initialize(TestContext testContext)
		{
			// Arrange
			var mockService = new Mock<ITipoocorrenciaService>();
			var mockOrganizacaoService = new Mock<IOrganizacaoService>();

			IMapper mapper = new MapperConfiguration(cfg =>
				cfg.AddProfile(new TipoocorrenciaProfile())).CreateMapper();

			mockService.Setup(service => service.ObterTodos())
				.Returns(GetTestTipoocorrencias());
			mockService.Setup(service => service.Obter(1))
				.Returns(GetTargetTipoocorrencia());
			mockService.Setup(service => service.Atualizar(It.IsAny<Tipoocorrencia>()))
				.Verifiable();
			mockService.Setup(service => service.Inserir(It.IsAny<Tipoocorrencia>()))
				.Verifiable();
			controller = new TipoocorrenciaController(mockService.Object, mockOrganizacaoService.Object, mapper);
		}

		[TestMethod()]
		public void IndexTest()
		{
			// Act
			var result = controller.Index();

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<TipoocorrenciaModel>));
			List<TipoocorrenciaModel> lista = (List<TipoocorrenciaModel>)viewResult.ViewData.Model;
			Assert.AreEqual(3, lista.Count);
		}

		[TestMethod()]
		public void DetailsTest()
		{
			// Act
			var result = controller.Details(1);

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(TipoocorrenciaModel));
			TipoocorrenciaModel tipoocorrenciaModel = (TipoocorrenciaModel)viewResult.ViewData.Model;
			Assert.AreEqual(13, tipoocorrenciaModel.IdTipoOcorrencia);
			Assert.AreEqual("Violencia", tipoocorrenciaModel.Nome);
			Assert.AreEqual(10, tipoocorrenciaModel.IdOrganizacao);
		}

		[TestMethod()]
		public void CreateTest()
		{
			// Act
			var result = controller.Create();
			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
		}

		[TestMethod()]
		public void CreateTest_Valid()
		{
			// Act
			var result = controller.Create(GetNewTipoocorrencia());

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		[TestMethod()]
		public void CreateTest_InValid()
		{
			// Arrange
			controller.ModelState.AddModelError("Nome", "Campo requerido");

			// Act
			var result = controller.Create(GetNewTipoocorrencia());

			// Assert
			Assert.AreEqual(1, controller.ModelState.ErrorCount);
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		[TestMethod()]
		public void EditTest_Post()
		{
			// Act
			var result = controller.Edit(1);

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(TipoocorrenciaModel));
			TipoocorrenciaModel tipoocorrenciaModel = (TipoocorrenciaModel)viewResult.ViewData.Model;
			Assert.AreEqual("Violencia", tipoocorrenciaModel.Nome);
			Assert.AreEqual(10, tipoocorrenciaModel.IdOrganizacao);
		}

		[TestMethod()]
		public void EditTest_Get()
		{
			// Act
			var result = controller.Edit((int)GetTargetTipoocorrenciaModel().IdTipoOcorrencia, GetTargetTipoocorrenciaModel());

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		[TestMethod()]
		public void DeleteTest_Post()
		{
			// Act
			var result = controller.Delete(1);

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(TipoocorrenciaModel));
			TipoocorrenciaModel tipoocorrenciaModel = (TipoocorrenciaModel)viewResult.ViewData.Model;
			Assert.AreEqual("Violencia", tipoocorrenciaModel.Nome);
			Assert.AreEqual(10, tipoocorrenciaModel.IdOrganizacao);
		}

		[TestMethod()]
		public void DeleteTest_Get()
		{
			// Act
			var result = controller.Delete((int)GetTargetTipoocorrenciaModel().IdTipoOcorrencia, GetTargetTipoocorrenciaModel());

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		private static TipoocorrenciaModel GetNewTipoocorrencia()
		{
			return new TipoocorrenciaModel
			{
				IdTipoOcorrencia = 17,
				Nome = "Violacao do Patrimonio",
				IdOrganizacao = 10
			};

		}
		private static Tipoocorrencia GetTargetTipoocorrencia()
		{
			return new Tipoocorrencia
			{
				IdTipoOcorrencia = 16,
				Nome = "Desordem",
				IdOrganizacao = 10
			};
		}

		private static TipoocorrenciaModel GetTargetTipoocorrenciaModel()
		{
			return new TipoocorrenciaModel
			{
				IdTipoOcorrencia = 15,
				Nome = "Pertubacao",
				IdOrganizacao = 10
			};
		}

		private static IEnumerable<Tipoocorrencia> GetTestTipoocorrencias()
		{
			return new List<Tipoocorrencia>
			{
				new Tipoocorrencia
				{
					IdTipoOcorrencia = 12,
					Nome = "Assalto",
					IdOrganizacao =10
				},
				new Tipoocorrencia
				{
					IdTipoOcorrencia = 13,
					Nome = "Violencia",
					IdOrganizacao =10
				},
				new Tipoocorrencia
				{
					IdTipoOcorrencia = 14,
					Nome = "Vandalismo",
					IdOrganizacao =10
				},
			};
		}
	}
}