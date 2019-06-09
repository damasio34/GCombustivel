using System.Collections.Generic;

namespace Damasio34.GCombustivel.Dominio
{
    public class Veiculo
    {
        public Veiculo(int codigo, int quilometroPorLitro)
        {
            this.Codigo = codigo;
            this.QuilometroPorLitro = quilometroPorLitro;
        }

        public int Codigo { get; }
        public int QuilometroPorLitro { get; }
        public List<Trecho> Trechos { get; private set; } = new List<Trecho>();
    }
}
