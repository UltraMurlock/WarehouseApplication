namespace WarehouseApplication
{
    public class Product
    {
        public readonly string Id;
        public int Count;



        public Product(string id, int count)
        {
            Id = id;
            Count = count;
        }
    }
}
