
using Microsoft.AspNetCore.Mvc.RazorPages;
using RimacAutomobill.Models;
using RimacAutomobill.Services;
using System.Collections.Generic;
using System.IO;

namespace RimacAutomobill.Pages
{
    public class IndexModel : PageModel
    {
        public List<Carro> Carros { get; set; } = new();

        public void OnGet()
        {
            string caminho = Path.Combine(
                Directory.GetCurrentDirectory(),
                "carros.csv"
            );

            CarroCsvService servico = new();

            Carros = servico.Ler(caminho);
        }
    }
}
