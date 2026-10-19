
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using RimacAutomobill.Enums;
using RimacAutomobill.Models;

namespace RimacAutomobill.Services
{
    public class PagamentoCsvService
    {
        public void Salvar(
            List<Pagamento> pagamentos,
            string caminhoArquivo)
        {
            List<string> linhas = new()
            {
                "IdPagamento,IdPedido,Valor,FormaPagamento,Status,DataPagamento"
            };

            foreach (Pagamento pagamento in pagamentos)
            {
                string linha =
                    $"{pagamento.IdPagamento}," +
                    $"{pagamento.IdPedido}," +
                    $"{pagamento.Valor.ToString(CultureInfo.InvariantCulture)}," +
                    $"{pagamento.FormaPagamento}," +
                    $"{pagamento.Status}," +
                    $"{pagamento.DataPagamento?.ToString("O", CultureInfo.InvariantCulture)}";

                linhas.Add(linha);
            }

            File.WriteAllLines(caminhoArquivo, linhas);
        }

        public List<Pagamento> Ler(string caminhoArquivo)
        {
            List<Pagamento> pagamentos = new();

            if (!File.Exists(caminhoArquivo))
            {
                return pagamentos;
            }

            string[] linhas = File.ReadAllLines(caminhoArquivo);

            for (int i = 1; i < linhas.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(linhas[i]))
                {
                    continue;
                }

                string[] dados = linhas[i].Split(',');

                Pagamento pagamento = new()
                {
                    IdPagamento = int.Parse(dados[0]),
                    IdPedido = int.Parse(dados[1]),

                    Valor = decimal.Parse(
                        dados[2],
                        CultureInfo.InvariantCulture),

                    FormaPagamento = Enum.Parse<FormaPagamento>(dados[3]),
                    Status = Enum.Parse<StatusPagamento>(dados[4]),

                    DataPagamento =
                        string.IsNullOrWhiteSpace(dados[5])
                            ? null
                            : DateTime.Parse(
                                dados[5],
                                CultureInfo.InvariantCulture,
                                DateTimeStyles.RoundtripKind)
                };

                pagamentos.Add(pagamento);
            }

            return pagamentos;
        }
    }
}
