using System.Net.Http;
using System.Threading.Tasks;

namespace DotNet.Agencias.Correios
{
    /// <summary>
    /// Interface do HttpClientWrapper
    /// </summary>
    public interface IHttpClientWrapper
    {
        /// <summary>
        /// Método responsável por chamar a url
        /// dos Correios.
        /// </summary>
        /// <param name="uf">UF do Estado</param>
        /// <param name="municipio">Município</param>
        /// <param name="bairro">Bairro</param>
        /// <returns>Task de HttpResponseMessage</returns>
        Task<HttpResponseMessage> GetAsync(string uf, string municipio, string bairro);
    }
}
