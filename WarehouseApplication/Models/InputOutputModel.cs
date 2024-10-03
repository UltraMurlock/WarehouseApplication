using System.Collections.ObjectModel;
using System.Linq;

namespace WarehouseApplication.Models
{
    public class InputOutputModel
    {
        public ObservableCollection<ProductGroup> InputProducts;
        public ObservableCollection<ProductGroup> OutputProducts;



        public InputOutputModel()
        {
            InputProducts = new ObservableCollection<ProductGroup>();
            OutputProducts = new ObservableCollection<ProductGroup>();
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
                string name = $"{id.ToCharArray()[0]}";
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
    }
}
