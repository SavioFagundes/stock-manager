namespace Product
{
    public class Product
    {
        public Guid Id { get; set; }    // identificador único

        public string Name { get; set; } = string.Empty;   // nome do produto
        public int Quantity { get; set; }  // quantidade em estoque
        public decimal Price { get; set; } // preço unitário
    }
}