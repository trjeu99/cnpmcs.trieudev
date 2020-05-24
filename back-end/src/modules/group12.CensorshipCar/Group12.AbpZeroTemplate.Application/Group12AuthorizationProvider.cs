﻿using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using GSoft.AbpZeroTemplate;

namespace Group12.AbpZeroTemplate.Application
{
    public class Group12AuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

        public Group12AuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public Group12AuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //COMMON PERMISSIONS (FOR BOTH OF TENANTS AND HOST)

            var pages = context.GetPermissionOrNull("Pages") ?? context.CreatePermission("Pages", L("Pages"));
            var group0 = pages.CreateChildPermission("Pages.Group12", L("Group12"));


            var demoModels = pages.CreateChildPermission(Group12PermissionsConst.Pages_Administration_Car, L("Car"));
            demoModels.CreateChildPermission(Group12PermissionsConst.Pages_Administration_Car_Add, L("Create"));
            demoModels.CreateChildPermission(Group12PermissionsConst.Pages_Administration_Car_Update, L("Edit"));
            demoModels.CreateChildPermission(Group12PermissionsConst.Pages_Administration_Car_View, L("View"));
            demoModels.CreateChildPermission(Group12PermissionsConst.Pages_Administration_Car_Delete, L("Delete"));
            demoModels.CreateChildPermission(Group12PermissionsConst.Pages_Administration_Car_Approve, L("Approve"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpZeroTemplateConsts.LocalizationSourceName);
        }
    }
}
