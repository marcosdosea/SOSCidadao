using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using Core;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SosCidadaoWeb.Controllers;
using Core.Service;
using SosCidadaoWeb.Mappers;
using Core.DTO;
using SosCidadaoWeb.Models;

namespace Controllers.Tests
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

			IMapper mapper = new MapperConfiguration(cfg => cfg.AddProfile(new TipoocorrenciaProfile())).CreateMapper();

			mockService.Setup(service => service.ObterTodosDTO()).Returns(GetTestTipoocorrencia());
			mockService.Setup(service => service.Obter(1)).Returns(GetTargetTipoocorrencia());
			mockService.Setup(service => service.Atualizar(It.IsAny<Tipoocorrencia>())).Verifiable();
			mockService.Setup(service => service.Inserir(It.IsAny<Tipoocorrencia>())).Verifiable();

			var especieAnimalMockService = new Mock<IOrganizacaoService>();

			especieAnimalMockService.Setup(service => service.Obter(1)).Returns(GetTargetOrganizacao());
			especieAnimalMockService.Setup(service => service.ObterTodos()).Returns(GetTestOrganizacao());

			controller = new TipoocorrenciaController(mockService.Object, especieAnimalMockService.Object, mapper);
		}

		[TestMethod]
		public void IndexTest()
		{
			// Act
			var result = controller.Index();

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<TipoocorrenciaDTO>));
			List<TipoocorrenciaDTO> lista = (List<TipoocorrenciaDTO>)viewResult.ViewData.Model;
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
			Assert.AreEqual("Roubo", tipoocorrenciaModel.Nome);
			Assert.AreEqual(1, tipoocorrenciaModel.IdOrganizacao);

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
			Assert.AreEqual("Roubo", tipoocorrenciaModel.Nome);
			Assert.AreEqual(1, tipoocorrenciaModel.IdOrganizacao);
		}

		[TestMethod()]
		public void EditTest_Get()
		{
			// Act
			var result = controller.Edit(GetTargetTipoocorrenciaModel().IdTipoOcorrencia, GetTargetTipoocorrenciaModel());

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
			Assert.AreEqual("Roubo", tipoocorrenciaModel.Nome);
			Assert.AreEqual(1, tipoocorrenciaModel.IdOrganizacao);
		}

		[TestMethod()]
		public void DeleteTest_Get()
		{
			// Act
			var result = controller.Delete(GetTargetTipoocorrenciaModel().IdTipoOcorrencia, GetTargetTipoocorrenciaModel());

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
				IdTipoOcorrencia = 1,
				IdOrganizacao = 1,
				Nome = "Latrocinio",
			};

		}

		private static IEnumerable<Organizacao> GetTestOrganizacao()
		{
			return new List<Organizacao>
			{
				new Organizacao
				{
					IdOrganizacao = 1,
					NomeFantasia = "UFS"
				},
				new Organizacao
				{
					IdOrganizacao = 2,
					NomeFantasia = "IFS"
				},
			};
		}

		private static Organizacao GetTargetOrganizacao()
		{
			return new Organizacao
			{
				IdOrganizacao = 1,
				NomeFantasia = "UFS"
			};
		}

		private static Tipoocorrencia GetTargetTipoocorrencia()
		{
			return new Tipoocorrencia
			{
				IdTipoOcorrencia = 1,
				IdOrganizacao = 1,
				Nome = "Roubo",
			};
		}

		private static TipoocorrenciaModel GetTargetTipoocorrenciaModel()
		{
			return new TipoocorrenciaModel
			{
				IdTipoOcorrencia = 1,
				IdOrganizacao = 1,
				Nome = "Roubo",
			};
		}

		private static IEnumerable<TipoocorrenciaDTO> GetTestTipoocorrencia()
		{
			return new List<TipoocorrenciaDTO>
			{
				new TipoocorrenciaDTO
				{
					IdTipoOcorrencia = 1,
					Nome = "Roubo",
					IdOrganizacao = 1,
				},
				new TipoocorrenciaDTO
				{
					IdTipoOcorrencia = 2,
					Nome = "Furto",
					IdOrganizacao = 1,
				},
				new TipoocorrenciaDTO
				{
					IdTipoOcorrencia = 3,
					Nome = "Homicidio",
					IdOrganizacao = 1,
				},
			};
		}
	}
}