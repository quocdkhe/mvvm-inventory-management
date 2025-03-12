using System.Windows;
using System.Windows.Controls;
using InventoryManagement.ViewModel;

namespace InventoryManagement
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            LoginViewModel loginViewModel = this.DataContext as LoginViewModel;
            if (sender is PasswordBox passwordBox)
            {
                loginViewModel.Password = passwordBox.Password;
            }
        }
    }
}
