
using RimacAutomobill.Enums;

namespace RimacAutomobill.Models
{
    public class PedidoAluguel
    {
        public int IdPedido { get; set; }

        public int IdCliente { get; set; }
        public int IdCarro { get; set; }
        public int? IdFuncionarioValidador { get; set; }

        public DateTime DataPedido { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public decimal ValorTotal { get; set; }

        public StatusPedido Status { get; set; }

        public DateTime? DataValidacao { get; set; }
    }
}
