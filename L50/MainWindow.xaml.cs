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

namespace L50
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Person MyPerson1 { get; set; }
        public class Person
        {
            public string Name { get; set; }
            public override string ToString()
            {
                return $"Person name {Name}";
            }
        }
        public MainWindow()
        {
            this.Resources["MyDynamicColor"] = new SolidColorBrush(Colors.LightPink);
            InitializeComponent();
            MyPerson1 = new Person { Name = "Very special person!" };
            //this.DataContext = this;
            //this.lbl1.DataContext = MyPerson1;
            this.lbl1.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Resources["MyDynamicColor"] = btnYellow.Background;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Resources["MyDynamicColor"] = btnBlueDown.Background;
        }
    }
}
