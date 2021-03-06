﻿using System.Windows.Forms;
using Elrob.Terminal.Controllers;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Item;
using Elrob.Terminal.Presenter;
using Elrob.Terminal.Presenter.Implementation.Item;
using Elrob.Terminal.Presenter.Interfaces;
using Elrob.Terminal.Presenter.Interfaces.Item;
using Elrob.Terminal.Properties;
using Elrob.Terminal.View.Interfaces.Item;
using Ninject;

namespace Elrob.Terminal.View.Implementations.Item
{
    public partial class OrderItemView : Form, IOrderItemView
    {
        private readonly IOrderItemPresenter _orderItemPresenter;

        public Order PassedOrder { get; set; }

        public TextBox TextBoxName => textBoxName;

        public DateTimePicker DateTimePickerStartDate => dateTimePickerStartDate;

        public ErrorProvider NameErrorProvider => nameErrorProvider;

        public bool IsInEditMode { get; set; }

        public OrderItemView()
        {
            _orderItemPresenter = new OrderItemPresenter(this, Program.Kernel.Get<IOrderItemModel>());
            
            InitializeComponent();
            Icon = Resources.purchase_order;
        }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonAccept_Click(object sender, System.EventArgs e)
        {
            _orderItemPresenter.AcceptChanges();
        }

        public Order Order => new Order()
        {
            Name = textBoxName.Text.Trim(),
            Id = PassedOrder?.Id ?? 0,
            StartDate = dateTimePickerStartDate.Value
        };

        private void textBoxName_Click(object sender, System.EventArgs e)
        {
            OnScreenKeyboardController.ShowOnScreenKeyboard();
        }
    }
}
