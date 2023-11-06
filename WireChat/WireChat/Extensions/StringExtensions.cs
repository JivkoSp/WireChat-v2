
namespace WireChat.Extensions
{
    public static class StringExtensions
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        private const string RoboHashUrl = "https://robohash.org/";

        public static string CreatePicture(this string value) 
        {
            var imageBytes = _httpClient.GetByteArrayAsync($"{RoboHashUrl}{value}.png?size=200x200").Result;

            string base64String = Convert.ToBase64String(imageBytes);

            return base64String;
        }
    }
}
