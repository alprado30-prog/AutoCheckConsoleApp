using System;
using System.Collections.Generic;
using System.Linq; // ADICIONA ESSA

namespace AutoCheckConsoleApp.Models
{
    public abstract class Veiculo
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public double Km { get; set; }
        public List<ItemVistoria> Checklist { get; set; }

        protected Veiculo(string marca, string modelo, int ano, double km)
        {
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Km = km;
            Checklist = new List<ItemVistoria>();
        }

        public abstract void CriarChecklist();

        public virtual void GerarRelatorio()
        {
            Console.WriteLine("\n========================================");
            Console.WriteLine($"RELATORIO DE VISTORIA - {this.GetType().Name}");
            Console.WriteLine($"Veiculo: {Marca} {Modelo} - {Ano}");
            Console.WriteLine($"KM: {Km}");
            Console.WriteLine("----------------------------------------");

            int totalItens = Checklist.Count;
            int itensBons = Checklist.Count(i => i.Status == "Bom");
            double porcentagem = totalItens > 0 ? (itensBons * 100.0) / totalItens : 0;

            foreach (var item in Checklist)
            {
                Console.WriteLine($"{item.Descricao}: {item.Status}");
            }

            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"APROVACAO: {porcentagem:F1}%");

            string classificacao = porcentagem >= 80 ? "APROVADO" : 
                                  porcentagem >= 50 ? "APROVADO COM RESSALVAS" : "REPROVADO";
            
            Console.WriteLine($"CLASSIFICACAO: {classificacao}");
            Console.WriteLine("========================================");
        }

        public double CalcularAprovacao()
        {
            int totalItens = Checklist.Count;
            int itensBons = Checklist.Count(i => i.Status == "Bom");
            return totalItens > 0 ? (itensBons * 100.0) / totalItens : 0;
        }

        public string ObterClassificacao()
        {
            double aprovacao = CalcularAprovacao();
            return aprovacao >= 80 ? "APROVADO" : 
                   aprovacao >= 50 ? "APROVADO COM RESSALVAS" : "REPROVADO";
        }

        public abstract string GetTipo();
        public abstract string GetAtributoEspecifico();
    }
}