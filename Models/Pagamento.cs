using RimacAutomobill.Enums;

namespace RimacAutomobill.Models
{
    public class Pagamento
    {
        public int IdPagamento { get; set; }

        public int IdPedido { get; set; }

        public decimal Valor { get; set; }

        public FormaPagamento FormaPagamento { get; set; }

        public StatusPagamento Status { get; set; }

        public DateTime? DataPagamento { get; set; }
    }
}