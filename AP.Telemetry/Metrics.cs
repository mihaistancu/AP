using AP.Instrumentation;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using System;
using System.Diagnostics.Metrics;

namespace AP.Telemetry
{
    public class Metrics : IMetrics, IDisposable
    {
        private MeterProvider provider;
        private Meter meter;

        public IDisposable Start()
        {
            meter = new Meter("AP", "1.0");

            provider = Sdk.CreateMeterProviderBuilder()
                .AddMeter("AP")
                .AddPrometheusExporter()
                .Build();

            return this;
        }

        public void Observe<T>(string name, Func<T> getter) where T : struct
        {
            var counter = meter.CreateObservableCounter(name, () =>
            {
                return new Measurement<T>(getter());
            });
        }

        public void Dispose()
        {
            provider.Dispose();
            meter.Dispose();
        }
    }
}
