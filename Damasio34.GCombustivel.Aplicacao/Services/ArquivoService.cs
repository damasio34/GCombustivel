using Damasio34.GCombustivel.Dominio.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace Damasio34.GCombustivel.Aplicacao.Services
{
    public class ArquivoService : IArquivoService
    {
        private readonly string _path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

        public Queue<string> LerArquivoDeEntrada(string nomeDoArquivo)
        {
            var linhas = File.ReadAllLines($"{_path}/Entradas/{nomeDoArquivo}");
            var queue = new Queue<string>(linhas);

            return queue;
        }
        public void EscreverArquivoDeSaida(IEnumerable<string> linhas, string nomeDoArquivo)
            => File.WriteAllLines($"{_path}/Saidas/{nomeDoArquivo}", linhas);
    }
}
