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
            AddProducts(InputProducts, ids);
        }

        public void AddOutputProducts(params string[] ids)
        {
            AddProducts(OutputProducts, ids);
        }



        private void AddProducts(ObservableCollection<ProductGroup> groupCollection, params string[] ids)
        {
            foreach(var id in ids)
            {
                string name = $"{id.ToCharArray()[0]}";
                Product product = new Product(id, 1);

                var group = groupCollection.FirstOrDefault(g => g.Name == name);
                if(group == null)
                {
                    group = new ProductGroup(name);
                    groupCollection.Add(group);
                }

                group.Add(product);
            }
        }
    }
}
