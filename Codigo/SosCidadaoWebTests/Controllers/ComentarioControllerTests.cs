using AutoMapper;
using Core;
using Core.DTO;
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
    public class ComentarioControllerTests
    {
        private static ComentarioController controller;

        public ComentarioControllerTests(TestContext testContext)
        {
            // Arrange
            var mockService = new Mock<IComentarioService>();

            IMapper mapper = new MapperConfiguration(cfg => cfg.AddProfile(new ComentarioProfile())).CreateMapper();

            mockService.Setup(service => service.ObterTodos())
                .Returns(GetTestComentarios());

            mockService.Setup(service => service.Obter(1))
                .Returns(GetTargetComentario());

            mockService.Setup(service => service.Atualizar(It.IsAny<Comentario>()))
                .Verifiable();

            mockService.Setup(service => service.Inserir(It.IsAny<Comentario>()))
                .Verifiable();

            controller = new ComentarioController(mockService.Object, mapper);

        }


        private static IEnumerable<Comentario> GetTestComentarios()
        {
            return new List<Comentario>
            {
                new Comentario
                {
                    IidPessoa = 1,
                    IdOcorrencia = 1,
                    Descricao = "O carro roubado tinha um amassado na porta direita.",
                    DataCadastro = DateTime.Today,

                },
                new Comentario
                {
                    IidPessoa = 2,
                    IdOcorrencia = 1,
                    Descricao = "Este veículo foi visto perto da Rua das Alameidas próximo ao posto!",
                    DataCadastro = DateTime.Today,

                },
                new Comentario {
                    IidPessoa = 1,
                    IdOcorrencia = 1,
                    Descricao = "A calota da frente é da cor amarela, as demais prata",
                    DataCadastro = DateTime.Today,

                },
            };
        }

        private static Comentario GetTargetComentario()
        {
            return new Comentario
            {
                IidPessoa = 1,
                IdOcorrencia = 1,
                Descricao = "A carro roubado tinha um amassado na porta direita.",
                DataCadastro = DateTime.Today,

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<ComentarioDTO>));
            List<ComentarioDTO> lista = (List<ComentarioDTO>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ComentarioModel));
            ComentarioModel comentarioModel = (ComentarioModel)viewResult.ViewData.Model;
            Assert.AreEqual("O carro roubado tinha um amassado na porta direita.", comentarioModel.Descricao);

        }


    }
}