using System.Net.Http;
using System.Threading.Tasks;

namespace DotNet.Agencias.Correios
{
    public interface IHttpClientWrapper
    {
        Task<HttpResponseMessage> GetAsync(string uf, string municipio, string bairro);
    }
}
