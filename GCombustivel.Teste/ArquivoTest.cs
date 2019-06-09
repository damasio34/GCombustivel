using Aplicacao;
using Damasio34.GCombustivel.Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Damasio34.GCombustivel.Teste
{
    [TestClass]
    public class ArquivoTest
    {
        [TestMethod]
        public void Ler_arquivo_de_entrada()
        {
            var arquivoService = new ArquivoService();
            var queue = arquivoService.LerArquivoDeEntrada("entrada_veiculos_teste.txt");

            Assert.IsNotNull(queue);
            Assert.AreEqual(queue.Count(), 5);
        }

        //1.    A primeira linha possui um número inteiro "D" com a quantidade de dias do relatorio
        //2.    A partir da segunda linha do arquivo, o seguinte padrão se repetirá "D" vezes:
        //2.1   Um número inteiro com o código do veículo(do arquivo de entrada), seguido de um espaço em branco e um número
        //     fracionário, com 2 casas decimais, com a média do consumo total do veículo no dia.
        //2.3   Uma linha em branco para determinar o fim do bloco
        [TestMethod]
        public void Escrever_arquivo_de_saida()
        {
            var arquivoService = new ArquivoService();
            var rotaService = new RotaService();

            var queue = arquivoService.LerArquivoDeEntrada("entrada_rotas_teste.txt");
            var veiculos = new List<Veiculo>()
            {
                new Veiculo(1, 7),
                new Veiculo(2, 8),
                new Veiculo(3, 10),
            };
            var rotas = rotaService.ObterRotas(queue, veiculos);

            var linhas = rotaService.EscreverRelatorio(arquivoService, "saida_teste.txt", rotas).ToArray();

            Assert.IsNotNull(linhas);
            Assert.AreEqual(linhas[0], "3");
            Assert.AreEqual(linhas[1], "1 19.57");
            Assert.AreEqual(linhas[2], "2 73.75");
            Assert.AreEqual(linhas[3], "3 20.70");
            Assert.AreEqual(linhas[4], "");
            Assert.AreEqual(linhas[5], "1 9.14");
            Assert.AreEqual(linhas[6], "2 14.87");
            Assert.AreEqual(linhas[7], "3 22.70");
            Assert.AreEqual(linhas[8], "");
            Assert.AreEqual(linhas[9], "1 8.00");
            Assert.AreEqual(linhas[10], "2 10.87");
            Assert.AreEqual(linhas[11], "3 29.00");
            Assert.AreEqual(linhas[12], "");
        }
    }
}
