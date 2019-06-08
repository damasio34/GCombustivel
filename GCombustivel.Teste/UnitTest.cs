using Damasio34.GCombustivel.Dominio;
using Damasio34.GCombustivel.Dominio.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Damasio34.GCombustivel.Teste
{
    [TestClass]
    public class UnitTest
    {        
        [TestMethod]
        [ExpectedException(typeof(QuilometragemZeradaException))]
        public void Nao_Deve_Existir_Trecho_Com_Km_Zero()
        {
            new Trecho("A", 0);            
        }
        public void Deve_Haver_Apenas_Uma_Rota_Por_Carro()
        {
            //var rota = new Rota();
            //var veiculo = new Veiculo(rota);
        }
        //MEDIA_CARRO_X_TRECHO_J = KILOMETRAGEM_TRECHO_PRA_CIDADE_J / CONSUMO_CARRO_X
        //media do carro A, no dia 1, trecho até CIDADE A = 35 km / 7 km/l = 5 litros
        [TestMethod]
        public void Media_consumo_ate_cidade_a()
        {
            var veiculo = new Veiculo(1, 7);
            var trecho = new Trecho("A", 35);
            var rota = new Rota(1, veiculo, trecho);

            Assert.AreEqual(rota.ConsumoMedio, 5, 0.1);
        }
        //media do carro A, no dia 1, trecho até CIDADE B = 80 km / 7 km/l = 11.42857 litros
        [TestMethod]
        public void Media_consumo_ate_cidade_b()
        {
            var veiculo = new Veiculo(1, 7);
            var trecho = new Trecho("B", 80);
            var rota = new Rota(1, veiculo, trecho);

            Assert.AreEqual(rota.ConsumoMedio, 11.42857, 0.1);
        }
        //media do carro A, no dia 1, trecho de VOLTA = 22 km / 7 km/l = 3.142857 litros
        [TestMethod]
        public void Media_consumo_ate_cidade_c()
        {
            var veiculo = new Veiculo(1, 7);
            var trecho = new Trecho("C", 22);
            var rota = new Rota(1, veiculo, trecho);

            Assert.AreEqual(rota.ConsumoMedio, 3.142857, 0.1);
        }

        //MEDIA_CARRO_X_NO DIA_Z = 
        //MEDIA_CARRO_X_TRECHO_PRA_CIDADE_A + MEDIA_CARRO_X_TRECHO_PRA_CIDADE_B + ... 
        //+ MEDIA_CARRO_X_TRECHO_PRA_CIDADE_N + MEDIA_CARRO_X_TRECHO_VOLTA
        //media do carro A no dia 1 = 5 + 11.42857 + 3.142857 = 19,57142857
        [TestMethod]
        public void Media_consumo_por_dia()
        {
            var veiculo = new Veiculo(1, 7);
            var trechoA = new Trecho("A", 35);
            var trechoB = new Trecho("B", 80);
            var trechoC = new Trecho("C", 22);
            var rota = new Rota(1, veiculo, trechoA, trechoB, trechoC);            

            Assert.AreEqual(rota.ConsumoMedio, 19.57142857, 0.1);
        }

        //1.    A primeira linha possui um número inteiro "D" com a quantidade de dias do relatorio
        //2.    A partir da segunda linha do arquivo, o seguinte padrão se repetirá "D" vezes:
        //2.1   Um número inteiro com o código do veículo(do arquivo de entrada), seguido de um espaço em branco e um número
        //     fracionário, com 2 casas decimais, com a média do consumo total do veículo no dia.
        //2.3   Uma linha em branco para determinar o fim do bloco
        public void FatiarArquivoDeSaida()
        {
            var quantidadeDeDias = 2;

        }
    }
}
