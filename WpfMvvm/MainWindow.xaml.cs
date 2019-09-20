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
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new VMTest1();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.F2)
            {
                (this.DataContext as VMTest1).Button1Command.Execute(null);
                e.Handled = true;
            }
            else if (e.Key == Key.S && (Keyboard.Modifiers == ModifierKeys.Control))
            {
                (this.DataContext as VMTest1).Button2Command.Execute(null);
                e.Handled = true;
            }
            else
            {
                base.OnKeyDown(e);
            }
        }
    }
}
