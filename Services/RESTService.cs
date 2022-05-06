namespace Ingenium.Materiaalbeheer.ClientApp.Services
{
    public static class RESTService
    {
        private static string _apiUrl;
        private static HttpClient _httpClient;
        public static bool signedIn;
        public static async Task Initialize(string apiUrl)
        {
            _apiUrl = apiUrl;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            string token = await AppSettings.AuthenticationService.GetToken();
            if (string.IsNullOrEmpty(token))
            {
                //force signed in to true for demo
                signedIn = true;
            }
            else
            {
                signedIn = true;
                _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            }

        }
    }
}
