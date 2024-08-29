//
// Copyright Grafana Labs
// SPDX-License-Identifier: Apache-2.0
//

#if !NETSTANDARD && !NETFRAMEWORK
using OpenTelemetry.Resources;

namespace Grafana.OpenTelemetry
{
    internal class AWSECSDetectorInitializer : ResourceDetectorInitializer
    {
        public override ResourceDetector Id { get; } = ResourceDetector.AWSECSDetector;

        protected override ResourceBuilder InitializeResourceDetector(ResourceBuilder builder)
        {
            return builder.AddAWSECSDetector();
        }
    }
}
#endif