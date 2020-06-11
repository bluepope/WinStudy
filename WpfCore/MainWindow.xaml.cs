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

namespace WpfCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel1 _viewModel = new ViewModel1();
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = _viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Text1 = new Random().Next(1000000).ToString();
            _viewModel.Num1 = new Random().Next(100);
        }
    }

    public class ViewModel1 : BaseModel
    {
        string _text1;

        public string Text1 { get => _text1; set { _text1 = value; OnPropertyChanged();  } }

        int _num1;
        public int Num1 { get => _num1; set { _num1 = value; OnPropertyChanged(); } }
    }
}
