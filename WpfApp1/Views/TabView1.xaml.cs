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
using Microsoft.Extensions.DependencyInjection;
using WpfApp1.ViewModels;

namespace WpfApp1.Views
{
    /// <summary>
    /// TabView1.xaml の相互作用ロジック
    /// </summary>
    public partial class TabView1 : UserControl
    {
        public TabView1(IServiceProvider serviceProvider, string header = "TabView1", string message = "This is TabView1", Action<object>? onClose = null)
        {
            InitializeComponent();

            var viewModel = ActivatorUtilities.CreateInstance<TabContent>(serviceProvider, header, message);
            DataContext = viewModel;

            if (onClose != null)
            {
                viewModel.TabClosed += (s, e) => onClose(this);
            }
        }
    }
}
