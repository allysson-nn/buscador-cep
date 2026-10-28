# Buscador de CEP
Projeto desenvolvido em C# que interage com a API do ViaCEP para obter dados de um endereço de acordo com o CEP passado pelo usuário.

## Sobre a API do ViaCEP
A API do ViaCEP é um serviço web gratuito e de alto desempenho que permite consultar informações de endereçamento postal de todo o Brasil. Os usos mais comuns dessa API incluem as seguintes tarefas:

- Consultar logradouro, bairro, localidade e UF a partir de um CEP válido
- Autocompletar dados de endereço em formulários de cadastro
- Validar a existência de códigos postais na base de dados nacional dos Correios

## Visão geral
Esse projeto surgiu com o objetivo de demonstrar o consumo de serviços web RESTful em C#, tratando retornos no formato JSON e oferecendo uma validação segura para prevenir exceções e identificar CEPs inexistentes diretamente na resposta da API.

## Interface
A aplicação roda diretamente via terminal (Console Application), exibindo os dados formatados após a consulta:

<p align="center">
<img width="478" height="236" alt="Demonstração da Interface" src="https://github.com/user-attachments/assets/28a25821-53ba-4046-9cde-9d6cc4883afb" />
</p>

## Tecnologias Utilizadas no Projeto

- **Linguagem:** C#
- **Plataforma:** .NET (Console Application)
- **Recursos e Bibliotecas:** `HttpClient` (para consumo da API REST) e `System.Text.Json` (para manipulação e desserialização de dados)
