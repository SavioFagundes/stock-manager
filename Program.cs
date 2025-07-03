using System;
using System.Linq;

namespace StockManager
{
    class Program
    {
        static void Main()
        {
            var repo = new ProductRepository();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Gerenciador de Estoque ===");
                Console.WriteLine("1. Listar produtos");
                Console.WriteLine("2. Cadastrar produto");
                Console.WriteLine("3. Atualizar produto");
                Console.WriteLine("4. Remover produto");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");
                var opt = Console.ReadLine();

                switch (opt)
                {
                    case "1": Listar(repo); break;
                    case "2": Cadastrar(repo); break;
                    case "3": Atualizar(repo); break;
                    case "4": Remover(repo); break;
                    case "0": return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        Pausar();
                        break;
                }
            }
        }

        static void Listar(ProductRepository repo)
        {
            Console.WriteLine("\nProdutos no estoque:");
            foreach (var p in repo.GetAll())
            {
                Console.WriteLine($"{p.Id} | {p.Name} | Qtd: {p.Quantity} | R$ {p.Price:F2}");
            }
            Pausar();
        }

        static void Cadastrar(ProductRepository repo)
        {
            Console.WriteLine("\n== Novo Produto ==");
            var p = new Product.Product { Id = Guid.NewGuid() };

            // Validação do Nome
            do
            {
                Console.Write("Nome: ");
                p.Name = Console.ReadLine() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(p.Name))
                    Console.WriteLine("Nome não pode ser vazio. Tente novamente.");
            } while (string.IsNullOrWhiteSpace(p.Name));

            // Validação da Quantidade
            p.Quantity = ReadInt("Quantidade", min: 0);

            // Validação do Preço
            p.Price = ReadDecimal("Preço unitário", min: 0m);

            repo.Add(p);
            Console.WriteLine("Produto cadastrado com sucesso!");
            Pausar();
        }

        static void Atualizar(ProductRepository repo)
        {
            Console.WriteLine("\n== Atualizar Produto ==");
            var id = ReadGuid("ID do produto a atualizar");

            var existing = repo.GetAll().FirstOrDefault(p => p.Id == id);
            if (existing == null)
            {
                Console.WriteLine("Produto não encontrado.");
                Pausar();
                return;
            }

            Console.WriteLine($"Nome atual: {existing.Name}");
            Console.Write("Novo nome (Enter para manter): ");
            var nome = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nome))
                existing.Name = nome;

            Console.WriteLine($"Quantidade atual: {existing.Quantity}");
            Console.Write("Nova quantidade (Enter para manter): ");
            var qtdInput = Console.ReadLine();
            int qtd;
            if (!string.IsNullOrWhiteSpace(qtdInput) && int.TryParse(qtdInput, out qtd))
                existing.Quantity = qtd;

            Console.WriteLine($"Preço atual: R$ {existing.Price:F2}");
            Console.Write("Novo preço (Enter para manter): ");
            var prInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(prInput) && decimal.TryParse(prInput, out var pr))
                existing.Price = pr;

            repo.Update(existing);
            Console.WriteLine("Produto atualizado com sucesso!");
            Pausar();
        }

        static void Remover(ProductRepository repo)
        {
            Console.WriteLine("\n== Remover Produto ==");
            var id = ReadGuid("ID do produto a remover");

            if (repo.Delete(id))
                Console.WriteLine("Produto removido com sucesso!");
            else
                Console.WriteLine("Produto não encontrado.");

            Pausar();
        }

        // Métodos auxiliares de validação
        static void Pausar()
        {
            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
        }

        static Guid ReadGuid(string prompt)
        {
            Guid id;
            do
            {
                Console.Write($"{prompt}: ");
                var input = Console.ReadLine();
                if (Guid.TryParse(input, out id))
                    return id;
                Console.WriteLine("ID inválido. Digite um GUID válido.");
            } while (true);
        }

        static int ReadInt(string prompt, int? min = null, int? max = null, bool allowEmpty = false)
        {
            int value;
            do
            {
                Console.Write($"{prompt}: ");
                var input = Console.ReadLine();
                if (allowEmpty && string.IsNullOrWhiteSpace(input))
                    return default; // will be handled by caller
                if (int.TryParse(input, out value) &&
                    (!min.HasValue || value >= min) &&
                    (!max.HasValue || value <= max))
                    return value;

                Console.WriteLine("Entrada inválida. Digite um número inteiro válido" +
                                  (min.HasValue ? $" >= {min}" : "") +
                                  (max.HasValue ? $" <= {max}" : "") + ".");
            } while (true);
        }

        static decimal ReadDecimal(string prompt, decimal? min = null, decimal? max = null, bool allowEmpty = false)
        {
            decimal value;
            do
            {
                Console.Write($"{prompt}: ");
                var input = Console.ReadLine();
                if (allowEmpty && string.IsNullOrWhiteSpace(input))
                    return default; // will be handled by caller
                if (decimal.TryParse(input, out value) &&
                    (!min.HasValue || value >= min) &&
                    (!max.HasValue || value <= max))
                    return value;

                Console.WriteLine("Entrada inválida. Digite um número decimal válido" +
                                  (min.HasValue ? $" >= {min}" : "") +
                                  (max.HasValue ? $" <= {max}" : "") + ".");
            } while (true);
        }
    }
}
