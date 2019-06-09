using System.Collections.Generic;
using System.IO;

namespace Aplicacao
{
    public class ArquivoService
    {
        private readonly string _path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

        public Queue<string> LerArquivoDeEntrada(string nomeDoArquivo)
        {
            var linhas = File.ReadAllLines($"{_path}/Inputs/{nomeDoArquivo}");
            var queue = new Queue<string>(linhas);

            return queue;
        }
        public void EscreverArquivoDeSaida(Queue<string> linhas, string nomeDoArquivo)
        {
            File.WriteAllLines($"{_path}/Inputs/{nomeDoArquivo}", linhas);
        }
    }
}
