using Aplicacao;
using Damasio34.GCombustivel.Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Damasio34.GCombustivel.Teste
{
    [TestClass]
    public class LeituraDeArquivoTest
    {
        [TestMethod]
        public void Ler_arquivo_de_entrada()
        {
            var rotaService = new RotaService();
            var queue = rotaService.LerArquivoDeEntrada("entrada_veiculos_teste.txt");

            Assert.IsNotNull(queue);
            Assert.AreEqual(queue.Count(), 5);
        }

        [TestMethod]
        public void Obtem_lista_de_veiculos()
        {
            var rotaService = new RotaService();
            var queue = rotaService.LerArquivoDeEntrada("entrada_veiculos_teste.txt");
            var veiculos = rotaService.ObterVeiculos(queue).ToArray();

            Assert.AreEqual(veiculos.Count(), 3);
            Assert.AreEqual(veiculos[0].Codigo, 1);
            Assert.AreEqual(veiculos[0].QuilometroPorLitro, 7);
            Assert.AreEqual(veiculos[1].Codigo, 2);
            Assert.AreEqual(veiculos[1].QuilometroPorLitro, 8);
            Assert.AreEqual(veiculos[2].Codigo, 3);
            Assert.AreEqual(veiculos[2].QuilometroPorLitro, 10);

        }

        [TestMethod]
        public void Obtem_lista_de_trechos()
        {
            var rotaService = new RotaService();
            var queue = rotaService.LerArquivoDeEntrada("entrada_trechos_teste.txt");
            var veiculo = new Veiculo(1, 7);
            var roteiro = new Roteiro(veiculo);
            var trechos = rotaService.ObterTrechos(queue, roteiro).ToArray();

            Assert.AreEqual(trechos.Count(), 8);
            Assert.AreEqual(trechos[0].Cidade, "119");
            Assert.AreEqual(trechos[0].Quilometragem, 47);
            Assert.AreEqual(trechos[1].Cidade, "8");
            Assert.AreEqual(trechos[1].Quilometragem, 230);
            Assert.AreEqual(trechos[2].Cidade, "107");
            Assert.AreEqual(trechos[2].Quilometragem, 48);
            Assert.AreEqual(trechos[3].Cidade, "10");
            Assert.AreEqual(trechos[3].Quilometragem, 65);
            Assert.AreEqual(trechos[4].Cidade, "9");
            Assert.AreEqual(trechos[4].Quilometragem, 197);
            Assert.AreEqual(trechos[5].Cidade, "35");
            Assert.AreEqual(trechos[5].Quilometragem, 236);
            Assert.AreEqual(trechos[6].Cidade, "129");
            Assert.AreEqual(trechos[6].Quilometragem, 142);
            Assert.AreEqual(trechos[7].Cidade, "0");
            Assert.AreEqual(trechos[7].Quilometragem, 71);
        }

        [TestMethod]
        public void Obtem_lista_de_rotas()
        {
            var rotaService = new RotaService();
            var queue = rotaService.LerArquivoDeEntrada("entrada_rotas_teste.txt");
            var veiculos = new List<Veiculo>()
            {
                new Veiculo(1, 7),
                new Veiculo(2, 8),
                new Veiculo(3, 10),
            };
            var rotas = rotaService.ObterRotas(queue, veiculos).ToArray();

            Assert.AreEqual(rotas.Count(), 3);
            Assert.AreEqual(rotas[0].Dia, 1);
            Assert.AreEqual(rotas[0].Roteiros.Count, 3);
            Assert.AreEqual(rotas[1].Dia, 2);
            Assert.AreEqual(rotas[1].Roteiros.Count, 3);
            Assert.AreEqual(rotas[2].Dia, 3);
            Assert.AreEqual(rotas[2].Roteiros.Count, 3);
        }
    }
}
