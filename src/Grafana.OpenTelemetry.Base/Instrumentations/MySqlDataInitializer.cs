//
// Copyright Grafana Labs
// SPDX-License-Identifier: Apache-2.0
//

using OpenTelemetry.Trace;

namespace Grafana.OpenTelemetry
{
    internal class MySqlDataInitializer : InstrumentationInitializer
    {
        public override Instrumentation Id { get; } = Instrumentation.MySqlData;

        protected override void InitializeTracing(TracerProviderBuilder builder)
        {
            // MySQL.Data.OpenTelemetry
            ReflectionHelper.CallStaticMethod(
                "MySQL.Data.OpenTelemetry",
                "OpenTelemetry.Trace.TracerProviderBuilderExtensions",
                "AddConnectorNet",
                new object[] { builder });

            // OpenTelemetry.Instrumentation.MySqlData
            ReflectionHelper.CallStaticMethod(
                "OpenTelemetry.Instrumentation.MySqlData",
                "OpenTelemetry.Trace.TracerProviderBuilderExtensions",
                "AddMySqlDataInstrumentation",
                new object[] { builder });
        }
    }
}
