using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Model;
using Elrob.Terminal.Model.Implementations;
using Elrob.Terminal.Model.Implementations.Choose;
using Elrob.Terminal.Model.Implementations.Item;
using Elrob.Terminal.Model.Implementations.Main;
using Elrob.Terminal.Model.Interfaces;
using Elrob.Terminal.Model.Interfaces.Choose;
using Elrob.Terminal.Model.Interfaces.Item;
using Elrob.Terminal.Model.Interfaces.Main;
using Elrob.Terminal.Presenter;
using Elrob.Terminal.Presenter.Implementation.Choose;
using Elrob.Terminal.Presenter.Implementation.Item;
using Elrob.Terminal.Presenter.Implementation.Main;
using Elrob.Terminal.Presenter.Interfaces;
using Elrob.Terminal.Presenter.Interfaces.Choose;
using Elrob.Terminal.Presenter.Interfaces.Item;
using Elrob.Terminal.Presenter.Interfaces.Main;
using Elrob.Terminal.View;
using Elrob.Terminal.View.Implementations.Choose;
using Elrob.Terminal.View.Implementations.Item;
using Elrob.Terminal.View.Implementations.Main;
using Elrob.Terminal.View.Interfaces;
using Elrob.Terminal.View.Interfaces.Choose;
using Elrob.Terminal.View.Interfaces.Item;
using Elrob.Terminal.View.Interfaces.Main;
using Ninject.Modules;

namespace Elrob.Terminal.Common
{
    public class DependencyBindings : NinjectModule
    {
        public override void Load()
        {
            #region Converters
            Bind<IMaterialConverter>().To<MaterialConverter>();
            Bind<IOrderContentConverter>().To<OrderContentConverter>();
            Bind<IPlaceConverter>().To<PlaceConverter>();
            Bind<IUserConverter>().To<UserConverter>();
            Bind<IOrderConverter>().To<OrderConverter>();
            Bind<IOrderProgressConverter>().To<OrderProgressConverter>();
            Bind<IGroupConverter>().To<GroupConverter>();
            Bind<IPermissionGroupConverter>().To<PermissionGroupConverter>();
            Bind<IPermissionConverter>().To<PermissionConverter>();
            #endregion

            #region Model
            Bind<ILoginModel>().To<LoginModel>();
            Bind<IMainModel>().To<MainModel>();
            Bind<IOrderPreviewModel>().To<OrderPreviewModel>();
            Bind<IMaterialModel>().To<MaterialModel>();
            Bind<IPlaceModel>().To<PlaceModel>();
            Bind<IOrderModel>().To<OrderModel>();
            Bind<IOrderContentModel>().To<OrderContentModel>();
            Bind<IPlaceChooseModel>().To<PlaceChooseModel>();
            Bind<IOrderItemModel>().To<OrderItemModel>();
            Bind<IMaterialItemModel>().To<MaterialItemModel>();
            Bind<IPlaceItemModel>().To<PlaceItemModel>();
            Bind<IOrderContentItemModel>().To<OrderContentItemModel>();
            Bind<IOrderProgressModel>().To<OrderProgressModel>();
            Bind<IOrderProgressItemModel>().To<OrderProgressItemModel>();
            Bind<IUserModel>().To<UserModel>();
            Bind<IUserItemModel>().To<UserItemModel>();
            Bind<IGroupModel>().To<GroupModel>();
            Bind<IGroupItemModel>().To<GroupItemModel>();
            Bind<IPermissionGroupModel>().To<PermissionGroupModel>();
            Bind<IPermissionGroupItemModel>().To<PermissionGroupItemModel>();
            Bind<IOrderChooseModel>().To<OrderChooseModel>();
            Bind<IOrderContentChooseModel>().To<OrderContentChooseModel>();
            Bind<IOrderPreviewItemModel>().To<OrderPreviewItemModel>();
            #endregion

            #region View
            Bind<ILoginView>().To<LoginView>();
            Bind<IMainView>().To<MainView>();
            Bind<IOrderPreviewView>().To<OrderPreviewView>();
            Bind<IMaterialView>().To<MaterialView>();
            Bind<IPlaceView>().To<PlaceView>();
            Bind<IOrderView>().To<OrderView>();
            Bind<IOrderContentView>().To<OrderContentView>();
            Bind<IPlaceChooseView>().To<PlaceChooseView>();
            Bind<IOrderItemView>().To<OrderItemView>();
            Bind<IMaterialItemView>().To<MaterialItemView>();
            Bind<IPlaceItemView>().To<PlaceItemView>();
            Bind<IOrderContentItemView>().To<OrderContentItemView>();
            Bind<IOrderProgressView>().To<OrderProgressView>();
            Bind<IOrderProgressItemView>().To<OrderProgressItemView>();
            Bind<IUserView>().To<UserView>();
            Bind<IUserItemView>().To<UserItemView>();
            Bind<IGroupView>().To<GroupView>();
            Bind<IGroupItemView>().To<GroupItemView>();
            Bind<IPermissionGroupView>().To<PermissionGroupView>();
            Bind<IPermissionGroupItemView>().To<PermissionGroupItemView>();
            Bind<IOrderChooseView>().To<OrderChooseView>();
            Bind<IOrderContentChooseView>().To<OrderContentChooseView>();
            Bind<IOrderPreviewItemView>().To<OrderPreviewItemView>();
            #endregion

            #region Presenter
            Bind<ILoginPresenter>().To<LoginPresenter>();
            Bind<IMainPresenter>().To<MainPresenter>();
            Bind<IOrderPreviewPresenter>().To<OrderPreviewPresenter>();
            Bind<IMaterialPresenter>().To<MaterialPresenter>();
            Bind<IPlacePresenter>().To<PlacePresenter>();
            Bind<IOrderPresenter>().To<OrderPresenter>();
            Bind<IOrderContentPresenter>().To<OrderContentPresenter>();
            Bind<IPlaceChoosePresenter>().To<PlaceChoosePresenter>();
            Bind<IOrderItemPresenter>().To<OrderItemPresenter>();
            Bind<IMaterialItemPresenter>().To<MaterialItemPresenter>();
            Bind<IPlaceItemPresenter>().To<PlaceItemPresenter>();
            Bind<IOrderContentItemPresenter>().To<OrderContentItemPresenter>();
            Bind<IOrderProgressPresenter>().To<OrderProgressPresenter>();
            Bind<IOrderProgressItemPresenter>().To<OrderProgressItemPresenter>();
            Bind<IUserPresenter>().To<UserPresenter>();
            Bind<IUserItemPresenter>().To<UserItemPresenter>();
            Bind<IGroupPresenter>().To<GroupPresenter>();
            Bind<IGroupItemPresenter>().To<GroupItemPresenter>();
            Bind<IPermissionGroupPresenter>().To<PermissionGroupPresenter>();
            Bind<IPermissionGroupItemPresenter>().To<PermissionGroupItemPresenter>();
            Bind<IOrderChoosePresenter>().To<OrderChoosePresenter>();
            Bind<IOrderContentChoosePresenter>().To<OrderContentChoosePresenter>();
            Bind<IOrderPreviewItemPresenter>().To<OrderPreviewItemPresenter>();
            #endregion
        }
    }
}
