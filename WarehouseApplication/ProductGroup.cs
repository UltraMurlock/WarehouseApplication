using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace WarehouseApplication
{
    public class ProductGroup : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; private set; }
        public int Count => GetCount();

        private List<Product> _products;


        public ProductGroup(string name)
        {
            Name = name;
            _products = new List<Product>();
        }



        public void Add(Product product)
        {
            var existProduct = _products.FirstOrDefault(p => p.Id == product.Id);
            if(existProduct != null)
                existProduct.Count += product.Count;
            else
                _products.Add(product);

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
        }

        public void Remove(Product product)
        {
            var existProduct = _products.FirstOrDefault(p => p.Id == product.Id);
            if(existProduct == null)
                return;

            existProduct.Count -= product.Count;
            if(existProduct.Count <= 0)
                _products.Remove(existProduct);

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
        }

        public int GetCount()
        {
            int count = 0;
            foreach(var product in _products)
                count += product.Count;
            return count;
        }
    }
}
