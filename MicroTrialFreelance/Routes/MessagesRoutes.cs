namespace MicroTrialFreelance.Routes
{
    public class MessagesRoutes
    {
        private const string BaseUrl = "messages";

        public const string GetAll = $"{BaseUrl}/all";
        public const string Get = $"{BaseUrl}/{{id}}";
        public const string GetUserMessages = $"{BaseUrl}/byuserid/{{id}}";

        public const string SetMessageRead = $"{BaseUrl}/setmessageread";
        public const string Add = $"{BaseUrl}";
        public const string Update = $"{BaseUrl}/{{id}}";
        public const string Delete = $"{BaseUrl}/{{id}}";
    }
}
