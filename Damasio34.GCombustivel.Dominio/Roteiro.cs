using System.Collections.Generic;
using System.Linq;

namespace Damasio34.GCombustivel.Dominio
{
    public class Roteiro
    {
        private readonly List<Trecho> _trechos = new List<Trecho>();

        public Roteiro(Veiculo veiculo)
        {
            this.Veiculo = veiculo;
        }
        
        public Veiculo Veiculo { get; }
        public IEnumerable<Trecho> Trechos => this._trechos;
        public double ConsumoMedio => this.Trechos.Sum(x => x.Quilometragem / Veiculo.QuilometroPorLitro);

        public void AdicionarTrecho(string cidade, double quilometragem)
        {
            var trecho = new Trecho(cidade, quilometragem);
            this._trechos.Add(trecho);
        }
        internal void AdicionarTrecho(Trecho trecho) => this._trechos.Add(trecho);
    }
}
