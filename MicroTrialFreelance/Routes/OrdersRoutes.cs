namespace MicroTrialFreelance.Routes
{
    public class OrdersRoutes
    {
        private const string BaseUrl = "orders";

        public const string GetAll = $"{BaseUrl}/all";
        public const string Get = $"{BaseUrl}/{{id}}";
        public const string GetUserOrders = $"{BaseUrl}/byuserid/{{id}}";

        public const string Add = $"{BaseUrl}";
        public const string Update = $"{BaseUrl}/{{id}}";
        public const string Delete = $"{BaseUrl}/{{id}}";
    }
}
