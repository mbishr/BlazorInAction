namespace EBikesShop.Shared
{
    public static class BaseUrl
    {
        // IIS Express hosted URL, see EBikesShop.Server/Properties/launchSettings.json for all possible profiles
        public static string Development = "http://localhost:61380";
        // Azure Web Services hosted URL
        public static string Production = "https://ebikesshopserver.azurewebsites.net";
    }
}