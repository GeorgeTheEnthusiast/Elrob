using System;
using System.Windows.Forms;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Item;
using Elrob.Terminal.Presenter.Interfaces.Item;
using Elrob.Terminal.View.Interfaces.Item;
using FluentNHibernate.Conventions;

namespace Elrob.Terminal.Presenter.Implementation.Item
{
    public class GroupItemPresenter : IGroupItemPresenter
    {
        private readonly IGroupItemView _groupItemView;
        private readonly IGroupItemModel _groupItemModel;

        public GroupItemPresenter(IGroupItemView groupItemView, IGroupItemModel groupItemModel)
        {
            if (groupItemView == null) throw new ArgumentNullException("groupItemView");
            if (groupItemModel == null) throw new ArgumentNullException("groupItemModel");

            _groupItemView = groupItemView;
            _groupItemModel = groupItemModel;
        }
        
        public DialogResult ShowDialog(Group group)
        {
            _groupItemView.PassedGroup = group;
            _groupItemView.ErrorProviderName.Clear();

            if (_groupItemView.PassedGroup != null)
            {
                _groupItemView.IsInEditMode = true;
                _groupItemView.TextBoxName.Text = _groupItemView.PassedGroup.Name;
            }
            else
            {
                _groupItemView.IsInEditMode = false;
            }

            return _groupItemView.ShowDialog();
        }

        public void AcceptChanges(bool IsInEditMode)
        {
            var orderExists = _groupItemModel.IsGroupExist(_groupItemView.FilledGroup.Name);

            if (orderExists)
            {
                _groupItemView.ErrorProviderName.SetError(_groupItemView.TextBoxName, "Grupa z taką nazwą już istnieje!");
                return;
            }
            else
            {
                _groupItemView.ErrorProviderName.Clear();
            }

            if (IsInEditMode)
            {
                _groupItemModel.UpdateGroup(_groupItemView.FilledGroup);
            }
            else
            {
                _groupItemModel.AddGroup(_groupItemView.FilledGroup);
            }

            _groupItemView.DialogResult = DialogResult.OK;
        }
    }
}
