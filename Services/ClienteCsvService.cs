using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using RimacAutomobill.Models;

namespace RimacAutomobill.Services
{
    public class ClienteCsvService
    {
        public void Salvar(List<Cliente> clientes, string caminhoArquivo)
        {
            List<string> linhas = new()
            {
                "IdCliente,Nome,CPF,DataRegistro"
            };

            foreach (Cliente cliente in clientes)
            {
                string linha =
                    $"{cliente.IdCliente},{cliente.Nome},{cliente.CPF}," +
                    cliente.DataRegistro.ToString("O", CultureInfo.InvariantCulture);

                linhas.Add(linha);
            }

            File.WriteAllLines(caminhoArquivo, linhas);
        }

        public List<Cliente> Ler(string caminhoArquivo)
        {
            List<Cliente> clientes = new();

            if (!File.Exists(caminhoArquivo))
            {
                return clientes;
            }

            string[] linhas = File.ReadAllLines(caminhoArquivo);

            for (int i = 1; i < linhas.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(linhas[i]))
                {
                    continue;
                }

                string[] dados = linhas[i].Split(',');

                Cliente cliente = new()
                {
                    IdCliente = int.Parse(dados[0]),
                    Nome = dados[1],
                    CPF = dados[2],
                    DataRegistro = DateTime.Parse(
                        dados[3],
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.RoundtripKind
                    )
                };

                clientes.Add(cliente);
            }

            return clientes;
        }
    }
}