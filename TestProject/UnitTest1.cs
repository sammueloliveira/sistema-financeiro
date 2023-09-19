using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sistema_Financeiro.Controllers;

namespace TestProject.Tests
{
    [TestClass]
    public class DespesaControllerTests
    {
        private DespesaController _controller;
        private Mock<IDespesa> _despesaMock;
        private IMapper _mapper;

        [TestInitialize]
        public void Setup()
        {
            _despesaMock = new Mock<IDespesa>();

            // Configurar o AutoMapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Despesa, DespesaViewModel>();
            });
            _mapper = mapperConfig.CreateMapper();

            _controller = new DespesaController(_despesaMock.Object, _mapper);
        }

        [TestMethod]
        public async Task ObterDespesa_WithValidId_ShouldReturnOkResult()
        {
            
            int idDespesa = 1;
            var despesaMock = new Despesa { Id = idDespesa, Valor = 100, Mes = 7, Ano = 2023 };
            _despesaMock.Setup(d => d.GetEntityById(idDespesa)).ReturnsAsync(despesaMock);

            
            var result = await _controller.ObterDespesa(idDespesa) as OkObjectResult;

            
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            var despesaRetornada = result.Value as Despesa;
            Assert.IsNotNull(despesaRetornada);
            Assert.AreEqual(idDespesa, despesaRetornada.Id);
            Assert.AreEqual(100, despesaRetornada.Valor);
        }

        
    }
}
