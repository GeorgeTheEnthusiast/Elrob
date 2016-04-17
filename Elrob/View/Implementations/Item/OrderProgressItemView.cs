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
        
        public OrderProgress PassedOrderProgress { get; set; }

        public OrderContent PassedOrderContent { get; set; }

        public bool IsInEditMode { get; set; }

        public NumericUpDown NumericUpDownCompleted => numericUpDownCompleted;

        public DateTimePicker DateTimePickerTimeSpend => dateTimePickerTimeSpend;

        public OrderProgressItemView()
        {
            _orderProgressItemPresenter = new OrderProgressItemPresenter(this, Program.Kernel.Get<IOrderProgressItemModel>());
            
            InitializeComponent();

            dateTimePickerTimeSpend.Format = DateTimePickerFormat.Time;
        }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonAccept_Click(object sender, System.EventArgs e)
        {
            _orderProgressItemPresenter.AcceptChanges();
        }

        public OrderProgress OrderProgress => new OrderProgress()
        {
            Completed = (int)numericUpDownCompleted.Value,
            User = UserFactory.Instance.LoggedUser,
            TimeSpend = dateTimePickerTimeSpend.Value.TimeOfDay,
            OrderContent = PassedOrderContent,
            Id = PassedOrderProgress?.Id ?? 0,
            ProgressCreatedDate = PassedOrderProgress?.ProgressCreatedDate ?? DateTime.Now,
            ProgressModifiedDate = PassedOrderProgress == null ? (DateTime?) null : DateTime.Now
        };
    }
}
