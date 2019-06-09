using Aplicacao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
