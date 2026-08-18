using System;
using System.Collections.Generic;
using AutoCheckConsoleApp.Models;
using AutoCheckConsoleApp;

class Program
{
    static List<Veiculo> listaVistorias = new List<Veiculo>();
    static MotorVistoria motor = new MotorVistoria();
    

    static void Main(string[] args)
    {
        int opcao = -1;
        do
        {
            try
            {
                Console.WriteLine("=== AUTOCHECK - MOTOR DE VISTORIA ===");
                Console.WriteLine("1 - Realizar Nova Vistoria");
                Console.WriteLine("2 - Exibir Relatorio das Vistorias");
                Console.WriteLine("0 - Sair");
                string? entrada = Console.ReadLine();
                if (string.IsNullOrEmpty(entrada) || !int.TryParse(entrada, out opcao))
                {
                    Console.WriteLine("Opção inválida!");
                    continue;
                }

                switch(opcao)
                {
                    case 1: RealizarVistoria(); break;
                    case 2: ExibirRelatorios(); break;
                    case 0: break;
                    default: Console.WriteLine("Opção inválida!"); break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        } while(opcao != 0);
    }
    
    // Aqui você vai implementar a lógica de pedir Marca, Modelo e percorrer o checklist


static void RealizarVistoria()
{
    Console.Clear();
    Console.WriteLine("=== NOVA VISTORIA ===");
   Console.Write("Digite a Marca: ");
string marca = Console.ReadLine()!;
Console.Write("Digite o Modelo: ");
string modelo = Console.ReadLine()!;
Console.Write("Digite o Ano: ");  // ADICIONA ESSA
int ano = int.Parse(Console.ReadLine()!);
Console.Write("Digite a KM: ");   // ADICIONA ESSA
double km = double.Parse(Console.ReadLine()!);

    Console.WriteLine("\nEscolha o tipo:");
    Console.WriteLine("1 - Carro");
    Console.WriteLine("2 - Moto");
    Console.WriteLine("3 - Caminhao");
    Console.Write("Opcao: ");
    int tipo = int.Parse(Console.ReadLine()!);

    Veiculo veiculo;
    switch (tipo)
    {
    case 1: veiculo = new Carro(marca, modelo, ano, km); break;
    case 2: veiculo = new Moto(marca, modelo, ano, km); break;
    case 3: veiculo = new Caminhao(marca, modelo, ano, km); break;
        default: Console.WriteLine("Tipo invalido"); return;
    }

    foreach (var item in veiculo.Checklist)
    {
        Console.Write($"\nItem: {item.Descricao} - Status [B= Bom / R= Regular / U= Ruim]: ");
        string status = Console.ReadLine()!.ToUpper();
        if (status == "B") item.Status = "Bom";
        else if (status == "R") item.Status = "Regular";
        else item.Status = "Ruim";
    }

    listaVistorias.Add(veiculo);
    
    // Mostrar relatório detalhado da vistoria
    Console.Clear();
    motor.GerarRelatorio(veiculo, listaVistorias.Count, listaVistorias.Count);
    
    Console.WriteLine("Vistoria salva com sucesso!");
    Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
    try { Console.ReadKey(); } catch { }
}

static void ExibirRelatorios()
{
    Console.Clear();
    if (listaVistorias.Count == 0)
    {
        Console.WriteLine("Nenhuma vistoria realizada ainda.");
    }
    else
    {
        for (int i = 0; i < listaVistorias.Count; i++)
        {
            motor.GerarRelatorio(listaVistorias[i], i + 1, listaVistorias.Count);
        }
        motor.GerarRelatorioFinal(listaVistorias.Count);
    }
    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
    try { Console.ReadKey(); } catch { }
}
}