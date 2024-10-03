using System.Data.Entity;

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

        public void RemoveProductTemplate(ProductTemplate template)
        {
            ProductTemplates.Remove(template);
            _nomenclatureDB.SaveChanges();
        }
    }
}
