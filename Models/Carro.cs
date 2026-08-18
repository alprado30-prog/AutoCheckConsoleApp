using System.Collections.Generic;
using AutoCheckConsoleApp.Models;

namespace AutoCheckConsoleApp.Models
{
    public class Carro : Veiculo
    {
        public Carro(string marca, string modelo, int ano, double km) : base(marca, modelo, ano, km) 
        {
            CriarChecklist(); // Chama ao criar
        }

        public override void CriarChecklist()
        {
            Checklist.Add(new ItemVistoria("Nível de Óleo do Motor"));
            Checklist.Add(new ItemVistoria("Bateria e Sistema Elétrico"));
            Checklist.Add(new ItemVistoria("Ar Condicionado Funcional"));
            Checklist.Add(new ItemVistoria("Estepe e Macaco"));
            Checklist.Add(new ItemVistoria("Triângulo de Sinalização"));
        }

        public override string GetTipo() => "Carro";
        public override string GetAtributoEspecifico() => "4 Portas";
    }
}
