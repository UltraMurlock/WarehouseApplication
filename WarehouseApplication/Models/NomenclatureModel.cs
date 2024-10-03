using System.Collections.ObjectModel;

namespace WarehouseApplication.Models
{
    internal class NomenclatureModel
    {
        public ObservableCollection<ProductTemplate> ProductTemplates;



        public NomenclatureModel()
        {
            ProductTemplates = new ObservableCollection<ProductTemplate>();
        }



        public void AddProductTemplate(ProductTemplate template)
        {
            ProductTemplates.Add(template);
        }

        public void RemoveProductTemplate(ProductTemplate template)
        {
            ProductTemplates.Remove(template);
        }
    }
}
