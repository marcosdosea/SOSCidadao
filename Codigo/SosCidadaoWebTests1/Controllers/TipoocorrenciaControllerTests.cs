using AutoMapper;
using Core;
using Core.DTO;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SosCidadaoWeb.Controllers;
using SosCidadaoWeb.Mappers;
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

            IMapper mapper = new MapperConfiguration(cfg => cfg.AddProfile(new TipoocorrenciaProfile())).CreateMapper();

            mockService.Setup(service => service.ObterTodos()).Returns(GetTestTiposocorrencia());

            mockService.Setup(service => service.Obter(1)).Returns(GetTargetTipoocorrencia());

            mockService.Setup(service => service.Atualizar(It.IsAny<Tipoocorrencia>())).Verifiable();

            mockService.Setup(service => service.Inserir(It.IsAny<Tipoocorrencia>())).Verifiable();

            controller = new TipoocorrenciaController(mockService.Object, mapper);

        }


        private static IEnumerable<Tipoocorrencia> GetTestTiposocorrencia()
        {
            return new List<Tipoocorrencia>
            {
                new Tipoocorrencia
                {
                    IdTipoOcorrencia = 1,
                    Nome = "Roubo",
                    IdOrganizacao = 1,

                },
                new Tipoocorrencia
                {
                    IdTipoOcorrencia = 1,
                    Nome = "Furto",
                    IdOrganizacao = 1,

                },
                new Tipoocorrencia {
                    IdTipoOcorrencia = 1,
                    Nome = "Homicidio",
                    IdOrganizacao = 1,

                },
            };
        }

        private static Tipoocorrencia GetTargetTipoocorrencia()
        {
            return new Tipoocorrencia
            {
                IdTipoOcorrencia = 1,
                Nome = "Roubo",
                IdOrganizacao = 1,

            };
        }


        [TestMethod()]
        public void IndexTest()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;

            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<Tipoocorrencia>));
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

            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(Tipoocorrencia));
            TipoocorrenciaDTO comentarioModel = (TipoocorrenciaDTO)viewResult.ViewData.Model;

            Assert.AreEqual("Roubo", comentarioModel.Nome);

        }
    }
}