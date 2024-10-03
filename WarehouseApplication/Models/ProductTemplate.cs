namespace WarehouseApplication.Models
{
    public class ProductTemplate
    {
        public string Id { get; private set; }
        public string Name { get; private set; }



        public ProductTemplate() { }

        public ProductTemplate(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
