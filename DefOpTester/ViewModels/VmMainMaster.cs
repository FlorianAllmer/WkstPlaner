using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HtlWeiz.WkstPlaner.Contracts.DataAccess;
using HtlWeiz.WkstPlaner.DataBaseHelper.Connect;
using HtlWeiz.WkstPlaner.DefOpTester.Init;
using HtlWeiz.WkstPlaner.Model.context;
using HtlWeiz.WkstPlaner.Model.tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;


namespace HtlWeiz.WkstPlaner.DefOpTester.ViewModels
{
    class VmMainMaster
    {
  
        public WkstStPlanContext MyModel;


        private readonly IConnectionDefinition _myConnectionParameter;
        private readonly IContextFactory _myContextFactory;
        public string Server
        {
            get => _myConnectionParameter.Server;
            set
            {
                _myConnectionParameter.Server = value; 
                OnPropertyChanged(nameof(Server));
            }
        }

        public string Catalog
        {
            get => _myConnectionParameter.Catalog;
            set
            {
                _myConnectionParameter.Catalog = value;
                OnPropertyChanged(nameof(Catalog));
            }
        }

        public bool UseWindowsAuthenication
        {
            get => _myConnectionParameter.UseWindowsAuthentication;
            set
            {
                _myConnectionParameter.UseWindowsAuthentication = value;
                OnPropertyChanged(nameof(UseWindowsAuthenication));
            }
        }
        public string User
        {
            get => _myConnectionParameter.User;
            set
            {
                _myConnectionParameter.User = value;
                OnPropertyChanged(nameof(User));
            }
        }
        public string Password
        {
            get => _myConnectionParameter.Password;
            set
            {
                _myConnectionParameter.Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }


        public List<TblPersonen> Personen => MyModel.TblPersonen.Select(x => x).ToList();

        public VmMainMaster(IContextFactory contextFactory, IConnectionDefinition connectionDefinition)
        {
            _myConnectionParameter = connectionDefinition;
            _myContextFactory = contextFactory;
            MyModel = (WkstStPlanContext)contextFactory.Context;
            ChangedAllPropertys();
        }

        #region commands
        public ICommand OnStoreSettingsCommand => new RelayCommand<object>(StoreConnectionStringToSetings);

        private void StoreConnectionStringToSetings(object dummy)
        {
            _myContextFactory.StoreSettingsToConfigFile();
        }


        #endregion


        #region Property changed handling
        public event PropertyChangedEventHandler PropertyChanged;

        private void ChangedAllPropertys()
        {
            OnPropertyChanged(nameof(Server));
            OnPropertyChanged(nameof(Catalog));
            OnPropertyChanged(nameof(UseWindowsAuthenication));
            OnPropertyChanged(nameof(User));
            OnPropertyChanged(nameof(Password));
            OnPropertyChanged(nameof(Personen));
        }

        protected virtual void RaisePropertyChangedEvent([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
