using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class FranqueadoVendeProduto
    {
        public string codigo { get; set; }
        public double IdFranqueado { get; set; }
        public int preco { get; set; }
        public int MinStock { get; set; }
        public int MaxStock { get; set; }
        public int StockAtual { get; set; }
        public int VendaAnoAtual { get; set; }
        public DateTime DataUltimaVenda { get; set; }
    }
}
