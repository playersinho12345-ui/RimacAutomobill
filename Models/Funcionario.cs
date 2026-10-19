namespace RimacAutomobill.Models
{
    public class Funcionario
    {
        public int IdFuncionario { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public DateTime DataAdmissao { get; set; }
    }
}