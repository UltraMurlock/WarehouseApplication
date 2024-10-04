using System.Data.Entity;
using System.Linq;

namespace WarehouseApplication.Models
{
    internal class NomenclatureModel
    {
        public DbSet<ProductTemplate> ProductTemplates => _nomenclatureDB.Templates;

        private NomenclatureDB _nomenclatureDB;



        public NomenclatureModel()
        {
            _nomenclatureDB = NomenclatureDB.GetInstance();
            _nomenclatureDB.Templates.Load();
        }



        public void AddProductTemplate(ProductTemplate template)
        {
            ProductTemplates.Add(template);
            _nomenclatureDB.SaveChanges();
        }

        public void RemoveProductTemplate(string id)
        {
            var template = ProductTemplates.FirstOrDefault(t => t.Id == id);
            if(template != null)
            {
                ProductTemplates.Remove(template);
                _nomenclatureDB.SaveChanges();

                _nomenclatureDB.OnTemplateRemoved(template);
            }
        }
    }
}
