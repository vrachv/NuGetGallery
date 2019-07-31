// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Web.Mvc;
using NuGet.Services.Entities;
using NuGet.Services.Licenses;
using NuGetGallery.Security;

namespace NuGetGallery
{
    public partial class ViewModelHelper
    {
        public static DeletePackageViewModel CreateDeletePackageViewModel(
            Package package,
            User currentUser,
            IReadOnlyList<ReportPackageReason> reasons)
        {
            var viewModel = new DeletePackageViewModel();
            return SetupDeletePackageViewModel(viewModel, package, currentUser, reasons);
        }

        public static DisplayLicenseViewModel CreateDisplayLicenseViewModel(
            Package package,
            IReadOnlyCollection<CompositeLicenseExpressionSegment> licenseExpressionSegments,
            string licenseFileContents)
        {
            var viewModel = new DisplayLicenseViewModel();
            return SetupDisplayLicenseViewModel(viewModel, package, licenseExpressionSegments, licenseFileContents);
        }

        public static DisplayPackageViewModel CreateDisplayPackageViewModel(
            Package package,
            User currentUser,
            PackageDeprecation deprecation)
        {
            var viewModel = new DisplayPackageViewModel();
            return SetupDisplayPackageViewModel(viewModel, package, currentUser, deprecation);
        }

        public static ListPackageItemRequiredSignerViewModel CreateListPackageItemRequiredSignerViewModel(
            Package package,
            User currentUser,
            ISecurityPolicyService securityPolicyService,
            bool wasAADLoginOrMultiFactorAuthenticated)
        {
            var viewModel = new ListPackageItemRequiredSignerViewModel();
            return SetupListPackageItemRequiredSignerViewModel(viewModel, package, currentUser, securityPolicyService, wasAADLoginOrMultiFactorAuthenticated);
        }

        public static ListPackageItemViewModel CreateListPackageItemViewModel(Package package, User currentUser)
        {
            var viewModel = new ListPackageItemViewModel();
            return SetupListPackageItemViewModel(viewModel, package, currentUser);
        }

        public static ManagePackageViewModel CreateManagePackageViewModel(
            Package package,
            User currentUser,
            IReadOnlyList<ReportPackageReason> reasons,
            UrlHelper url,
            string readMe,
            bool isManageDeprecationEnabled)
        {
            var viewModel = new ManagePackageViewModel();
            return SetupManagePackageViewModel(viewModel, package, currentUser, reasons, url, readMe, isManageDeprecationEnabled);
        }

        public static PackageViewModel CreatePackageViewModel(Package package)
        {
            var viewModel = new PackageViewModel();
            return SetupPackageViewModel(viewModel, package);
        }
    }
}