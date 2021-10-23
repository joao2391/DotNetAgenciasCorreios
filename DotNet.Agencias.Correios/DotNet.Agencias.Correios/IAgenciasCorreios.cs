using System.Threading.Tasks;

namespace DotNet.Agencias.Correios
{
    /// <summary>
    /// Interface para a classe AgenciasCorreios
    /// </summary>
    public interface IAgenciasCorreios
    {
        /// <summary>
        /// Método responsável por chamar a url
        /// dos Correios.
        /// </summary>
        /// <param name="uf">UF do Estado</param>
        /// <param name="municipio">Município</param>
        /// <param name="bairro">Bairro</param>
        /// <returns>Task de Agencias</returns>
        Task<Agencias> GetAgenciasAsync(string uf, string municipio, string bairro);
    }
}
