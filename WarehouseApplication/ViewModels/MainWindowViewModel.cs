using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using Prism.Commands;
using Prism.Mvvm;
using WarehouseApplication.Models;
using WarehouseApplication.Views;

namespace WarehouseApplication.ViewModels
{
    internal class MainWindowViewModel : BindableBase
    {
        public DelegateCommand<string> AddInputCommand { get; }
        public DelegateCommand<string> AddOutputCommand { get; }
        public DelegateCommand CleanUpCommand { get; }
        public DelegateCommand OpenNomenclatureEditorCommand { get; }

        public ObservableCollection<ProductGroup> InputProducts => _model.InputProducts;
        public ObservableCollection<ProductGroup> OutputProducts => _model.OutputProducts;

        private NomenclatureEditorWindow _nomenclatureEditorWindow;

        private InputOutputModel _model;

        private readonly Regex _idRegex;



        public MainWindowViewModel()
        {
            _model = new InputOutputModel();
            AddInputCommand = new DelegateCommand<string>((string id) => AddInput(id));
            AddOutputCommand = new DelegateCommand<string>((string id) => AddOutput(id));
            CleanUpCommand = new DelegateCommand(_model.CleanUp);
            OpenNomenclatureEditorCommand = new DelegateCommand(OpenNomenclatureEditor);

            _idRegex = new Regex(@"^([0-9]|[A-F])*$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }



        private void AddInput(string id)
        {
            if(!TryParseIdText(id, out var ids))
                return;

            _model.AddInputProducts(ids);
        }

        private void AddOutput(string id)
        {
            if(!TryParseIdText(id, out var ids))
                return;

            _model.AddOutputProducts(ids);
        }



        private void OpenNomenclatureEditor()
        {
            if(_nomenclatureEditorWindow != null)
                return;

            _nomenclatureEditorWindow = new NomenclatureEditorWindow();
            _nomenclatureEditorWindow.Closed += (object sender, EventArgs e) => _nomenclatureEditorWindow = null;
            _nomenclatureEditorWindow.Show();
        }



        private bool TryParseIdText(string idText, out string[] ids)
        {
            ids = new string[0];
            if(string.IsNullOrEmpty(idText))
            {
                MessageBox.Show("Введите в поле ввода идентификатор");
                return false;
            }

            idText = idText.ToUpper();
            ids = idText.Split(' ');
            foreach(string id in ids)
            {
                if(id.Length != 24)
                {
                    MessageBox.Show($"Ошибка в идентификаторе {id}. Длина идентификатора должна быть равна 24 символам");
                    return false;
                }

                if(!_idRegex.IsMatch(id))
                {
                    MessageBox.Show($"Ошибка в идентификаторе {id}. Должны использоваться только HEX-символы (0-9 и A-F)");
                    return false;
                }
            }

            return true;
        }
    }
}
