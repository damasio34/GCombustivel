using Damasio34.GCombustivel.Dominio.Exceptions;
using System;

namespace Damasio34.GCombustivel.Dominio
{
    public class Trecho
    {
        [Obsolete]
        public Trecho(Veiculo veiculo, string codigo, double quilometragem) : this(codigo, quilometragem)
        {
            veiculo.Trechos.Add(this);
        }

        internal Trecho(string codigo, double quilometragem)
        {
            if (quilometragem <= 0) throw new QuilometragemZeradaException();
            this.Quilometragem = quilometragem;
            
            this.Codigo = codigo;
        }

        public double Quilometragem { get; private set; }
        public string Codigo { get; }        
    }
}
