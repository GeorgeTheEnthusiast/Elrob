﻿using System;
using System.Windows.Forms;
using Elrob.Terminal.Dto;
using Elrob.Terminal.View;

namespace Elrob.Terminal.Presenter.Interfaces.Main
{
    public interface IMainPresenter
    {
        User GetUser(string loginName);

        DialogResult ShowDialog();

        void ImportOrder();

        void ShowOrderProgressView();
        void SetPermissions();
    }
}
