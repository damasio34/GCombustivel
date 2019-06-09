using System.Collections.Generic;
using System.Linq;

namespace Damasio34.GCombustivel.Dominio
{
    public class Roteiro
    {
        public Roteiro(Veiculo veiculo)
        {
            this.Veiculo = veiculo;
        }

        private List<Trecho> _trechos = new List<Trecho>();

        public Veiculo Veiculo { get; }
        public IEnumerable<Trecho> Trechos => this._trechos;

        //public double ConsumoMedio => this.Veiculos.Sum(x => x.Trechos.Sum(p => p.Quilometragem / x.QuilometroPorLitro));
        public void AdicionarTrecho(string cidade, double quilometragem)
        {
            var trecho = new Trecho(cidade, quilometragem);
            this._trechos.Add(trecho);
        }
        public double ConsumoMedio => this.Trechos.Sum(x => x.Quilometragem / Veiculo.QuilometroPorLitro);
    }
}
