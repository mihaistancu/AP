using AP.Instrumentation;
using OpenTelemetry.Resources;
using OpenTelemetry;
using OpenTelemetry.Context.Propagation;
using OpenTelemetry.Trace;
using System.Diagnostics;

namespace AP.Telemetry
{
    public class Trace : ITrace, IDisposable
    {
        private string serviceName = "AP";
        private string serviceVersion = "1.0";
        private TracerProvider provider;
        private ActivitySource source;
        private TextMapPropagator propagator; 

        public IDisposable Start()
        {   
            source = new ActivitySource(serviceName);

            provider = Sdk.CreateTracerProviderBuilder()
                .SetSampler(new AlwaysOnSampler())
                .AddSource(source.Name)
                .SetResourceBuilder(
                    ResourceBuilder.CreateDefault()
                        .AddService(serviceName: serviceName, serviceVersion: serviceVersion))
                .AddHttpClientInstrumentation()
                .AddAspNetCoreInstrumentation()
                .AddJaegerExporter(options => {
                    options.AgentHost = "jaeger";
                })
                .Build();

            propagator = Propagators.DefaultTextMapPropagator;

            return this;
        }

        public IDisposable Start(string span)
        {
            return source.StartActivity(span);
        }

        public IDisposable Start<T>(string span, T carrier, Action<T, string, object> setter)
        {
            var activity = source.StartActivity(span);
            var context = new PropagationContext(activity.Context, Baggage.Current);
            propagator.Inject(context, carrier, setter);
            return activity;
        }

        public IDisposable Start<T>(string span, T carrier, Func<T, string, IEnumerable<string>> getter)
        {
            var parent = propagator.Extract(default, carrier, getter);
            Baggage.Current = parent.Baggage;
            return source.StartActivity(span, default, parent.ActivityContext);
        }

        public void Dispose()
        {
            provider.Dispose();
            source.Dispose();
        }
    }
}
