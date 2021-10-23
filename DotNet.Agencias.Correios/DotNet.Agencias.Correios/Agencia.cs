namespace DotNet.Agencias.Correios
{
    /// <summary>
    /// Classe Agencia
    /// </summary>
    public class Agencia
    {
        /// <summary>
        /// Nome da Agencia encontrada
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Endereco da Agencia encontrada
        /// </summary>
        public string Endereco { get; set; }
        /// <summary>
        /// CEP da Agencia encontrada
        /// </summary>
        public string CEP { get; set; }
        /// <summary>
        /// Situação da Agencia encontrada
        /// Exemplo:
        /// Aberta ou Fechada
        /// </summary>
        public string Situacao { get; set; }
    }
}
