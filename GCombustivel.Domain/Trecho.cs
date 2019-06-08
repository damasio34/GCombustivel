using Damasio34.GCombustivel.Dominio.Exceptions;
using System;

namespace Damasio34.GCombustivel.Dominio
{
    public class Trecho
    {
        public Trecho(decimal quilometragem)
        {
            if (quilometragem <= 0) throw new QuilometragemZeradaException();
            this.Quilometragem = quilometragem;
        }

        public decimal Quilometragem { get; private set; }
    }
}
