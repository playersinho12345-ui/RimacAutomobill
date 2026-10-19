using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using RimacAutomobill.Models;

namespace RimacAutomobill.Services
{
    public class CarroCsvService
    {
        public void Salvar(List<Carro> carros, string caminhoArquivo)
        {
            string cabecalho = "IdCarro,Marca,Modelo,AnoFabricacao,Quilometragem,ValorDiaria";

            List<string> linhas = new List<string>();
            linhas.Add(cabecalho);

            foreach (Carro carro in carros)
            {
                string linha = $"{carro.IdCarro},{carro.Marca},{carro.Modelo},{carro.AnoFabricacao},{carro.Quilometragem},{carro.ValorDiaria.ToString(CultureInfo.InvariantCulture)}";

                linhas.Add(linha);
            }

            File.WriteAllLines(caminhoArquivo, linhas);
        }

        public List<Carro> Ler(string caminhoArquivo)
        {
            List<Carro> carros = new List<Carro>();

            if (!File.Exists(caminhoArquivo))
            {
                return carros;
            }

            string[] linhas = File.ReadAllLines(caminhoArquivo);

            for (int i = 1; i < linhas.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(linhas[i]))
                {
                    continue;
                }

                string[] dados = linhas[i].Split(',');

                Carro carro = new Carro
                {
                    IdCarro = int.Parse(dados[0]),
                    Marca = dados[1],
                    Modelo = dados[2],
                    AnoFabricacao = int.Parse(dados[3]),
                    Quilometragem = int.Parse(dados[4]),
                    ValorDiaria = decimal.Parse(
                        dados[5],
                        CultureInfo.InvariantCulture
                    )
                };

                carros.Add(carro);
            }

            return carros;
        }
    }
}