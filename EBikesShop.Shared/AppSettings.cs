namespace EBikesShop.Shared
{
    public class AppSettings
    {
#if DEBUG
        private static string _baseUrl = Shared.BaseUrl.Development;
#else
        private static string _baseUrl = Shared.BaseUrl.Production;
#endif

        public string BaseUrl { get; set; } = _baseUrl;

        public string ApiBaseUrl { get; set; } = $"{_baseUrl}/api";
    }
}
