# Stock Manager

> Gerenciador de estoque simples em .NET Core com persistência em arquivo JSON

---

## Índice

- [Sobre](#sobre)  
- [Funcionalidades](#funcionalidades)  
- [Tecnologias](#tecnologias)  
- [Pré-requisitos](#pré-requisitos)  
- [Instalação](#instalação)  
- [Uso](#uso)  
- [Estrutura do Projeto](#estrutura-do-projeto)  
- [Contribuições](#contribuições)  
- [Licença](#licença)  
- [Autor](#autor)  

---

## Sobre

O **Stock Manager** é um aplicativo de console desenvolvido em C# com .NET 7.0 que permite gerenciar um inventário de produtos de forma simples e rápida. Todas as operações de CRUD (Criar, Ler, Atualizar e Excluir) são persistidas em um arquivo `data.json`, garantindo que os dados sobrevivam entre execuções do programa.

---

## Funcionalidades

- **Listar produtos**  
  Exibe todos os itens em estoque com ID, nome, quantidade e preço.

- **Cadastrar produto**  
  Cria um novo registro com identificador único (GUID), informando nome, quantidade e preço.

- **Atualizar produto**  
  Permite alterar o nome, quantidade e preço de um item existente (pressione Enter para manter o valor atual de cada campo).

- **Remover produto**  
  Exclui um item do estoque a partir do seu ID (GUID).

- **Persistência em JSON**  
  Todas as alterações são automaticamente salvas no arquivo `data.json`.

---

## Tecnologias

- [.NET 7.0 SDK](https://dotnet.microsoft.com/download)  
- C#  
- Console application  
- JSON para persistência de dados  

---

## Pré-requisitos

Antes de começar, verifique se você possui instalado em sua máquina:

- .NET 7.0 SDK (ou superior)  
- Git (para clonar o repositório)  
- Terminal / Console de sua preferência  

---

## Instalação

1. **Clone este repositório**

   ```bash
   git clone https://github.com/SavioFagundes/stock-manager.git
   cd stock-manager

Autor
Sávio Fagundes Marques

GitHub: @SavioFagundes
