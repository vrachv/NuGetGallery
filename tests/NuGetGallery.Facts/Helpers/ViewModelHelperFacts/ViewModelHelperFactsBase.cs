// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Moq;
using NuGet.Services.Licenses;
using NuGetGallery.Security;

namespace NuGetGallery.Helpers
{
    public class ViewModelHelperFactsBase
    {
        protected Mock<ISecurityPolicyService> _securityPolicyServiceMock;
        protected Mock<IValidationService> _validationServiceMock;
        protected Mock<IContentObjectService> _contentObjectServiceMock;
        protected Mock<IFeatureFlagService> _featureFlagServiceMock;
        protected Mock<ILicenseExpressionSplitter> _licenseExpressionSplitterMock;
        protected Mock<ITelemetryService> _telemetryServiceMock;
        protected Mock<IPackageService> _packageServiceMock;
        protected ViewModelHelper _target;

        public ViewModelHelperFactsBase()
        {
            _securityPolicyServiceMock = new Mock<ISecurityPolicyService>();
            _validationServiceMock = new Mock<IValidationService>();
            _contentObjectServiceMock = new Mock<IContentObjectService>();
            _featureFlagServiceMock = new Mock<IFeatureFlagService>();
            _licenseExpressionSplitterMock = new Mock<ILicenseExpressionSplitter>();
            _telemetryServiceMock = new Mock<ITelemetryService>();
            _packageServiceMock = new Mock<IPackageService>();

            _target = new ViewModelHelper(
                _securityPolicyServiceMock.Object,
                _validationServiceMock.Object,
                _contentObjectServiceMock.Object,
                _featureFlagServiceMock.Object,
                _licenseExpressionSplitterMock.Object,
                _telemetryServiceMock.Object,
                _packageServiceMock.Object);
        }
    }
}
