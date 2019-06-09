using Aplicacao;
using Damasio34.GCombustivel.Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
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
            var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            var linhas = File.ReadAllLines($"{path}/Inputs/entrada_veiculos_teste.txt");
            var queue = new Queue<string>(linhas);


            var rotaService = new RotaService();
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
            var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            var linhas = File.ReadAllLines($"{path}/Inputs/entrada_trechos_teste.txt");
            var queue = new Queue<string>(linhas);

            var rotaService = new RotaService();
            var veiculo = new Veiculo(1, 7);
            var rota = new Rota(1, veiculo);
            var trechos = rotaService.ObterTrechos(queue, rota, veiculo).ToArray();

            Assert.AreEqual(trechos.Count(), 8);
            Assert.AreEqual(trechos[0].Codigo, "119");
            Assert.AreEqual(trechos[0].Quilometragem, 47);
            Assert.AreEqual(trechos[1].Codigo, "8");
            Assert.AreEqual(trechos[1].Quilometragem, 230);
            Assert.AreEqual(trechos[2].Codigo, "107");
            Assert.AreEqual(trechos[2].Quilometragem, 48);
            Assert.AreEqual(trechos[3].Codigo, "10");
            Assert.AreEqual(trechos[3].Quilometragem, 65);
            Assert.AreEqual(trechos[4].Codigo, "9");
            Assert.AreEqual(trechos[4].Quilometragem, 197);
            Assert.AreEqual(trechos[5].Codigo, "35");
            Assert.AreEqual(trechos[5].Quilometragem, 236);
            Assert.AreEqual(trechos[6].Codigo, "129");
            Assert.AreEqual(trechos[6].Quilometragem, 142);
            Assert.AreEqual(trechos[7].Codigo, "0");
            Assert.AreEqual(trechos[7].Quilometragem, 71);
        }

        [TestMethod]
        public void Obtem_lista_de_rotas()
        {
            var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            var linhas = File.ReadAllLines($"{path}/Inputs/entrada_func_a.txt");
            var queue = new Queue<string>(linhas);


            var rotaService = new RotaService();
            var veiculos = rotaService.ObterVeiculos(queue).ToArray();

            Assert.AreEqual(veiculos.Count(), 3);
            Assert.AreEqual(veiculos[0].Codigo, 1);
            Assert.AreEqual(veiculos[0].QuilometroPorLitro, 7);
            Assert.AreEqual(veiculos[1].Codigo, 2);
            Assert.AreEqual(veiculos[1].QuilometroPorLitro, 8);
            Assert.AreEqual(veiculos[2].Codigo, 3);
            Assert.AreEqual(veiculos[2].QuilometroPorLitro, 10);
        }
    }
}
