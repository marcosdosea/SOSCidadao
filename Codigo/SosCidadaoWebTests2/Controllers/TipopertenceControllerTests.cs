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
    public class TipopertenceControllerTests
    {
        private static TipopertenceController controller;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            // Arrange
            var mockService = new Mock<ITipopertenceService>();

            IMapper mapper = new MapperConfiguration(cfg => cfg.AddProfile(new TipopertenceProfile())).CreateMapper();

            mockService.Setup(service => service.ObterTodos())
                .Returns(GetTestTiposPertence());

            mockService.Setup(service => service.Obter(1))
                .Returns(GetTargetTipoPertence());

            mockService.Setup(service => service.Atualizar(It.IsAny<Tipopertence>()))
                .Verifiable();

            mockService.Setup(service => service.Inserir(It.IsAny<Tipopertence>()))
                .Verifiable();

            controller = new TipopertenceController(mockService.Object, mapper);

        }


        private static IEnumerable<Tipopertence> GetTestTiposPertence()
        {
            return new List<Tipopertence>
            {
                new Tipopertence
                {
                    Nome = "Moto",
                    IdOrganizacao = 1,

                },
                new Tipopertence
                {
                    Nome = "Celular",
                    IdOrganizacao = 1,

                },
                new Tipopertence {
                    Nome = "Carro",
                    IdOrganizacao = 1,

                },
            };
        }

        private static Tipopertence GetTargetTipoPertence()
        {
            return new Tipopertence
            {
                Nome = "Moto",
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<Tipopertence>));
            List<TipopertenceDTO> lista = (List<TipopertenceDTO>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(Tipopertence));
            TipopertenceDTO comentarioModel = (TipopertenceDTO)viewResult.ViewData.Model;
            Assert.AreEqual("Moto", comentarioModel.Nome);

        }
    }
}