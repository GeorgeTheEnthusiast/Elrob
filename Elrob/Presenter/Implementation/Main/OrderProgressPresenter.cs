using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Elrob.Terminal.Common;
using Elrob.Terminal.Controllers;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Main;
using Elrob.Terminal.Presenter.Interfaces.Item;
using Elrob.Terminal.Presenter.Interfaces.Main;
using Elrob.Terminal.View.Interfaces.Main;
using Ninject;

namespace Elrob.Terminal.Presenter.Implementation.Main
{
    public class OrderProgressPresenter : IOrderProgressPresenter
    {
        private readonly IOrderProgressView _orderProgressView;
        private readonly IOrderProgressModel _orderProgressModel;
        private IOrderProgressItemPresenter _orderProgressItemPresenter;

        public OrderProgressPresenter(IOrderProgressView orderProgressView, IOrderProgressModel orderProgressModel)
        {
            if (orderProgressView == null) throw new ArgumentNullException("orderProgressView");
            if (orderProgressModel == null) throw new ArgumentNullException("orderProgressModel");

            _orderProgressView = orderProgressView;
            _orderProgressModel = orderProgressModel;
        }

        public DialogResult ShowDialog(OrderContent orderContent)
        {
            _orderProgressView.OrderContent = orderContent;

            RefreshData();

            _orderProgressView.TextBoxOrderContent.Text = orderContent.Name;
            _orderProgressView.TextBoxOrder.Text = orderContent.Order.Name;
            _orderProgressView.TextBoxDocumentNumber.Text = orderContent.DocumentNumber;
            _orderProgressView.TextBoxToComplete.Text = orderContent.ToComplete.ToString();
            
            return _orderProgressView.ShowDialog();
        }

        public void RefreshData()
        {
            _orderProgressView.OrderProgresses.Clear();
            var items = _orderProgressModel.GetOrderContentProgressById(_orderProgressView.OrderContent.Id);

            foreach (var item in items)
            {
                _orderProgressView.OrderProgresses.Add(item);
            }

            _orderProgressView.TextBoxCompletedSum.Text = _orderProgressView.OrderProgresses.Sum(x => x.Completed).ToString();
        }

        public void SetPermissions()
        {
            _orderProgressView.ButtonEdit.Enabled = UserFactory.Instance.HasPermission(PermissionType.OrderProgressView_EditRows);
            _orderProgressView.ButtonAdd.Enabled = UserFactory.Instance.HasPermission(PermissionType.OrderProgressView_AddRows);
            _orderProgressView.ButtonDelete.Enabled = UserFactory.Instance.HasPermission(PermissionType.OrderProgressView_DeleteRows);
            _orderProgressView.DataGridViewUserColumn.Visible = UserFactory.Instance.HasPermission(PermissionType.OrderProgressView_SeeWhoAddRows);
        }

        public void ShowAddForm()
        {
            _orderProgressItemPresenter = Program.Kernel.Get<IOrderProgressItemPresenter>();
            var dialogResult = _orderProgressItemPresenter.ShowDialog(_orderProgressView.OrderContent, null);

            if (dialogResult == DialogResult.OK)
            {
                RefreshData();
            }
        }

        public void ShowEditForm()
        {
            var selectedRow = Helpers.GetSelectedRow<OrderProgress>(_orderProgressView.DataGridViewOrderProgress);

            if (selectedRow == default(OrderProgress))
            {
                return;
            }

            _orderProgressItemPresenter = Program.Kernel.Get<IOrderProgressItemPresenter>();
            var dialogResult = _orderProgressItemPresenter.ShowDialog(_orderProgressView.OrderContent, selectedRow);

            if (dialogResult == DialogResult.OK)
            {
                RefreshData();
            }
        }

        public void DeleteOrderProgress()
        {
            var selectedRow = Helpers.GetSelectedRow<OrderProgress>(_orderProgressView.DataGridViewOrderProgress);

            if (selectedRow == default(OrderProgress))
            {
                return;
            }

            if (MessageBox.Show(
                "Czy aby napewno chcesz usunąć ten wpis?",
                "Potwierdź",
                MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                _orderProgressModel.DeleteOrderProgress(selectedRow);
                RefreshData();
            }
        }
    }
}
