using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using HtlWeiz.WkstPlaner.DataBaseHelper.Connect;
using HtlWeiz.WkstPlaner.DefOpTester.Init;
using HtlWeiz.WkstPlaner.Model;
using Microsoft.EntityFrameworkCore;


namespace HtlWeiz.WkstPlaner.DefOpTester.ViewModels
{
    class VmMainMaster
    {
  
        public WkstStPlanContext MyModel;


        private readonly IConnectionDefinition _myConnectionParameter;
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

        public VmMainMaster()
        {
            _myConnectionParameter = InitConnection.GetConnectionParameter(EnumUser.HqRemote);
            ChangedAllPropertys();
            MyModel = new WkstStPlanContext(_myConnectionParameter.ConnectionString);
            
        }

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
