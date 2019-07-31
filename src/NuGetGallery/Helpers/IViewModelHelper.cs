// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Web.Mvc;
using NuGet.Services.Entities;
using NuGet.Services.Licenses;

namespace NuGetGallery
{
    public interface IViewModelHelper
    {
        DeletePackageViewModel CreateDeletePackageViewModel(Package package, User currentUser, IReadOnlyList<ReportPackageReason> reasons);
        DisplayLicenseViewModel CreateDisplayLicenseViewModel(Package package, IReadOnlyCollection<CompositeLicenseExpressionSegment> licenseExpressionSegments, string licenseFileContents);
        DisplayPackageViewModel CreateDisplayPackageViewModel(Package package, User currentUser, PackageDeprecation deprecation);
        ListPackageItemRequiredSignerViewModel CreateListPackageItemRequiredSignerViewModel(Package package, User currentUser, bool wasAADLoginOrMultiFactorAuthenticated);
        ListPackageItemViewModel CreateListPackageItemViewModel(Package package, User currentUser);
        ManagePackageViewModel CreateManagePackageViewModel(Package package, User currentUser, IReadOnlyList<ReportPackageReason> reasons, UrlHelper url, string readMe, bool isManageDeprecationEnabled);
        PackageViewModel CreatePackageViewModel(Package package);
    }
}