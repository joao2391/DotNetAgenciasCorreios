using System.Net.Http;
using System.Threading.Tasks;

namespace DotNet.Agencias.Correios
{
    /// <summary>
    /// Classe utilizada para abstrair as chamadas HTTP
    /// </summary>
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly HttpClient _client;

        /// <summary>
        /// Construtor padrão
        /// </summary>
        public HttpClientWrapper()
        {
            _client = new HttpClient();
        }

        /// <summary>
        /// Realiza a chamada GET para a url
        /// dos Correios
        /// </summary>
        /// <param name="uf">UF do Estado</param>
        /// <param name="municipio">Município</param>
        /// <param name="bairro">Bairro</param>
        /// <returns>Task de HttpResponseMessage</returns>
        public virtual async Task<HttpResponseMessage> GetAsync(string uf, string municipio, string bairro)
        {
            var req = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new System.Uri($"https://buscaagencia.correios.com.br/app/carrega/carrega_agencia_localidade.php?cmbEstado={uf}&cmbMunicipio={municipio}&cmbBairro={bairro}")
            };

            var result = await _client.SendAsync(req).ConfigureAwait(false);

            return result;

        }
    }
}
