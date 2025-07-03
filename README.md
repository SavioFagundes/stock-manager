# Stock Manager

> Gerenciador de Estoque simples em .NET Core com persistência em arquivo JSON

## 📝 Descrição

O **Stock Manager** é um aplicativo de console para gerenciar um inventário de produtos localmente.  
Ele suporta operações de **CRUD** (criar, ler, atualizar e excluir) e salva todas as mudanças em um arquivo `data.json`, permitindo que seus dados persistam entre execuções.

## 🚀 Funcionalidades

- 📋 **Listar produtos**: exibe Todos os itens em estoque com ID, nome, quantidade e preço.  
- ➕ **Cadastrar produto**: cria um novo registro com identificador único (GUID).  
- ✏️ **Atualizar produto**: altera nome, quantidade e preço de um item existente.  
- 🗑️ **Remover produto**: exclui um item pelo seu ID.  
- 💾 **Persistência em JSON**: todas as alterações são salvas automaticamente em `data.json`.  

## 📋 Pré-requisitos

- [.NET 7.0 SDK (ou superior)](https://dotnet.microsoft.com/download)  
- Windows, macOS ou Linux com terminal/console disponível

## 📦 Instalação

1. **Clone o repositório**  
   ```bash
   git clone https://github.com/SavioFagundes/stock-manager.git
   cd stock-manager
Restaurar dependências e compilar

bash
Copiar
Editar
dotnet restore
dotnet build --configuration Release
Executar o aplicativo

bash
Copiar
Editar
dotnet run --project StockManager.csproj
Na primeira execução, um arquivo data.json vazio será criado na pasta do executável.

🎯 Como usar
Ao iniciar, escolha uma opção no menu (1–4 ou 0 para sair):

markdown
Copiar
Editar
=== Gerenciador de Estoque ===
1. Listar produtos
2. Cadastrar produto
3. Atualizar produto
4. Remover produto
0. Sair
Escolha uma opção:
Listar (1)
— Exibe todos os produtos carregados de data.json.

Cadastrar (2)

Informe o Nome, Quantidade (inteiro) e Preço (decimal).

Um novo GUID será gerado automaticamente.

Atualizar (3)

Informe o ID (GUID) do produto a ser alterado.

Quando solicitado, pressione Enter para manter cada campo inalterado ou informe um novo valor.

Remover (4)

Informe o ID (GUID) do produto a ser removido.

Sair (0)
— Encerra o programa.

🗂️ Estrutura de arquivos
bash
Copiar
Editar
stock-manager/
│
├─ Product.cs                # Modelo de domínio do produto
├─ ProductRepository.cs      # Repositório para CRUD + persistência JSON
├─ Program.cs                # Interface de console e lógica de menu
├─ StockManager.csproj       # Projeto C# (.NET SDK)
├─ StockManager.sln          # Solução Visual Studio / VS Code
└─ data.json                 # (gerado em tempo de execução) armazena produtos
🛠️ Arquitetura
Domain Model: Product com propriedades Id, Name, Quantity, Price.

Repository Pattern: ProductRepository encapsula leitura/escrita em data.json.

Console UI: Program.cs apresenta menu, captura input e chama o repositório.

🤝 Contribuições
Fork este repositório

Crie sua branch de feature: git checkout -b feature/nova-funcionalidade

Faça commits atômicos seguindo Conventional Commits

Abra um Pull Request describindo o que e por que mudou

📜 Licença
Este projeto está sob a licença MIT. Veja o arquivo LICENSE para mais detalhes.

Desenvolvido com 💙 por Sávio Fagundes Marques

csharp
Copiar
Editar

**Personalize** qualquer seção conforme necessidade (links, versões, nomes). Esse README fornece aos usuários e colabor