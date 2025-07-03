class Program
{
    static void Main(string[] args)
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
                case "4": new Program().Remover(repo); break;
                case "0": return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    Pausar();
                    continue;
            }
        }
    }

    static void Listar(ProductRepository repo)
    {
        Console.WriteLine("=== Lista de Produtos ===");
        foreach (var p in repo.GetAll())
        {
            Console.WriteLine($"ID: {p.Id}, Nome: {p.Name}, Quantidade: {p.Quantity}, Preço: {p.Price:C}");
        }
        Pausar();
    }
    static void Cadastrar(ProductRepository repo)
    {
        Console.WriteLine("=== Cadastrar Produto ===");
        var p = new Product.Product { Id = Guid.NewGuid() };
        Console.Write("Nome: "); p.Name = Console.ReadLine();
        Console.Write("Quantidade: "); p.Quantity = int.Parse(Console.ReadLine());
        Console.Write("Preço: "); p.Price = decimal.Parse(Console.ReadLine());
        repo.Add(p);
        Console.WriteLine("Produto cadastrado com sucesso!");
        Pausar();
    }

    static void Atualizar(ProductRepository repo)
    {
        Console.WriteLine("=== Atualizar Produto ===");
        if (!Guid.TryParse(Console.ReadLine(), out var id)) { System.Console.WriteLine("Id Inválido."); Pausar(); return; }

        var existing = repo.GetAll().FirstOrDefault(p => p.Id == id);
        if (existing == null) { System.Console.WriteLine("Produto não encontrado."); Pausar(); return; }

        Console.Write($"Nome ({existing.Name}): ");
        var nome = Console.ReadLine(); if (!string.IsNullOrWhiteSpace(nome)) existing.Name = nome;

        Console.Write($"Quantidade ({existing.Quantity}): ");
        var qtd = Console.ReadLine();
        if (int.TryParse(qtd, out var q)) existing.Quantity = q;

        Console.Write($"Preço ({existing.Price:F2}): ");
        var pr = Console.ReadLine();
        if (decimal.TryParse(pr, out var dv)) existing.Price = dv;

        repo.Update(existing);
        Console.WriteLine("Produto atualizado!");
        Pausar();

    }

    public void Remover(ProductRepository repo)
    {
        Console.Write("=== Remover Produto ===\nDigite o ID do produto: ");
        if (!Guid.TryParse(Console.ReadLine(), out var id)) { System.Console.WriteLine("Id Inválido."); Pausar(); return; }
        if (repo.Delete(id)) System.Console.WriteLine("Produto removido com sucesso!");
        else System.Console.WriteLine("Produto não encontrado.");
        Pausar();
    }


    static void Pausar()
    {
        Console.WriteLine("Pressione Enter para continuar...");
        Console.ReadLine();
    }
}
