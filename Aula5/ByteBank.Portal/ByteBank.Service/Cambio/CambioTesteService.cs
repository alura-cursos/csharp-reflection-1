using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Service.Cambio
{
    public class CambioTesteService : ICambioService
    {
        private readonly Random _rdm = new Random();

        public decimal Calcular(string moedaOrigem, string moedaDestino, decimal valor) =>
            valor * (decimal)_rdm.NextDouble();
    }
}
