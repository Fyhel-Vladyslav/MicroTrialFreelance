namespace MicroTrialFreelance.Routes
{
    public class SolutionsRoutes
    {
        private const string BaseUrl = "solutions";

        public const string GetAll = $"{BaseUrl}/all";
        public const string Get = $"{BaseUrl}/{{id}}";
        public const string GetUserSolutions = $"{BaseUrl}/byuserid/{{id}}";
        public const string GetOrderSolutions = $"{BaseUrl}/byorderid/{{id}}";

        public const string Add = $"{BaseUrl}";
        public const string Update = $"{BaseUrl}/{{id}}";
        public const string Delete = $"{BaseUrl}/{{id}}";
    }
}
