﻿using System.Collections.Generic;
using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Presenter.Interfaces.Main
{
    public interface IOrderProgressPresenter
    {
        DialogResult ShowDialog(OrderContent orderContent);

        void RefreshData();

        void SetPermissions();

        void ShowAddForm();

        void ShowEditForm();

        void DeleteOrderProgress();
    }
}
