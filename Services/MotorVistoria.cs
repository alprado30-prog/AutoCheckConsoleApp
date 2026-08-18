using AutoCheckConsoleApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace AutoCheckConsoleApp
{
    public class MotorVistoria
    {
        public int CalcularPontos(ItemVistoria item)
        {
            if (item.Status == "Bom") return 10;
            if (item.Status == "Regular") return 5;
            return 0; // Ruim
        }

        public double CalcularPercentual(Veiculo veiculo)
        {
            int pontosMaximos = veiculo.Checklist.Count * 10;
            int pontosObtidos = 0;
            foreach (var item in veiculo.Checklist)
            {
                pontosObtidos += CalcularPontos(item);
            }
            return ((double)pontosObtidos / pontosMaximos) * 100;
        }

        public string Classificar(double percentual)
        {
            if (percentual >= 80) return "APROVADO COM EXCELÊNCIA";
            if (percentual >= 60) return "APROVADO COM APONTAMENTOS";
            return "REPROVADO";
        }

        private string GerarDashes(int comprimento)
        {
            return new string('-', comprimento);
        }

        private void GerarRecomendacoes(Veiculo veiculo)
        {
            Console.WriteLine("> RELATÓRIO DE MANUTENÇÃO E RECOMENDAÇÕES DA OFICINA:");
            Console.WriteLine();

            var itensRuins = veiculo.Checklist.Where(i => i.Status == "Ruim").ToList();
            var itensRegulares = veiculo.Checklist.Where(i => i.Status == "Regular").ToList();
            var itensBons = veiculo.Checklist.Where(i => i.Status == "Bom").ToList();

            if (itensRuins.Count > 0)
            {
                Console.WriteLine("  🔴 ITENS CRÍTICOS / REPROVADOS (AÇÃO IMEDIATA):");
                Console.WriteLine();
                foreach (var item in itensRuins)
                {
                    var recomendacao = ObterRecomendacao(item.Descricao);
                    Console.WriteLine($"     - {item.Descricao}: {recomendacao}");
                }
                Console.WriteLine();
            }

            if (itensRegulares.Count > 0)
            {
                Console.WriteLine("  [!] ITENS DE ATENÇÃO / APONTAMENTOS:");
                Console.WriteLine();
                foreach (var item in itensRegulares)
                {
                    var recomendacao = ObterRecomendacao(item.Descricao);
                    Console.WriteLine($"  [!] {item.Descricao}: {recomendacao}");
                }
                Console.WriteLine();
            }

            if (itensRuins.Count == 0 && itensRegulares.Count == 0)
            {
                Console.WriteLine("  [OK] Nenhuma pendência mecânica identificada. Veículo liberado para operação!");
            }
        }

        private string ObterRecomendacao(string descricaoItem)
        {
            var recomendacoes = new Dictionary<string, string>
            {
                { "Sistema de Freios a Ar", "Revisar sistema de freios a ar e cilindros." },
                { "Nível de Óleo do Motor", "Completar nível de óleo e verificar vazamentos." },
                { "Bateria e Sistema Elétrico", "Verificar carga da bateria e conexões." },
                { "Triângulo de Sinalização", "Adquirir triângulo para atender exigências legais." },
                { "", "Verificar e reparar conforme diagnóstico técnico." }
            };

            return recomendacoes.ContainsKey(descricaoItem) ? recomendacoes[descricaoItem] : recomendacoes[""];
        }

        public void GerarRelatorio(Veiculo veiculo, int indiceVistoria, int totalVistorias)
        {
            double percentual = CalcularPercentual(veiculo);
            string classificacao = Classificar(percentual);
            int pontosObtidos = veiculo.Checklist.Sum(i => CalcularPontos(i));

            Console.WriteLine(new string('=', 67));
            Console.WriteLine("                  AUTOCHECK .NET - MOTOR DE VISTORIA");
            Console.WriteLine(new string('=', 67));
            Console.WriteLine();
            Console.WriteLine($"[{indiceVistoria}/{totalVistorias}] PROCESSANDO VISTORIA");
            Console.WriteLine(new string('-', 67));
            Console.WriteLine();
            Console.WriteLine("> DADOS DO VEÍCULO:");
            Console.WriteLine();
            Console.WriteLine($"  - Tipo: {veiculo.GetTipo()}");
            Console.WriteLine($"  - Modelo: {veiculo.Marca} {veiculo.Modelo}");
            Console.WriteLine($"  - Ano: {veiculo.Ano} | Quilometragem: {veiculo.Km:N0} km");
            Console.WriteLine($"  - Atributo Específico: {veiculo.GetAtributoEspecifico()}");
            Console.WriteLine();

            Console.WriteLine($"> AVALIAÇÃO DOS ITENS INSPECIONADOS ({veiculo.Checklist.Count} ITENS):");
            Console.WriteLine("[1/2] PROCESSANDO VISTORIA");
            foreach (var item in veiculo.Checklist)
            {
                int pontos = CalcularPontos(item);
                string simbolo = pontos == 10 ? "[OK]" : pontos == 5 ? "[ ! ]" : "[ X ]";
                
                // Calcular quantidade de dashes para alinhar
                int espacoDisponivel = 50 - simbolo.Length - item.Descricao.Length;
                string dashes = GerarDashes(espacoDisponivel);
                
                Console.WriteLine($"  {simbolo} {item.Descricao} {dashes} Status: {item.Status} ({pontos} pts)");
            }
            Console.WriteLine();

            Console.WriteLine("> RESUMO DA PONTUAÇÃO:");
            Console.WriteLine();
            Console.WriteLine($"  - Pontuação Atingida: {pontosObtidos} de {veiculo.Checklist.Count * 10} pontos possíveis");
            Console.WriteLine($"  - Percentual de Aprovação: {percentual:F1}%");
            Console.WriteLine($"  - Classificação Final: [ {classificacao} ]");
            Console.WriteLine();

            GerarRecomendacoes(veiculo);

            Console.WriteLine(new string('-', 67));
            Console.WriteLine();
        }

        public void GerarRelatorioFinal(int totalVistorias)
        {
            Console.WriteLine(new string('=', 67));
            Console.WriteLine("                  FIM DO PROCESSAMENTO DE VISTORIAS");
            Console.WriteLine(new string('=', 67));
        }
    }
}

  