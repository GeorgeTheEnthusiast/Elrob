using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Elrob.Terminal.Common;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Main
{
    public interface IOrderPreviewView
    {
        DialogResult ShowDialog();

        CustomBindingList<OrderContent> OrderContents { get; set; }

        Order Order { get; set; }

        TextBox TextBoxOrderName { get; }

        List<Material> Materials { get; set; }

        List<Place> Places { get; set; }

        DataGridView DataGridViewOrderContent { get; }

        DialogResult DialogResult { get; set; }
    }
}
