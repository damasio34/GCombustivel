using Damasio34.GCombustivel.Dominio.Exceptions;
using System;

namespace Damasio34.GCombustivel.Dominio
{
    public class Trecho
    {
        public Trecho(string codigo, double quilometragem)
        {
            if (quilometragem <= 0) throw new QuilometragemZeradaException();
            this.Quilometragem = quilometragem;

            this.Codigo = codigo;
        }
        public Trecho(string codigo, double quilometragem, Veiculo veiculo) : this(codigo, quilometragem)
        {
            if (quilometragem <= 0) throw new QuilometragemZeradaException();
            this.Quilometragem = quilometragem;

            this.Codigo = codigo;

            veiculo.AdiconarTrecho(this);
            this.Veiculo = veiculo;            
        }

        public Veiculo Veiculo { get; }
        public double Quilometragem { get; private set; }
        public string Codigo { get; }
    }
}
