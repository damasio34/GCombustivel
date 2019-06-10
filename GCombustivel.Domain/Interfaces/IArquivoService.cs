using System.Collections.Generic;

namespace Damasio34.GCombustivel.Dominio.Interfaces
{
    public interface IArquivoService
    {
        void EscreverArquivoDeSaida(IEnumerable<string> linhas, string nomeDoArquivo);
        Queue<string> LerArquivoDeEntrada(string nomeDoArquivo);
    }
}