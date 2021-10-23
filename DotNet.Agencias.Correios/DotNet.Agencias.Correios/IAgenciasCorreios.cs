using System.Threading.Tasks;

namespace DotNet.Agencias.Correios
{
    public interface IAgenciasCorreios
    {
        Task<Agencias> GetAgenciasAsync(string uf, string municipio, string bairro);
    }
}
