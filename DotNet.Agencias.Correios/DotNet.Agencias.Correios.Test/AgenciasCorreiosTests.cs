using Moq;
using System;
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
            fakeContent = File.ReadAllText(@"./FakeData.html");
        }

        [Fact]
        public async Task Should_Return_Agencias_From_GetAgenciasAsync_When_All_Params_is_Full()
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

        [Fact]
        public async Task Should_Return_ArgumentNullException_When_Uf_Is_Empty()
        {
            var mockHttp = new Mock<IHttpClientWrapper>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(fakeContent)
            };

            mockHttp.Setup(x => x.GetAsync(Constants.UF_AGENCIA_SP, Constants.MUNICIPIO_AGENCIA_SP, Constants.BAIRRO_AGENCIA_SP)).ReturnsAsync(response);

            _agenciasCorreios = new AgenciasCorreios(mockHttp.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(() => _agenciasCorreios.GetAgenciasAsync("", Constants.MUNICIPIO_AGENCIA_SP, Constants.BAIRRO_AGENCIA_SP));

        }

        [Fact]
        public async Task Should_Return_ArgumentNullException_When_Municipio_Is_Empty()
        {
            var mockHttp = new Mock<IHttpClientWrapper>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(fakeContent)
            };

            mockHttp.Setup(x => x.GetAsync(Constants.UF_AGENCIA_SP, Constants.MUNICIPIO_AGENCIA_SP, Constants.BAIRRO_AGENCIA_SP)).ReturnsAsync(response);

            _agenciasCorreios = new AgenciasCorreios(mockHttp.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(() => _agenciasCorreios.GetAgenciasAsync(Constants.UF_AGENCIA_SP, "", Constants.BAIRRO_AGENCIA_SP));

        }

        [Fact]
        public async Task Should_Return_ArgumentNullException_When_Bairro_Is_Empty()
        {
            var mockHttp = new Mock<IHttpClientWrapper>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(fakeContent)
            };

            mockHttp.Setup(x => x.GetAsync(Constants.UF_AGENCIA_SP, Constants.MUNICIPIO_AGENCIA_SP, Constants.BAIRRO_AGENCIA_SP)).ReturnsAsync(response);

            _agenciasCorreios = new AgenciasCorreios(mockHttp.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(() => _agenciasCorreios.GetAgenciasAsync(Constants.UF_AGENCIA_SP, Constants.MUNICIPIO_AGENCIA_SP, ""));

        }



    }
}
