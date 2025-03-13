using System.Collections.ObjectModel;
using System.Windows.Input;
using InventoryManagement.Model;

namespace InventoryManagement.ViewModel
{
    public class ObjectViewModel : BaseViewModel
    {
        private ObservableCollection<Model.Object> _list;
        private ObservableCollection<Unit> _units;
        private ObservableCollection<Supplier> _suppliers;


        private Model.Object _selectedItem;
        private string _displayName;
        private string _qrCode;
        private string _barCode;
        private Supplier _selectedSupplier;
        private Unit _selectedUnit;
        public ObservableCollection<Model.Object> List
        {
            get => _list;
            set { _list = value; OnPropertyChanged(); }
        }
        public ObservableCollection<Supplier> Suppliers
        {
            get => _suppliers;
            set { _suppliers = value; OnPropertyChanged(); }
        }
        public ObservableCollection<Unit> Units
        {
            get => _units;
            set { _units = value; OnPropertyChanged(); }
        }

        public Model.Object? SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value; OnPropertyChanged();
                if (SelectedItem != null)
                {
                    DisplayName = SelectedItem.DisplayName;
                    QRCode = SelectedItem.QRCode;
                    BarCode = SelectedItem.BarCode;
                    SelectedUnit = SelectedItem.Unit;
                    SelectedSupplier = SelectedItem.Supplier;
                }
            }
        }
        public string? DisplayName
        {
            get => _displayName;
            set { _displayName = value; OnPropertyChanged(); }
        }
        public string? QRCode
        {
            get => _qrCode;
            set { _qrCode = value; OnPropertyChanged(); }
        }
        public string? BarCode
        {
            get => _barCode;
            set { _barCode = value; OnPropertyChanged(); }
        }
        public Supplier? SelectedSupplier
        {
            get => _selectedSupplier;
            set { _selectedSupplier = value; OnPropertyChanged(); }
        }
        public Unit? SelectedUnit
        {
            get => _selectedUnit;
            set { _selectedUnit = value; OnPropertyChanged(); }
        }
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private void LoadFromDatabase()
        {
            List = new ObservableCollection<Model.Object>(InventoryManagementContext.INSTANCE.Objects);
            Suppliers = new ObservableCollection<Supplier>(InventoryManagementContext.INSTANCE.Suppliers);
            Units = new ObservableCollection<Unit>(InventoryManagementContext.INSTANCE.Units);
        }
        public ObjectViewModel()
        {
            LoadFromDatabase();

            AddCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedSupplier == null || SelectedUnit == null || string.IsNullOrEmpty(DisplayName))
                {
                    return false;
                }
                bool isExisted = InventoryManagementContext.INSTANCE.Objects
                    .Where(obj => obj.DisplayName == DisplayName).Count() != 0;
                return !isExisted;
            }, (p) =>
            {
                Model.Object obj = new Model.Object
                {
                    DisplayName = DisplayName,
                    BarCode = BarCode,
                    QRCode = QRCode,
                    SupplierId = SelectedSupplier.Id,
                    UnitId = SelectedUnit.Id,
                };
                InventoryManagementContext.INSTANCE.Objects.Add(obj);
                InventoryManagementContext.INSTANCE.SaveChanges();
                LoadFromDatabase();
            });



            EditCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(DisplayName) || SelectedItem == null)
                {
                    return false;
                }

                return true;

            }, (p) =>
            {
                var currentObject = InventoryManagementContext
                    .INSTANCE
                    .Objects
                    .FirstOrDefault(obj => obj.Id == SelectedItem.Id);
                currentObject.DisplayName = DisplayName;
                currentObject.BarCode = BarCode;
                currentObject.QRCode = QRCode;
                currentObject.UnitId = SelectedUnit.Id;
                currentObject.SupplierId = SelectedSupplier.Id;
                InventoryManagementContext.INSTANCE.SaveChanges();
                LoadFromDatabase();
            });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                {
                    return false;
                }
                return true;

            }, (p) =>
            {
                var currentObject = InventoryManagementContext.INSTANCE
                    .Objects
                    .FirstOrDefault(obj => obj.Id == SelectedItem.Id);
                if (currentObject != null)
                {
                    InventoryManagementContext.INSTANCE.Objects.Remove(currentObject);
                    InventoryManagementContext.INSTANCE.SaveChanges();
                }
                LoadFromDatabase();
            });
        }
    }
}
