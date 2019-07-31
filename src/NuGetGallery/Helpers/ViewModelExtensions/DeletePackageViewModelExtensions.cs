// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Globalization;
using NuGet.Services.Entities;

namespace NuGetGallery
{
    internal static class DeletePackageViewModelExtensions
    {
        internal static DeletePackageViewModel Setup(
            this DeletePackageViewModel viewModel,
            Package package,
            User currentUser,
            IReadOnlyList<ReportPackageReason> reasons)
        {
            ((DisplayPackageViewModel)viewModel).Setup(package, currentUser, deprecation: null);

            viewModel.DeletePackagesRequest = new DeletePackagesRequest
            {
                Packages = new List<string>
                {
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "{0}|{1}",
                        package.PackageRegistration.Id,
                        package.Version)
                },
                ReasonChoices = reasons
            };

            viewModel.IsLocked = package.PackageRegistration.IsLocked;

            return viewModel;
        }
    }
}