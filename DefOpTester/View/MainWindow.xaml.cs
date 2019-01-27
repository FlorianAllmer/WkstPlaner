using HtlWeiz.WkstPlaner.DefOpTester.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HtlWeiz.WkstPlaner.Contracts.DataAccess;
using HtlWeiz.WkstPlaner.DefOpTester.Init;

namespace HtlWeiz.WkstPlaner.DefOpTester.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //var myContextFactory = new ContextFactory(EnumUser.LocalExpressDomainUser);
            var myContextFactory = new ContextFactory();
            DataContext = new VmMainMaster(myContextFactory.Context, myContextFactory.ConnectionDefinition);
        }
    }
}
