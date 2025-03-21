using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WpfApp1.ViewModels
{
    public class TestSuite
    {
        public string Name { get; set; } = "";
        public ObservableCollection<TestCase> TestCases { get; set; } = new ObservableCollection<TestCase>();
        public TestSuite() { }
    }
}
