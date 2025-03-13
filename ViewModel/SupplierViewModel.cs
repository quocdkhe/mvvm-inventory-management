﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using InventoryManagement.Model;

namespace InventoryManagement.ViewModel
{
    public class SupplierViewModel : BaseViewModel
    {
        private ObservableCollection<Supplier> _list;
        private Supplier _selectedItem;
        private string _displayName;
        private string _phone;
        private string _address;
        private string _email;
        private string _moreInfo;
        private DateTime? _contractDate;
        public ObservableCollection<Supplier> List
        {
            get => _list; set
            {
                _list = value; OnPropertyChanged();
            }
        }
        public string? DisplayName
        {
            get => _displayName; set { _displayName = value; OnPropertyChanged(); }
        }

        public string? Phone
        {
            get => _phone; set { _phone = value; OnPropertyChanged(); }
        }

        public string? Address
        {
            get => _address; set { _address = value; OnPropertyChanged(); }
        }

        public string? Email
        {
            get => _email; set { _email = value; OnPropertyChanged(); }
        }

        public string? MoreInfo
        {
            get => _moreInfo; set { _moreInfo = value; OnPropertyChanged(); }
        }

        public DateTime? ContractDate
        {
            get => _contractDate; set { _contractDate = value; OnPropertyChanged(); }
        }

        public Supplier SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value; OnPropertyChanged();
                if (SelectedItem != null)
                {
                    DisplayName = SelectedItem.DisplayName;
                    Phone = SelectedItem.Phone;
                    Address = SelectedItem.Address;
                    Email = SelectedItem.Email;
                    ContractDate = SelectedItem.ContractDate;
                    MoreInfo = SelectedItem.MoreInfo;
                }
            }
        }
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private void LoadFromDatabase()
        {
            List = new ObservableCollection<Supplier>(InventoryManagementContext.INSTANCE.Suppliers);
        }
        public SupplierViewModel()
        {
            LoadFromDatabase();
            AddCommand = new RelayCommand<object>((p) =>
            {
                if (DisplayName == null)
                {
                    return false;
                }
                return true;

            }, (p) =>
            {
                Supplier supplier = new Supplier
                {
                    DisplayName = DisplayName,
                    Phone = Phone,
                    Address = Address,
                    Email = Email,
                    ContractDate = ContractDate,
                    MoreInfo = MoreInfo,
                };
                InventoryManagementContext.INSTANCE.Suppliers.Add(supplier);
                InventoryManagementContext.INSTANCE.SaveChanges();
                LoadFromDatabase();
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                var currentSupplier = InventoryManagementContext
                    .INSTANCE
                    .Suppliers
                    .FirstOrDefault(supplier => supplier.Id == SelectedItem.Id);
                currentSupplier.DisplayName = DisplayName;
                currentSupplier.Phone = Phone;
                currentSupplier.Address = Address;
                currentSupplier.Email = Email;
                currentSupplier.ContractDate = ContractDate;
                currentSupplier.MoreInfo = MoreInfo;
                InventoryManagementContext.INSTANCE.SaveChanges();
                LoadFromDatabase();
            });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem != null)
                {
                    return true;
                }
                return false;

            }, (p) =>
            {
                var currentSupplier = InventoryManagementContext.INSTANCE
                    .Suppliers
                    .FirstOrDefault(supplier => supplier.Id == SelectedItem.Id);
                if (currentSupplier != null)
                {
                    InventoryManagementContext.INSTANCE.Suppliers.Remove(currentSupplier);
                    InventoryManagementContext.INSTANCE.SaveChanges();

                }
                LoadFromDatabase();
            });
        }
    }
}
