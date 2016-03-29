using System;
using System.Collections.Generic;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Main;
using Elrob.Terminal.Presenter.Interfaces.Main;
using Elrob.Terminal.View.Interfaces.Main;

namespace Elrob.Terminal.Presenter.Implementation.Main
{
    public class GroupPresenter : IGroupPresenter
    {
        private readonly IGroupView _groupView;
        private readonly IGroupModel _groupModel;

        public GroupPresenter(IGroupView groupView, IGroupModel groupModel)
        {
            if (groupView == null) throw new ArgumentNullException("groupView");
            if (groupModel == null) throw new ArgumentNullException("groupModel");

            _groupView = groupView;
            _groupModel = groupModel;
        }

        public List<Group> GetAllGroups()
        {
            return _groupModel.GetAllGroups();
        }

        public bool DeleteGroup(Group group)
        {
            return _groupModel.DeleteGroup(group);
        }

        public void ShowDialog()
        {
            RefreshData();

            _groupView.ShowDialog();
        }

        public void RefreshData()
        {
            _groupView.Groups.Clear();
            var groups = _groupModel.GetAllGroups();
            foreach (var group in groups)
            {
                _groupView.Groups.Add(group);
            }
        }
    }
}
