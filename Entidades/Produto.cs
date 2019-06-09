using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Produto
    {
        public string codigo { get; set; }
        private int Id { get; set; }
        public string Descricao { get; set; }
        public int MinStock { get; set; }
        public int MaxStock { get; set; }
        public int StockAtual { get; set; }
        public string Tipo { get; set; }
    }
}
