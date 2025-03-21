using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
namespace WpfApp1.ViewModels
{
    public class Project
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty ;
        public ObservableCollection<TestSuite> Tests { get; set; } = new ObservableCollection<TestSuite>();

        public Project()
        {
            
        }
    }
}
