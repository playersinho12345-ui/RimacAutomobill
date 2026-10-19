namespace RimacAutomobill.Models
{
    public class Carro
    {
        public int IdCarro { get; set; }
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public int AnoFabricacao { get; set; }
        public int Quilometragem { get; set; }
        public decimal ValorDiaria { get; set; }
    }
}