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
using WpfMvvm.ViewModels;

namespace WpfMvvm
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        VMTest1 ViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            this.ViewModel = new VMTest1();
            this.DataContext = this.ViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //frame1.Navigate("test");
            //image1.Source = new BitmapImage(new Uri("/Images/18.jpg", UriKind.Relative));
            this.ViewModel.Text1 = new Random().Next().ToString();
            this.ViewModel.Num1 = new Random().Next(100);
            this.ViewModel.Num2 = new Random(this.ViewModel.Num1).Next(100);
        }
    }
}
