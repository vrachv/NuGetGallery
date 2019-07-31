// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using NuGet.Services.Entities;
using NuGet.Services.Licenses;

namespace NuGetGallery
{
    public static class ViewModelHelper
    {
        public static DeletePackageViewModel CreateDeletePackageViewModel(
            Package package,
            User currentUser,
            IReadOnlyList<ReportPackageReason> reasons,
            IIconUrlProvider iconUrlProvider)
        {
            return new DeletePackageViewModel().Setup(package, currentUser, reasons, iconUrlProvider);
        }

        public static DisplayLicenseViewModel CreateDisplayLicenseViewModel(
            Package package,
            IReadOnlyCollection<CompositeLicenseExpressionSegment> licenseExpressionSegments,
            string licenseFileContents,
            IIconUrlProvider iconUrlProvider)
        {
            return new DisplayLicenseViewModel().Setup(package, licenseExpressionSegments, licenseFileContents, iconUrlProvider);
        }

        public static DisplayPackageViewModel CreateDisplayPackageViewModel(
            Package package,
            User currentUser,
            PackageDeprecation deprecation,
            IIconUrlProvider iconUrlProvider)
        {
            return new DisplayPackageViewModel().Setup(package, currentUser, deprecation, iconUrlProvider);
        }
    }
}