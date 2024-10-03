using System.Data.Entity;
using System.Linq;
using System.Windows;
using Prism.Commands;
using Prism.Mvvm;
using WarehouseApplication.Models;

namespace WarehouseApplication.ViewModels
{
    internal class NomenclatureEditorViewModel : BindableBase
    {
        public DelegateCommand<ProductTemplate> AddProductTemplateCommand { get; }

        public DbSet<ProductTemplate> ProductTemplates => _model.ProductTemplates;

        private NomenclatureModel _model;



        public NomenclatureEditorViewModel()
        {
            _model = new NomenclatureModel();
            AddProductTemplateCommand = new DelegateCommand<ProductTemplate>((t) => AddProductTemplate(t));
        }



        public void AddProductTemplate(ProductTemplate template)
        {
            if(string.IsNullOrEmpty(template.Name))
            {
                MessageBox.Show("Введите наименование продукта");
                return;
            }

            if(string.IsNullOrEmpty(template.Id))
            {
                MessageBox.Show("Введите идентификатор продукта");
                return;
            }

            template.Id = template.Id.ToUpper();

            if(template.Id.Length != 24)
            {
                MessageBox.Show($"Длина идентификатора должна быть равна 24 символам");
                return;
            }

            if(!IdValidator.IsValid(template.Id))
            {
                MessageBox.Show($"В идентификаторе должны использоваться только HEX-символы (0-9 и A-F)");
                return;
            }

            if(ProductTemplates.FirstOrDefault(t => t.Id == template.Id) != null)
            {
                MessageBox.Show($"Продукт с таким идентификатором уже есть в номенклатуре");
                return;
            }

            _model.AddProductTemplate(template);
        }
    }
}
