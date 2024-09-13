# Projeto Demo de Testes Unitários com xUnit usando .NET Core em C#

Este projeto demonstra a criação e execução de testes unitários utilizando o xUnit em um projeto .NET Core em C#.

## Visão Geral

Este projeto não inclui a execução prática da API em si. Em vez disso, o foco é testar funcionalidades utilizando o xUnit. Para executar os testes, você pode usar uma IDE compatível, como o Visual Studio ou o Visual Studio Code com a extensão do .NET Developer Kit.

## Requisitos

- **.NET Core SDK**: Certifique-se de ter o .NET Core SDK instalado. Você pode baixá-lo [aqui](https://dotnet.microsoft.com/download).
- **IDE (opcional)**: Visual Studio ou Visual Studio Code com a extensão .NET Developer Kit. Você pode baixá-lo no [marketplace](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit).

## Executando os Testes

Para rodar os testes via terminal, siga estas etapas:

1. **Abra o Terminal**: Use o terminal integrado da sua IDE ou um terminal de sua preferência.

2. **Navegue até o Diretório do Projeto de Testes**:
   Certifique-se de estar no diretório do projeto de testes `professorschedulelib.tests`. Verifique a presença do arquivo `ProfessorScheduleLib.Tests.csproj` usando o comando:
   
   ```bash
   ls
   
3. **Restaure as dependencias usando:**
    ```bash
    dotnet restore

4. **Finalmente execute os testes com:**
   ```bash
   dotnet test
