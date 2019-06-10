using Damasio34.GCombustivel.Dominio.Exceptions;

namespace Damasio34.GCombustivel.Dominio
{
    public class Trecho
    {
        public Trecho(Roteiro roteiro, string codigo, double quilometragem) : this(codigo, quilometragem)
        {
            roteiro.AdicionarTrecho(this);
        }
        internal Trecho(string cidade, double quilometragem)
        {
            if (quilometragem <= 0) throw new QuilometragemZeradaException();
            this.Quilometragem = quilometragem;
            
            this.Cidade = cidade;
        }

        public double Quilometragem { get; private set; }
        public string Cidade { get; }        
    }
}
