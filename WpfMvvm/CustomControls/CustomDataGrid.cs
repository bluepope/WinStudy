using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
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

namespace WpfMvvm.CustomControls
{
    public class CustomDataGrid : DataGrid
    {
        public CustomDataGrid()
        {
            CanUserAddRows = false;
            CanUserDeleteRows = false;
            AutoGenerateColumns = false;
            /*
            RowStyle = new Style();
            RowStyle.Triggers.Add(new Func<DataTrigger>(() => {
                var dataTrigger = new DataTrigger() { Binding = new Binding("isEdit"), Value = "True" };
                dataTrigger.Setters.Add(new Setter() { Property = Control.BackgroundProperty, Value = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Orange")) });

                return dataTrigger;
            }).Invoke());

            RowStyle.Triggers.Add(new Func<DataTrigger>(() => {
                var dataTrigger = new DataTrigger() { Binding = new Binding("isNew"), Value = "True" };
                dataTrigger.Setters.Add(new Setter() { Property = Control.BackgroundProperty, Value = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Cyan")) });

                return dataTrigger;
            }).Invoke());

            RowStyle.Triggers.Add(new Func<DataTrigger>(() => {
                var dataTrigger = new DataTrigger() { Binding = new Binding("isDelete"), Value = "True" };
                dataTrigger.Setters.Add(new Setter() { Property = Control.BackgroundProperty, Value = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red")) });

                return dataTrigger;
            }).Invoke());
            */
        }

        public void AddTextColumn(string fieldName, string header, int width)
        {
            var col = new DataGridTextColumn();
            col.Binding = new Binding(fieldName);
            col.Header = header;
            col.Width = width;

            Columns.Add(col);
        }
    }
}
