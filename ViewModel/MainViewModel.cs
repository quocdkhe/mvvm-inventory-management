using System.Windows;
using System.Windows.Input;

namespace InventoryManagement.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public Window MainWindow { get; private set; }
        public bool IsLoaded { get; set; } = false;
        public ICommand UnitCommand { get; set; }
        public ICommand SupplierComand { get; set; }
        public ICommand CustomerCommand { get; set; }
        public ICommand ObjectCommand { get; set; }
        public ICommand UserCommand { get; set; }
        public ICommand InputCommand { get; set; }
        public ICommand OutputCommand { get; set; }
        public MainViewModel()
        {

            MainWindow = Application.Current.MainWindow;

            if (!IsLoaded)
            {
                IsLoaded = true;
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();

                // Process: the login is succeeded or not
                var loginVM = loginWindow.DataContext as LoginViewModel;
                if (loginVM == null)
                {
                    return;
                }
                // If is not logged in, close main window
                if (!loginVM.IsLogin)
                {
                    MainWindow.Close();
                }
            }

            UnitCommand = new RelayCommand<object>((p) => true, (p) =>
            {
                UnitWindow unitWindow = new UnitWindow();
                unitWindow.ShowDialog();
            });

            SupplierComand = new RelayCommand<object>((p) => true, (p) =>
            {
                SupplierWindow supplierWindow = new SupplierWindow();
                supplierWindow.ShowDialog();
            });

            CustomerCommand = new RelayCommand<object>((p) => true, (p) =>
            {
                CustomerWindow customerWindow = new CustomerWindow();
                customerWindow.ShowDialog();
            });

            ObjectCommand = new RelayCommand<object>((p) => true, (p) =>
            {
                ObjectWindow objectWindow = new ObjectWindow();
                objectWindow.ShowDialog();
            });

            UserCommand = new RelayCommand<object>((p) => true, (p) =>
            {
                UserWindow userWindow = new UserWindow();
                userWindow.ShowDialog();
            });
            InputCommand = new RelayCommand<object>((p) => true, (p) =>
            {
                InputWindow inputWindow = new InputWindow();
                inputWindow.ShowDialog();
            });

            OutputCommand = new RelayCommand<object>((p) => true, (p) =>
            {
                OutputWindow outputWindow = new OutputWindow();
                outputWindow.ShowDialog();
            });
        }
    }
}
