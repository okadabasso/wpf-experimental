using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfApp1.ViewModels
{
    public partial class SubwindowViewModel : ObservableObject
    {
        [ObservableProperty]
        public partial Project Project { get; set; }

        public SubwindowViewModel()
        {
            Project = CreateProject();
        }

        private Project CreateProject()
        {
            Project project = new Project();

            var suite1 = new TestSuite()
            {
                Name = "Suite1",
                TestCases = new ObservableCollection<TestCase>() {
                    new TestCase(){
                        Description = "Test case 1",
                        TestCommands = new System.Collections.ObjectModel.ObservableCollection<TestCommand> {
                            new TestCommand(){ Command = "Command1", CommandParameter = "Param1" },
                            new TestCommand(){ Command = "Command2", CommandParameter = "Param2" },
                            new TestCommand(){ Command = "Command3", CommandParameter = "Param3" }
                        }
                    },
                    new TestCase(){
                        Description = "Test case 2",
                        TestCommands = new System.Collections.ObjectModel.ObservableCollection<TestCommand> {
                            new TestCommand(){ Command = "Command4", CommandParameter = "Param4" },
                            new TestCommand(){ Command = "Command5", CommandParameter = "Param5" },
                            new TestCommand(){ Command = "Command6", CommandParameter = "Param6" }
                        }
                    },
                    new TestCase(){
                        Description = "Test case 3",
                        TestCommands = new System.Collections.ObjectModel.ObservableCollection<TestCommand> {
                            new TestCommand(){ Command = "Command7", CommandParameter = "Param7" },
                            new TestCommand(){ Command = "Command8", CommandParameter = "Param8" },
                            new TestCommand(){ Command = "Command9", CommandParameter = "Param9" }
                        }
                    }

                }
            };

            var suite2 = new TestSuite()
            {
                Name = "Suite2",
                TestCases = new ObservableCollection<TestCase>() {
                    new TestCase(){
                        Description = "Test case 4",
                        TestCommands = new System.Collections.ObjectModel.ObservableCollection<TestCommand> {
                            new TestCommand(){ Command = "Command10", CommandParameter = "Param10" },
                            new TestCommand(){ Command = "Command11", CommandParameter = "Param11" },
                            new TestCommand(){ Command = "Command12", CommandParameter = "Param12" }
                        }
                    },
                    new TestCase(){
                        Description = "Test case 5",
                        TestCommands = new System.Collections.ObjectModel.ObservableCollection<TestCommand> {
                            new TestCommand(){ Command = "Command13", CommandParameter = "Param13" },
                            new TestCommand(){ Command = "Command14", CommandParameter = "Param14" },
                            new TestCommand(){ Command = "Command15", CommandParameter = "Param15" }
                        }
                    },
                    new TestCase(){
                        Description = "Test case 6",
                        TestCommands = new System.Collections.ObjectModel.ObservableCollection<TestCommand> {
                            new TestCommand(){ Command = "Command16", CommandParameter = "Param16" },
                            new TestCommand(){ Command = "Command17", CommandParameter = "Param17" },
                            new TestCommand(){ Command = "Command18", CommandParameter = "Param18" }
                        }
                    }
                }
            };

            project.Tests.Add(suite1);
            project.Tests.Add(suite2);

            return project;
        }

    }
}
