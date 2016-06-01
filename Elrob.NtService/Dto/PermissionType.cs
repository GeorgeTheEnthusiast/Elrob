﻿namespace Elrob.NtService.Dto
{
    public enum PermissionType
    {
        MainView_RunImport = 2,
        MaterialView_EditRows = 5,
        MaterialView_View = 6,
        MaterialView_AddRows = 21,
        MaterialView_DeleteRows = 22,
        OrderContentView_EditRows = 9,
        OrderContentView_View = 10,
        OrderContentView_AddRows = 25,
        OrderContentView_DeleteRows = 26,
        OrderView_EditRows = 13,
        OrderView_AddRows = 19,
        OrderView_DeleteRows = 20,
        OrderView_View = 14,
        PlaceView_EditRows = 17,
        PlaceView_View = 18,
        PlaceView_AddRows = 23,
        PlaceView_DeleteRows = 24,
        OrderProgressView_EditRows = 29,
        OrderProgressView_View = 27,
        OrderProgressView_AddRows = 28,
        OrderProgressView_DeleteRows = 30,
        OrderProgressView_SeeWhoAddRows = 43,
        UserView_EditRows = 33,
        UserView_View = 31,
        UserView_AddRows = 32,
        UserView_DeleteRows = 34,
        GroupView_EditRows = 37,
        GroupView_View = 35,
        GroupView_AddRows = 36,
        GroupView_DeleteRows = 38,
        PermissionGroupView_View = 41,
        PermissionGroupView_DeletePermission = 40,
        PermissionGroupView_ChangePermissions = 39,
        PlaceChoose_All = 42,
        CardView_View = 44,
        CardView_AddRows = 45,
        CardView_DeleteRows = 46,
        CardView_EditRows = 50
    }
}