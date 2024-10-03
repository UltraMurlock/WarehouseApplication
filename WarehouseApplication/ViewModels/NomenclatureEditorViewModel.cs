using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Mvvm;
using WarehouseApplication.Models;

namespace WarehouseApplication.ViewModels
{
    internal class NomenclatureEditorViewModel : BindableBase
    {
        public DelegateCommand<ProductTemplate> AddProductTemplateCommand { get; }

        public ObservableCollection<ProductTemplate> ProductTemplates => _model.ProductTemplates;

        private NomenclatureModel _model;



        public NomenclatureEditorViewModel()
        {
            _model = new NomenclatureModel();
            AddProductTemplateCommand = new DelegateCommand<ProductTemplate>((t) => AddProductTemplate(t));
        }



        public void AddProductTemplate(ProductTemplate template)
        {
            _model.AddProductTemplate(template);
        }
    }
}
