namespace AksApi.Options
{
    public class ApplicationInsightsOptions
    {
        public string InstrumentationKey { get; set; }
        public string MinimumLogLevel { get; set; }
        public bool EnableAdaptiveSampling { get; set; }
    }
}
