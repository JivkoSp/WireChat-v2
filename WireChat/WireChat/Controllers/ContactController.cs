using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;
using WireChat.Application.Dtos;
using WireChat.Application.Queries;
using WireChat.Application.Queries.Dispatcher;

namespace WireChat.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly IMemoryCache _cache;
        private readonly MemoryCacheEntryOptions _cacheEntryOptions;
        private const string SearchedContactsCacheKey = "SearchedContactsDataCache";

        public ContactController(IQueryDispatcher queryDispatcher, IMemoryCache cache)
        {
            _queryDispatcher = queryDispatcher;
            _cache = cache;

            _cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1),
                SlidingExpiration = TimeSpan.FromMinutes(10)
            };
        }

        [HttpGet]
        public async Task<IActionResult> SearchContact(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return Json(new List<string>());
            }

            List<ChatUserDto> contacts;

            if (!_cache.TryGetValue(SearchedContactsCacheKey, out contacts))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var getContactsQuery = new GetContactsQuery(userId);

                contacts = await _queryDispatcher.DispatchAsync(getContactsQuery);

                _cache.Set(SearchedContactsCacheKey, contacts, _cacheEntryOptions);
            }

            // Filter the cached data
            var result = contacts
                .Where(x => x.UserName.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();

            return new JsonResult(result);
        }
    }
}
