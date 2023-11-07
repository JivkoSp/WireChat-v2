using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Controllers
{
    public class UserSettingsController : Controller
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly UserManager<UserReadModel> _userManager;
        private const string RoboHashUrl = "https://robohash.org/";

        public UserSettingsController(UserManager<UserReadModel> userManager)
        {
            _userManager = userManager;
        }

        // Generate random strings
        private static string GenerateRandomString(int length)
        {
            var random = new Random();

            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";

            char[] randomString = new char[length];

            for (int i = 0; i < randomString.Length; i++)
            {
                randomString[i] = chars[random.Next(chars.Length)];
            }

            return new string(randomString);
        }

        // Fetch images from RoboHashUrl.
        [HttpGet]
        public async Task<IActionResult> FetchRoboHashImages(int numberOfRandomImages = 4)
        {
            // List of image sets
            var sets = new List<string> { "set2", "set3", "set4" };

            // List of fetched images as bytes.
            var imagesAsBase64 = new List<string>();

            var userName = User.Identity.Name;

            if(userName != null)
            {
                var imagesToFetch = new List<string>()
                {
                    $"{RoboHashUrl}{userName}.png?size=200x200"
                };

                // Add images for the user-specified name for each set
                foreach (var set in sets)
                {
                    string url = $"{RoboHashUrl}{userName}.png?set={set}&size=200x200";
                    imagesToFetch.Add(url);
                }

                // Generate random names and add images for each
                for (int i = 0; i < numberOfRandomImages; i++)
                {
                    string randomName = GenerateRandomString(6);  // Generate a random 6-character string

                    string url = $"{RoboHashUrl}{randomName}.png?size=200x200";  // Use default set

                    imagesToFetch.Add(url);

                    foreach (var set in sets)
                    {
                        url = $"{RoboHashUrl}{randomName}.png?set={set}&size=200x200";

                        imagesToFetch.Add(url);
                    }
                }

                // Fetch images
                foreach (var imageUrl in imagesToFetch)
                {
                    Console.WriteLine($"Fetching image from: {imageUrl}");

                    var imageBytes = await _httpClient.GetByteArrayAsync(imageUrl);

                    string base64String = Convert.ToBase64String(imageBytes);

                    imagesAsBase64.Add(base64String);
                }
            }

            return new JsonResult(imagesAsBase64);
        }

        [HttpPost]
        public async Task UpdateProfilePicture(string profilePicture)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            user.UserPicture = profilePicture;

            await _userManager.UpdateAsync(user);
        }
    }
}
