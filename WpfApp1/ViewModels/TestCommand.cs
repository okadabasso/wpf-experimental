using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModels
{
    public class TestCommand
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";

        public string Command { get; set; } = "";

        public string Target { get; set; } = "";

        public string CommandParameter { get; set; } = "";


        public TestCommand() { }
    }
}
