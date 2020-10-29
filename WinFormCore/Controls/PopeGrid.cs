using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using WinFormCore.Models;
using System.Reflection;
using System.Drawing;
using System.Data;
using System.Runtime.CompilerServices;

namespace WinFormCore.Controls
{
    public class PopeGrid : DataGridView
    {
        public enum DataSourceTypeEnum
        {
            DataTable,
            ModelBase
        }

        public enum ColTypeEnum
        {
            ReadOnly,
            Edit,
            OnlyNewEdit
        }

        public DataSourceTypeEnum DataSourceType { get; private set; }

        public PopeGrid()
        {
            this.AutoGenerateColumns = false;
            this.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        public new object DataSource
        {
            get => base.DataSource;
            set
            {
                if (value is DataTable || value.GetType().Name.IndexOf("BindingList") == 0)
                {
                    base.DataSource = value;
                }
                else
                {
                    throw new Exception("지원하지 않는 형식입니다");
                }
            }
        }

        public DataGridViewColumn AddColumn(string colName, string headerText, int width, ColTypeEnum colType)
        {
            var col = new DataGridViewTextBoxColumn();
            col.DataPropertyName = colName;
            col.HeaderText = headerText;
            col.Width = width;
            col.Tag = colType;

            switch (colType)
            {
                case ColTypeEnum.OnlyNewEdit:
                    col.ReadOnly = false;
                    break;
                case ColTypeEnum.Edit:
                    col.ReadOnly = false;
                    break;
                default:
                    col.ReadOnly = true;
                    break;
            }

            this.CellValueChanged += PopeGrid_CellValueChanged;
            this.CellBeginEdit += PopeGrid_CellBeginEdit;
            this.Columns.Add(col);

            return col;
        }
        
        public void AddRow()
        {
            var row = this.DataSource.GetType().GetMethod("AddNew").Invoke(this.DataSource, null);
            (row as ModelBase).RowState = ModelBase.RowStateEnum.New;

            this.CurrentCell = this.Rows[this.Rows.GetLastRow(DataGridViewElementStates.Visible)].Cells[0];
            this.CurrentRow.DefaultCellStyle.BackColor = Color.Aqua;

            this.BeginEdit(false);
        }

        public void DeleteRow()
        {
            if (this.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in this.SelectedRows)
                {
                    var item = (row.DataBoundItem as ModelBase);

                    if (item.RowState == ModelBase.RowStateEnum.New)
                    {
                        //삭제
                        this.Rows.Remove(row);
                    }
                    else
                    {
                        item.RowState = ModelBase.RowStateEnum.Deleted;
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
            else if (this.CurrentRow != null)
            {
                var row = this.CurrentRow;
                var item = row.DataBoundItem as ModelBase;

                if (item.RowState == ModelBase.RowStateEnum.New)
                {
                    //삭제
                    this.Rows.Remove(row);
                }
                else
                {
                    item.RowState = ModelBase.RowStateEnum.Deleted;
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private void PopeGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var row = this.Rows[e.RowIndex].DataBoundItem as ModelBase;
            var colType = (ColTypeEnum)this.Columns[e.ColumnIndex].Tag;
            
            if (colType == ColTypeEnum.OnlyNewEdit)
            {
                if (row.RowState != ModelBase.RowStateEnum.New)
                {
                    e.Cancel = true;
                }
            }
        }

        private void PopeGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var row = this.Rows[e.RowIndex];
            var item = row.DataBoundItem as ModelBase;

            if (item != null && item.RowState == ModelBase.RowStateEnum.None)
            {
                item.RowState = ModelBase.RowStateEnum.Modified;
                row.DefaultCellStyle.BackColor = Color.SkyBlue;
            }
        }
    }
}
