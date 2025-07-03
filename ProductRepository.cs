using System.Text.Json;

public class ProductRepository
{
    private const string FilePath = "data.json";
    private List<Product.Product> _products;

    public ProductRepository()
    {
        if (File.Exists(FilePath))
        {
            var json = File.ReadAllText(FilePath);
            _products = JsonSerializer.Deserialize<List<Product.Product>>(json) ?? new List<Product.Product>();
        }
        else
        {
            _products = new List<Product.Product>();
        }
    }

    public IEnumerable<Product.Product> GetAll() => _products;

    public void Add(Product.Product p)
    {
        _products.Add(p);
        SaveChanges();
    }

    public bool Update(Product.Product updated)
    {
        var idx = _products.FindIndex(p => p.Id == updated.Id);
        if (idx < 0) return false;
        _products[idx] = updated;
        SaveChanges();
        return true;
    }

    public bool Delete(Guid id)
    {
        var idx = _products.FindIndex(p => p.Id == id);
        if (idx < 0) return false;
        _products.RemoveAt(idx);
        SaveChanges();
        return true;
    }

    public void SaveChanges()
    {
        var json = JsonSerializer.Serialize(_products, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FilePath, json);
    }
}