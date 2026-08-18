using System.Collections.Generic;
using AutoCheckConsoleApp.Models;

namespace AutoCheckConsoleApp.Models
{
    public class Caminhao : Veiculo
    {
        public Caminhao(string marca, string modelo, int ano, double km) : base(marca, modelo, ano, km) 
        {
            CriarChecklist();
        }

        public override void CriarChecklist()
        {
            Checklist.Add(new ItemVistoria("Pneus e Calibragem"));
            Checklist.Add(new ItemVistoria("Sistema de Freios Completo"));
            Checklist.Add(new ItemVistoria("Óleo do Motor e Filtros"));
            Checklist.Add(new ItemVistoria("Suspensão e Amortecedores"));
            Checklist.Add(new ItemVistoria("Sistema de Ar Comprimido"));
        }

        public override string GetTipo() => "Caminhao";
        public override string GetAtributoEspecifico() => "Capacidade: 5 toneladas";
    }
}