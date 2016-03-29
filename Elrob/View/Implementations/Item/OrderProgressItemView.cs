using System;
using System.Windows.Forms;
using Elrob.Terminal.Controllers;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Item;
using Elrob.Terminal.Presenter;
using Elrob.Terminal.Presenter.Implementation.Item;
using Elrob.Terminal.Presenter.Interfaces;
using Elrob.Terminal.Presenter.Interfaces.Item;
using Elrob.Terminal.View.Interfaces.Item;
using Ninject;

namespace Elrob.Terminal.View.Implementations.Item
{
    public partial class OrderProgressItemView : Form, IOrderProgressItemView
    {
        private readonly IOrderProgressItemPresenter _orderProgressItemPresenter;

        private bool _isInEditMode;

        private OrderProgress _orderProgress;
        private OrderContent _orderContent;

        public OrderProgressItemView()
        {
            _orderProgressItemPresenter = new OrderProgressItemPresenter(this, Program.Kernel.Get<IOrderProgressItemModel>());
            
            InitializeComponent();

            dateTimePickerTimeSpend.Format = DateTimePickerFormat.Time;
        }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonAccept_Click(object sender, System.EventArgs e)
        {
            if (_isInEditMode)
            {
                _orderProgressItemPresenter.UpdateOrderProgress(OrderProgress);
            }
            else
            {
                _orderProgressItemPresenter.AddOrderProgress(OrderProgress);
            }

            DialogResult = DialogResult.OK;
        }

        public OrderProgress OrderProgress => new OrderProgress()
        {
            Completed = (int)numericUpDownCompleted.Value,
            User = UserFactory.Instance.LoggedUser,
            TimeSpend = dateTimePickerTimeSpend.Value.TimeOfDay,
            OrderContent = _orderContent,
            Id = _orderProgress?.Id ?? 0,
            ProgressCreatedDate = _orderProgress?.ProgressCreatedDate ?? DateTime.Now,
            ProgressModifiedDate = _orderProgress == null ? (DateTime?) null : DateTime.Now
        };

        public DialogResult ShowDialog(OrderContent orderContent, OrderProgress orderProgress)
        {
            _orderProgress = orderProgress;
            _orderContent = orderContent;

            if (_orderProgress != null)
            {
                _isInEditMode = true;
                numericUpDownCompleted.Value = _orderProgress.Completed;
                dateTimePickerTimeSpend.Value = new DateTime(
                    DateTime.Now.Year,
                    DateTime.Now.Month,
                    DateTime.Now.Day,
                    _orderProgress.TimeSpend.Hours,
                    _orderProgress.TimeSpend.Minutes,
                    _orderProgress.TimeSpend.Seconds);
            }
            else
            {
                _isInEditMode = false;
            }

            return base.ShowDialog();
        }
    }
}
