using System.Windows;
using System.Windows.Input;
using InventoryManagement.Model;

namespace InventoryManagement.ViewModel
{

    class LoginViewModel : BaseViewModel
    {
        public bool IsLogin { get; set; } = false;

        private string _userName;
        private string _password;
        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }


        public ICommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Login(p);
            });
        }

        private void Login(Window p)
        {
            if (p == null)
            {
                return;
            }

            /*
             Check login is succeed or not here
             */

            var accCount = InventoryManagementContext.INSTANCE.Users.Where(user =>
            user.UserName == _userName && user.Password == _password).Count();

            if (accCount > 0)
            {
                IsLogin = true;
                p.Close();
            }
            else
            {
                IsLogin = false;
                MessageBox.Show("Đăng nhập cái địt mẹ mày");
            }
        }
    }
}
