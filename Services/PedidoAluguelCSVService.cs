
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using RimacAutomobill.Enums;
using RimacAutomobill.Models;

namespace RimacAutomobill.Services
{
    public class PedidoAluguelCsvService
    {
        public void Salvar(
            List<PedidoAluguel> pedidos,
            string caminhoArquivo)
        {
            List<string> linhas = new()
            {
                "IdPedido,IdCliente,IdCarro,IdFuncionarioValidador," +
                "DataPedido,DataInicio,DataFim,ValorTotal,Status," +
                "DataValidacao"
            };

            foreach (PedidoAluguel pedido in pedidos)
            {
                string linha =
                    $"{pedido.IdPedido}," +
                    $"{pedido.IdCliente}," +
                    $"{pedido.IdCarro}," +
                    $"{pedido.IdFuncionarioValidador}," +
                    $"{pedido.DataPedido.ToString("O", CultureInfo.InvariantCulture)}," +
                    $"{pedido.DataInicio.ToString("O", CultureInfo.InvariantCulture)}," +
                    $"{pedido.DataFim.ToString("O", CultureInfo.InvariantCulture)}," +
                    $"{pedido.ValorTotal.ToString(CultureInfo.InvariantCulture)}," +
                    $"{pedido.Status}," +
                    $"{pedido.DataValidacao?.ToString("O", CultureInfo.InvariantCulture)}";

                linhas.Add(linha);
            }

            File.WriteAllLines(caminhoArquivo, linhas);
        }

        public List<PedidoAluguel> Ler(string caminhoArquivo)
        {
            List<PedidoAluguel> pedidos = new();

            if (!File.Exists(caminhoArquivo))
            {
                return pedidos;
            }

            string[] linhas = File.ReadAllLines(caminhoArquivo);

            for (int i = 1; i < linhas.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(linhas[i]))
                {
                    continue;
                }

                string[] dados = linhas[i].Split(',');

                PedidoAluguel pedido = new()
                {
                    IdPedido = int.Parse(dados[0]),
                    IdCliente = int.Parse(dados[1]),
                    IdCarro = int.Parse(dados[2]),

                    IdFuncionarioValidador =
                        string.IsNullOrWhiteSpace(dados[3])
                            ? null
                            : int.Parse(dados[3]),

                    DataPedido = DateTime.Parse(
                        dados[4], CultureInfo.InvariantCulture),

                    DataInicio = DateTime.Parse(
                        dados[5], CultureInfo.InvariantCulture),

                    DataFim = DateTime.Parse(
                        dados[6], CultureInfo.InvariantCulture),

                    ValorTotal = decimal.Parse(
                        dados[7], CultureInfo.InvariantCulture),

                    Status = Enum.Parse<StatusPedido>(dados[8]),

                    DataValidacao =
                        string.IsNullOrWhiteSpace(dados[9])
                            ? null
                            : DateTime.Parse(
                                dados[9],
                                CultureInfo.InvariantCulture,
                                DateTimeStyles.RoundtripKind)
                };

                pedidos.Add(pedido);
            }

            return pedidos;
        }
    }
}
