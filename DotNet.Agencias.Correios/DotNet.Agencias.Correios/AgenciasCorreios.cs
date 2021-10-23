using HtmlAgilityPack;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DotNet.Agencias.Correios
{
    /// <summary>
    /// Classe com função que busca informaçãoes das agências dos Correios.
    /// </summary>
    public class AgenciasCorreios : IAgenciasCorreios
    {
        private readonly IHttpClientWrapper _httpClient;
        private readonly HtmlDocument _document;

        /// <summary>
        /// Construtor para instanciar a classe HttpClientWrapper via injeção de dependência.
        /// </summary>
        /// <param name="httpClientWrapper">Objeto HttpClientWrapper</param>
        public AgenciasCorreios(IHttpClientWrapper httpClientWrapper)
        {
            _httpClient = httpClientWrapper;
            _document = new HtmlDocument();
        }

        /// <summary>
        /// Busca as agências localizadas de acordo com
        /// os parâmetros informados.
        /// </summary>
        /// <param name="uf">UF do Estado.</param>
        /// <param name="municipio">Município.</param>
        /// <param name="bairro">Bairro.</param>
        /// <returns>Objeto do tipo Agencias</returns>
        /// <exception cref="HttpRequestException">HttpRequestException</exception>
        /// <exception cref="HtmlWebException">HtmlWebException</exception>
        /// <exception cref="IndexOutOfRangeException">IndexOutOfRangeException</exception>
        /// <exception cref="ArgumentNullException">ArgumentNullException</exception>
        /// 
        public async Task<Agencias> GetAgenciasAsync(string uf, string municipio, string bairro)
        {
            ValidaParametros(uf, municipio, bairro);

            try
            {
                var agencias = await BuildAgenciasAsync(uf, municipio, bairro).ConfigureAwait(false);

                return agencias;
            }
            catch (HttpRequestException)
            {
                throw;
            }
            catch (HtmlWebException)
            {
                throw;
            }
            catch (IndexOutOfRangeException)
            {
                throw;
            }


        }


        private void ValidaParametros(string uf, string municipio, string bairro)
        {
            if (string.IsNullOrEmpty(uf))
            {
                throw new ArgumentNullException(uf, "UF não pode ser vazio");
            }

            if (string.IsNullOrEmpty(municipio))
            {
                throw new ArgumentNullException(municipio, "UF não pode ser vazio");
            }

            if (string.IsNullOrEmpty(bairro))
            {
                throw new ArgumentNullException(bairro, "UF não pode ser vazio");
            }
        }

        private async Task<Agencias> BuildAgenciasAsync(string uf, string municipio, string bairro)
        {
            var response = await _httpClient.GetAsync(uf, municipio, bairro).ConfigureAwait(false);

            var html = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            _document.LoadHtml(html);

            var agencias = _document.DocumentNode.SelectNodes(Constants.NODE_AGENCIAS);

            var quantidade = (agencias[0].ChildNodes.Count - 3) / 2;

            var agenciasObj = new Agencias
            {
                AgenciasEncontradas = new Agencia[quantidade]
            };


            for (int i = 0; i < quantidade; i++)
            {
                var nomeAgencia = _document.DocumentNode.SelectSingleNode($"/table[1]/tbody[1]/tr[{i + 1}]/td[1]/table[1]/tbody[1]/tr[1]/td[1]/span[1]");
                var enderecoAgencia = _document.DocumentNode.SelectSingleNode($"/table[1]/tbody[1]/tr[{i + 1}]/td[1]/table[1]/tbody[1]/tr[1]/td[1]/span[2]");
                var cepAgencia = _document.DocumentNode.SelectSingleNode($"/table[1]/tbody[1]/tr[{i + 1}]/td[1]/table[1]/tbody[1]/tr[1]/td[1]/span[3]/span[1]/span[1]");
                var situacaoAgencia = _document.DocumentNode.SelectSingleNode($"/table[1]/tbody[1]/tr[{i + 1}]/td[1]/table[1]/tbody[1]/tr[1]/td[1]/span[5]");

                agenciasObj.AgenciasEncontradas[i] = new Agencia()
                {
                    Nome = nomeAgencia?.InnerText.Trim(),
                    CEP = cepAgencia?.InnerText.Trim(),
                    Endereco = enderecoAgencia?.InnerText.Trim(),
                    Situacao = situacaoAgencia?.InnerText.Trim()
                };

            }

            return agenciasObj;

        }
    }
}
