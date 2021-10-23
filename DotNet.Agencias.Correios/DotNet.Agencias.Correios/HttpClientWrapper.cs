using System.Net.Http;
using System.Threading.Tasks;

namespace DotNet.Agencias.Correios
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly HttpClient _client;

        public HttpClientWrapper()
        {
            _client = new HttpClient();
        }

        public virtual async Task<HttpResponseMessage> GetAsync(string uf, string municipio, string bairro)
        {
            var req = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new System.Uri($"https://mais.correios.com.br/app/carrega/carrega_agencia_localidade.php?cmbEstado={uf}&cmbMunicipio={municipio}&cmbBairro={bairro}")
            };

            var result = await _client.SendAsync(req).ConfigureAwait(false);

            return result;

        }
    }
}
