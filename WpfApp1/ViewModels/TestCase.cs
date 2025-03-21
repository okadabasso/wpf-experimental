using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WpfApp1.ViewModels
{
    public class TestCase
    {
        public string Description { get; set; } = "";
        public ObservableCollection<TestCommand> TestCommands { get; set; } = new ObservableCollection<TestCommand>();

        public TestCase()
        {
                
        }
    }
}
