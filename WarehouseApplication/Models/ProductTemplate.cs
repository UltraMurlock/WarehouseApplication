namespace WarehouseApplication.Models
{
    public class ProductTemplate
    {
        public string Id { get; set; }
        public string Name { get; set; }



        public ProductTemplate() { }

        public ProductTemplate(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
