using System.Linq;

namespace Damasio34.GCombustivel.Dominio
{
    public class Rota
    {
        public Rota(int dia, Veiculo veiculo, params Trecho[] trechos)
        {
            this.Dia = dia;            
            this.Trechos = trechos;

            veiculo.AdiconarRota(this);
            this.Veiculo = veiculo;
        }

        public int Dia { get; }
        public Veiculo Veiculo { get; }
        public Trecho[] Trechos { get; }

        public double ConsumoMedio => this.Trechos.Sum(p => p.Quilometragem) / Veiculo.QuilometroPorLitro;
    }
}
