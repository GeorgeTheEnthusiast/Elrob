using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elrob.Terminal.Common
{
    public static class Helpers
    {
        public static string GetPropertyName<TObject, TResult>(Expression<Func<TObject, TResult>> exp)
        {
            return (((MemberExpression)(exp.Body)).Member).Name;
        }

        public static T GetSelectedRow<T>(DataGridView dataGridView)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Najpierw zaznacz element!");
                return default(T);
            }

            var selectedRow = (T)dataGridView.SelectedRows[0].DataBoundItem;

            return selectedRow;
        }

        public static void SortDataGridView(DataGridView dataGridView, int columnIndex)
        {
            var column = dataGridView.Columns[columnIndex];

            if (column.Tag == null)
            {
                column.Tag = "";
                dataGridView.Sort(column, ListSortDirection.Ascending);

            }
            else
            {
                column.Tag = null;
                dataGridView.Sort(column, ListSortDirection.Descending);
            }
        }

        public static void textBox_FitHeightToText(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            Size size = TextRenderer.MeasureText(textBox.Text, textBox.Font);

            if (textBox.Width < size.Width)
            {
                textBox.Height = (size.Height + textBox.Margin.Bottom + textBox.Margin.Top) * 2;
            }
        }
    }
}
