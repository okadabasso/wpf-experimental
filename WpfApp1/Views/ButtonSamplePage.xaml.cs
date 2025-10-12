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
namespace WpfApp1.Views
{
    /// <summary>
    /// Page2.xaml の相互作用ロジック
    /// </summary>
    public partial class ButtonSamplePage : Page
    {
        private readonly IServiceProvider _serviceProvider;
        public ButtonSamplePage(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }

    }
}
