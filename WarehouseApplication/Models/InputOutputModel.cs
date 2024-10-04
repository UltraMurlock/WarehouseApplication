using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;

namespace WarehouseApplication.Models
{
    public class InputOutputModel
    {
        public ObservableCollection<ProductGroup> InputProducts;
        public ObservableCollection<ProductGroup> OutputProducts;

        private DbSet<ProductTemplate> _productTemplates;



        public InputOutputModel()
        {
            InputProducts = new ObservableCollection<ProductGroup>();
            OutputProducts = new ObservableCollection<ProductGroup>();

            var nomenclatureDB = NomenclatureDB.GetInstance();
            _productTemplates = nomenclatureDB.Templates;
            nomenclatureDB.TemplateRemoved += RemoveById;
        }



        public void AddInputProducts(params string[] ids)
        {
            AddProducts(InputProducts, OutputProducts, ids);
        }

        public void AddOutputProducts(params string[] ids)
        {
            AddProducts(OutputProducts, InputProducts, ids);
        }

        public void CleanUp()
        {
            InputProducts.Clear();
            OutputProducts.Clear();
        }



        private void AddProducts(ObservableCollection<ProductGroup> groupToAddCollection, ObservableCollection<ProductGroup> groupToRemoveCollection, params string[] ids)
        {
            foreach(var id in ids)
            {
                if(!TryGetProductName(id, out var name))
                    continue;

                Product product = new Product(id, 1);

                var groupToAdd = groupToAddCollection.FirstOrDefault(g => g.Name == name);
                if(groupToAdd == null)
                {
                    groupToAdd = new ProductGroup(name);
                    groupToAddCollection.Add(groupToAdd);
                }
                groupToAdd.Add(product);

                var groupToRemove = groupToRemoveCollection.FirstOrDefault(g => g.Name == name);
                if(groupToRemove != null)
                {
                    groupToRemove.Remove(product);
                    if(groupToRemove.Count <= 0)
                        groupToRemoveCollection.Remove(groupToRemove);
                }
            }
        }

        private bool TryGetProductName(string id, out string name)
        {
            ProductTemplate template = _productTemplates.FirstOrDefault(g => g.Id == id);
            if(template == null)
            {
                name = string.Empty;
                return false;
            }
            
            name = template.Name;
            return true;
        }

        private void RemoveById(ProductTemplate template)
        {
            for (int i = InputProducts.Count - 1; i >= 0; i--)
            {
                InputProducts[i].RemoveById(template.Id);
                if(InputProducts[i].Count <= 0)
                    InputProducts.Remove(InputProducts[i]);
            }
            for(int i = OutputProducts.Count - 1; i >= 0; i--)
            {
                OutputProducts[i].RemoveById(template.Id);
                if(OutputProducts[i].Count <= 0)
                    OutputProducts.Remove(OutputProducts[i]);
            }
        }
    }
}
