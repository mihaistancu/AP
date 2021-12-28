using AP.Instrumentation;
using OpenTelemetry;
using OpenTelemetry.Trace;
using System;
using System.Diagnostics;

namespace AP.Telemetry
{
    public class Trace : ITrace, IDisposable
    {
        private TracerProvider provider;
        private ActivitySource source;

        public IDisposable Start()
        {
            source = new ActivitySource("AP");

            provider = Sdk.CreateTracerProviderBuilder()
                .SetSampler(new AlwaysOnSampler())
                .AddSource(source.Name)
                .AddConsoleExporter()
                .Build();

            return this;
        }

        public IDisposable Start(string span)
        {
            return source.StartActivity(span);
        }

        public void Dispose()
        {
            provider.Dispose();
            source.Dispose();
        }
    }
}
