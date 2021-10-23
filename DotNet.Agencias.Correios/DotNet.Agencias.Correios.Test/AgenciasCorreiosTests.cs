using Moq;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DotNet.Agencias.Correios.Test
{
    public class AgenciasCorreiosTests
    {
        private AgenciasCorreios _agenciasCorreios;
        private readonly string fakeContent = string.Empty;

        public AgenciasCorreiosTests()
        {
            fakeContent = File.ReadAllText(@".\FakeData.html");
        }

        [Fact]
        public async Task Should_Return_Agencias_From_GetAgenciasAsync()
        {
            var mockHttp = new Mock<IHttpClientWrapper>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(fakeContent)
            };

            mockHttp.Setup(x => x.GetAsync(Constants.UF_AGENCIA_SP, Constants.MUNICIPIO_AGENCIA_SP, Constants.BAIRRO_AGENCIA_SP)).ReturnsAsync(response);

            _agenciasCorreios = new AgenciasCorreios(mockHttp.Object);

            var result = await _agenciasCorreios.GetAgenciasAsync(Constants.UF_AGENCIA_SP, Constants.MUNICIPIO_AGENCIA_SP, Constants.BAIRRO_AGENCIA_SP);

            Assert.NotNull(result);
            Assert.IsType<Agencias>(result);
            Assert.IsType<Agencia>(result.AgenciasEncontradas[0]);
            Assert.Equal(Constants.SEIS, result.AgenciasEncontradas.Length);
            Assert.Equal(Constants.CEP_AGENCIA_SP, result.AgenciasEncontradas[0].CEP);

        }

    }
}
