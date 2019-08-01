// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Globalization;
using NuGet.Services.Entities;

namespace NuGetGallery
{
    public partial class ViewModelHelper
    {
        private DeletePackageViewModel SetupDeletePackageViewModel(
            DeletePackageViewModel viewModel,
            Package package,
            User currentUser,
            IReadOnlyList<ReportPackageReason> reasons)
        {
            SetupDisplayPackageViewModel(viewModel, package, currentUser, deprecation: null, readMeHtml: null);

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