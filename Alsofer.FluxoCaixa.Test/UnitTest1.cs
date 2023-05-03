using Alsofer.FluxoCaixa.Application.Services.Interfaces;
using Alsofer.FluxoCaixa.Application.Services.Wrappers;
using Alsofer.FluxoCaixa.Domain.Entities;
using Alsofer.FluxoCaixa.Domain.Model;
using Moq;

namespace Alsofer.FluxoCaixa.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            Assert.Pass();
        }

        [Test]
        public void TestListarCliente()
        {

            var mockRepo = new Mock<IClienteServices>();
            var response = mockRepo.Setup(x => x.ListarClientes().Result);

            Assert.IsNotNull(response);
            Assert.Pass("Ok");
        }

        [Test]
        public void TestAdiconarCliente()
        {

            ClienteRequest clienteRequest = new ClienteRequest();
            clienteRequest.cliente = new Cliente()
            {
                nomeCliente = "Teste",
                ativo = true,
                nmUsuarioAlteracao = "teste "
            };

            var mockRepo = new Mock<IClienteServices>();
            var response = mockRepo.Setup(x => x.AdicionarClientes(clienteRequest).Result);

            Assert.IsNotNull(response);
            Assert.Pass("Ok");
        }
    }
}