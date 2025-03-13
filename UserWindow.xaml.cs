using System.Windows;
using System.Windows.Controls;
using InventoryManagement.ViewModel;

namespace InventoryManagement
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            UserViewModel userViewModel = this.DataContext as UserViewModel;
            if (sender is PasswordBox passwordBox)
            {
                userViewModel.Password = passwordBox.Password;
            }
        }
    }
}
