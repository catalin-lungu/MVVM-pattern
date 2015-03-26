
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Telerik.Windows.Controls;
using System.Windows;

namespace MVVM.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private Test myclass;

        public Test MyClass
        {
            get
            {
                return myclass;
            }
            set
            {
                if (this.myclass != value)
                {
                    this.myclass = value;
                    OnPropertyChanged("MyClass");
                }
            }
        }

        public ICommand ButtonClick { get; set; }

        public ICommand Focused { get; set; }
        public ObservableCollection<Test> ListItems { get; set; }
        
        public MainViewModel()
        {
            this.MyClass = new Test();
            this.ButtonClick = new DelegateCommandAutoCanExecute(new DelegateCommand(this.OnButtonClick, this.CanClickExecute));
            this.Focused = new DelegateCommand(this.OnFocus);
            ListItems = new ObservableCollection<Test>();
            for (int i = 0; i < 100; i++)
            {
                this.ListItems.Add(new Test() { MyValue = "Item " + i });
            }
        }

        private void OnFocus(object obj)
        {
            MessageBox.Show("Button Focused");
        }

        private bool CanClickExecute(object obj)
        {
            return obj != null;
        }
 
        private void OnButtonClick(object obj)
        {
            MessageBox.Show((obj as Test).MyValue);
        }
    }


    public class Test
    {
        public string MyValue { get; 
            set; }

        public Test2 MyTest { get; set; }
        public Test()
        {
            MyTest = new Test2();
        }
    }

    public class Test2
    {
        public string Value2 { get; set; }
    }
}