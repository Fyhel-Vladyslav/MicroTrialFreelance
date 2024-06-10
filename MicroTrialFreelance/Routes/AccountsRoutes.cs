namespace MicroTrialFreelance.Routes
{
    public class AccountsRoutes
    {
        private const string BaseUrl = "accounts";

        public const string GetAll = $"{BaseUrl}/all";
        public const string Get = $"{BaseUrl}/{{id}}";

        public const string Login = $"{BaseUrl}/login";
        public const string Logout = $"{BaseUrl}/logout";
        public const string Add = $"{BaseUrl}";
        public const string Update = $"{BaseUrl}/{{id}}";
        public const string Delete = $"{BaseUrl}/{{id}}";
    }
}
