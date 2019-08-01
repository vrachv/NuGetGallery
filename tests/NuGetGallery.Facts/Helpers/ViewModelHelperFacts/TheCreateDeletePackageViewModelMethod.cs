// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using NuGet.Services.Entities;
using Xunit;

namespace NuGetGallery.Helpers
{
    public partial class ViewModelHelperFacts
    {
        public class TheCreateDeletePackageViewModelMethod : ViewModelHelperFactsBase
        {
            [Theory]
            [InlineData(false)]
            [InlineData(true)]
            public void SetsIsLockedProperly(bool isLocked)
            {
                var package = new Package
                {
                    PackageRegistration = new PackageRegistration { Id = "someid", IsLocked = isLocked },
                    Version = "1.2.3"
                };

                var currentUser = new User();
                var reasons = new List<ReportPackageReason>();

                var viewModel = _target.CreateDeletePackageViewModel(package, currentUser, reasons);

                Assert.Equal(isLocked, viewModel.IsLocked);
            }
        }
    }
}
