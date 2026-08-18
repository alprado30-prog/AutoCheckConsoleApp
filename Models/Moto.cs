using System.Collections.Generic;
using AutoCheckConsoleApp.Models;

namespace AutoCheckConsoleApp.Models
{
    public class Moto : Veiculo
    {
        public Moto(string marca, string modelo, int ano, double km) : base(marca, modelo, ano, km) 
        {
            CriarChecklist();
        }

        public override void CriarChecklist()
        {
            Checklist.Add(new ItemVistoria("Pressão dos Pneus"));
            Checklist.Add(new ItemVistoria("Pastilhas de Freio"));
            Checklist.Add(new ItemVistoria("Corrente de Transmissão"));
            Checklist.Add(new ItemVistoria("Óleo do Motor"));
        }

        public override string GetTipo() => "Moto";
        public override string GetAtributoEspecifico() => "Cilindrada: 150cc";
    }
}