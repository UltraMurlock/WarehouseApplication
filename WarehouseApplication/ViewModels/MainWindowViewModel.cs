using System.Collections.ObjectModel;
using System.Windows;
using Prism.Commands;
using Prism.Mvvm;
using WarehouseApplication.Models;

namespace WarehouseApplication.ViewModels
{
    internal class MainWindowViewModel : BindableBase
    {
        public DelegateCommand<string> AddInputCommand { get; }
        public DelegateCommand<string> AddOutputCommand { get; }
        public ObservableCollection<ProductGroup> InputProducts => _model.InputProducts;
        public ObservableCollection<ProductGroup> OutputProducts => _model.OutputProducts;

        private InputOutputModel _model;



        public MainWindowViewModel()
        {
            _model = new InputOutputModel();
            AddInputCommand = new DelegateCommand<string>((string id) => AddInput(id));
            AddOutputCommand = new DelegateCommand<string>((string id) => AddOutput(id));
        }



        private void AddInput(string id)
        {
            if(string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Ошибка в поле ID приёма");
                return;
            }

            _model.AddInputProducts(id);
        }

        private void AddOutput(string id)
        {
            if(string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Ошибка в поле ID отгрузки");
                return;
            }

            _model.AddOutputProducts(id);
        }
    }
}
