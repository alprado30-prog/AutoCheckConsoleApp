#!/usr/bin/env pwsh

# Simular entrada de dados
$input_data = @(
    "1",                      # Realizar Nova Vistoria
    "Toyota",                 # Marca
    "Corolla 2.0 Flex",       # Modelo
    "2021",                   # Ano
    "45000",                  # KM
    "1",                      # Tipo: Carro
    "B", "B", "R", "R", "U",  # Status dos itens
    "1",                      # Nova Vistoria
    "Volvo",                  # Marca
    "FH 540",                 # Modelo
    "2019",                   # Ano
    "280000",                 # KM
    "3",                      # Tipo: Caminhão
    "B", "B", "B", "B", "B",  # Status dos itens
    "2",                      # Exibir Relatórios
    "0"                       # Sair
) -join "`n"

$input_data | dotnet run 2>$null
