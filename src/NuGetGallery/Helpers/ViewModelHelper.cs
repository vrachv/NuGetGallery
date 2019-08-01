// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Web.Mvc;
using NuGet.Services.Entities;
using NuGet.Services.Licenses;
using NuGetGallery.Security;

namespace NuGetGallery
{
    public partial class ViewModelHelper : IViewModelHelper
    {
        private readonly ISecurityPolicyService _securityPolicyService;
        private readonly IValidationService _validationService;
        private readonly IContentObjectService _contentObjectService;
        private readonly IFeatureFlagService _featureFlagService;
        private readonly ILicenseExpressionSplitter _licenseExpressionSplitter;
        private readonly ITelemetryService _telemetryService;
        private readonly IPackageService _packageService;

        public ViewModelHelper(
            ISecurityPolicyService securityPolicyService,
            IValidationService validationService,
            IContentObjectService contentObjectService,
            IFeatureFlagService featureFlagService,
            ILicenseExpressionSplitter licenseExpressionSplitter,
            ITelemetryService telemetryService,
            IPackageService packageService)
        {
            _securityPolicyService = securityPolicyService ?? throw new ArgumentNullException(nameof(securityPolicyService));
            _validationService = validationService ?? throw new ArgumentNullException(nameof(validationService));
            _contentObjectService = contentObjectService ?? throw new ArgumentNullException(nameof(contentObjectService));
            _featureFlagService = featureFlagService ?? throw new ArgumentNullException(nameof(featureFlagService));
            _licenseExpressionSplitter = licenseExpressionSplitter ?? throw new ArgumentNullException(nameof(licenseExpressionSplitter));
            _telemetryService = telemetryService ?? throw new ArgumentNullException(nameof(telemetryService));
            _packageService = packageService ?? throw new ArgumentNullException(nameof(packageService));
        }

        public DeletePackageViewModel CreateDeletePackageViewModel(
            Package package,
            User currentUser,
            IReadOnlyList<ReportPackageReason> reasons)
        {
            var viewModel = new DeletePackageViewModel();
            return SetupDeletePackageViewModel(viewModel, package, currentUser, reasons);
        }

        public DisplayLicenseViewModel CreateDisplayLicenseViewModel(
            Package package,
            IReadOnlyCollection<CompositeLicenseExpressionSegment> licenseExpressionSegments,
            string licenseFileContents)
        {
            var viewModel = new DisplayLicenseViewModel();
            return SetupDisplayLicenseViewModel(viewModel, package, licenseExpressionSegments, licenseFileContents);
        }

        public DisplayPackageViewModel CreateDisplayPackageViewModel(
            Package package,
            User currentUser,
            PackageDeprecation deprecation,
            string readmeHtml)
        {
            var viewModel = new DisplayPackageViewModel();
            return SetupDisplayPackageViewModel(
                viewModel,
                package,
                currentUser,
                deprecation,
                readmeHtml);
        }

        public ListPackageItemRequiredSignerViewModel CreateListPackageItemRequiredSignerViewModel(
            Package package,
            User currentUser,
            bool wasAADLoginOrMultiFactorAuthenticated)
        {
            var viewModel = new ListPackageItemRequiredSignerViewModel();
            return SetupListPackageItemRequiredSignerViewModel(viewModel, package, currentUser, wasAADLoginOrMultiFactorAuthenticated);
        }

        public ListPackageItemViewModel CreateListPackageItemViewModel(Package package, User currentUser)
        {
            var viewModel = new ListPackageItemViewModel();
            return SetupListPackageItemViewModel(viewModel, package, currentUser);
        }

        public ManagePackageViewModel CreateManagePackageViewModel(
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

        public PackageViewModel CreatePackageViewModel(Package package)
        {
            var viewModel = new PackageViewModel();
            return SetupPackageViewModel(viewModel, package);
        }

        public DeleteAccountListPackageItemViewModel CreateDeleteAccountListPackageItemViewModel(Package package, User userToDelete, User currentUser)
        {
            var viewModel = new DeleteAccountListPackageItemViewModel();
            SetupListPackageItemViewModel(viewModel, package, currentUser);
            viewModel.WillBeOrphaned = _packageService.WillPackageBeOrphanedIfOwnerRemoved(package.PackageRegistration, userToDelete);
            return viewModel;
        }
    }
}