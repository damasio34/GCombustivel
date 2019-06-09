using Aplicacao;
using Damasio34.GCombustivel.Dominio;
using Damasio34.GCombustivel.Dominio.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Damasio34.GCombustivel.Teste
{
    [TestClass]
    public class RotaTest
    {        
        [TestMethod]
        [ExpectedException(typeof(QuilometragemZeradaException))]
        public void Nao_Deve_Existir_Trecho_Com_Km_Zero()
        {            
            var rota = new Rota(1);
            var veiculo = new Veiculo(1, 7);
            rota.AdicionarTrecho(veiculo, "A", 0);
        }
        [TestMethod]
        [ExpectedException(typeof(VeiculoEmRotaException))]
        public void Deve_Haver_Apenas_Uma_Rota_Por_Carro()
        {
            var rota = new Rota(1);
            var veiculo = new Veiculo(1, 7);
            rota.AdicionarVeiculo(veiculo);
            rota.AdicionarVeiculo(veiculo);

        }
        //MEDIA_CARRO_X_TRECHO_J = KILOMETRAGEM_TRECHO_PRA_CIDADE_J / CONSUMO_CARRO_X
        //media do carro A, no dia 1, trecho até CIDADE A = 35 km / 7 km/l = 5 litros
        [TestMethod]
        public void Media_consumo_ate_cidade_a()
        {
            var rota = new Rota(1);
            var veiculo = new Veiculo(1, 7);
            rota.AdicionarTrecho(veiculo, "A", 35);

            Assert.AreEqual(rota.ConsumoMedio, 5, 0.1);
        }
        //media do carro A, no dia 1, trecho até CIDADE B = 80 km / 7 km/l = 11.42857 litros
        [TestMethod]
        public void Media_consumo_ate_cidade_b()
        {
            var rota = new Rota(1);
            var veiculo = new Veiculo(1, 7);
            rota.AdicionarTrecho(veiculo, "B", 80);

            Assert.AreEqual(rota.ConsumoMedio, 11.42857, 0.1);
        }
        //media do carro A, no dia 1, trecho de VOLTA = 22 km / 7 km/l = 3.142857 litros
        [TestMethod]
        public void Media_consumo_ate_cidade_c()
        {
            var rota = new Rota(1);
            var veiculo = new Veiculo(1, 7);
            rota.AdicionarTrecho(veiculo, "C", 22);

            Assert.AreEqual(rota.ConsumoMedio, 3.142857, 0.1);
        }

        //MEDIA_CARRO_X_NO DIA_Z = 
        //MEDIA_CARRO_X_TRECHO_PRA_CIDADE_A + MEDIA_CARRO_X_TRECHO_PRA_CIDADE_B + ... 
        //+ MEDIA_CARRO_X_TRECHO_PRA_CIDADE_N + MEDIA_CARRO_X_TRECHO_VOLTA
        //media do carro A no dia 1 = 5 + 11.42857 + 3.142857 = 19,57142857
        [TestMethod]
        public void Media_consumo_por_dia()
        {
            var rota = new Rota(1);
            var veiculo = new Veiculo(1, 7);
            rota.AdicionarTrecho(veiculo, "A", 35);
            rota.AdicionarTrecho(veiculo, "B", 80);
            rota.AdicionarTrecho(veiculo, "C", 22);

            Assert.AreEqual(rota.ConsumoMedio, 19.57142857, 0.1);
        }

        [TestMethod]
        public void Obter_lista_de_veiculos()
        {
            var arquivoService = new ArquivoService();
            var rotaService = new RotaService();
            var queue = arquivoService.LerArquivoDeEntrada("entrada_veiculos_teste.txt");
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
        public void Obter_lista_de_trechos()
        {
            var arquivoService = new ArquivoService();
            var rotaService = new RotaService();

            var queue = arquivoService.LerArquivoDeEntrada("entrada_trechos_teste.txt");
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
        public void Obter_lista_de_rotas()
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

            Assert.AreEqual(rotas.Count(), 3);
            Assert.AreEqual(rotas[0].Dia, 1);
            Assert.AreEqual(rotas[0].Roteiros.Count, 3);
            Assert.AreEqual(rotas[0].Roteiros[0].ConsumoMedio, 19.57142857, 0.1);
            Assert.AreEqual(rotas[1].Dia, 2);
            Assert.AreEqual(rotas[1].Roteiros.Count, 3);
            Assert.AreEqual(rotas[2].Dia, 3);
            Assert.AreEqual(rotas[2].Roteiros.Count, 3);
        }
    }
}
