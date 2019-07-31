// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Web.Mvc;
using NuGet.Services.Entities;
using NuGet.Services.Licenses;
using NuGetGallery.Security;

namespace NuGetGallery
{
    public class ViewModelHelper
    {
        public static DeletePackageViewModel CreateDeletePackageViewModel(
            Package package,
            User currentUser,
            IReadOnlyList<ReportPackageReason> reasons)
        {
            return new DeletePackageViewModel().Setup(package, currentUser, reasons);
        }

        public static DisplayLicenseViewModel CreateDisplayLicenseViewModel(
            Package package,
            IReadOnlyCollection<CompositeLicenseExpressionSegment> licenseExpressionSegments,
            string licenseFileContents)
        {
            return new DisplayLicenseViewModel().Setup(package, licenseExpressionSegments, licenseFileContents);
        }

        public static DisplayPackageViewModel CreateDisplayPackageViewModel(
            Package package,
            User currentUser,
            PackageDeprecation deprecation)
        {
            return new DisplayPackageViewModel().Setup(package, currentUser, deprecation);
        }

        public static ListPackageItemRequiredSignerViewModel CreateListPackageItemRequiredSignerViewModel(
            Package package,
            User currentUser,
            ISecurityPolicyService securityPolicyService,
            bool wasAADLoginOrMultiFactorAuthenticated)
        {
            return new ListPackageItemRequiredSignerViewModel().Setup(package, currentUser, securityPolicyService, wasAADLoginOrMultiFactorAuthenticated);
        }

        public static ListPackageItemViewModel CreateListPackageItemViewModel(Package package, User currentUser)
        {
            return new ListPackageItemViewModel().Setup(package, currentUser);
        }

        public static ManagePackageViewModel CreateManagePackageViewModel(
            Package package,
            User currentUser,
            IReadOnlyList<ReportPackageReason> reasons,
            UrlHelper url,
            string readMe,
            bool isManageDeprecationEnabled)
        {
            return new ManagePackageViewModel().Setup(package, currentUser, reasons, url, readMe, isManageDeprecationEnabled);
        }
    }
}