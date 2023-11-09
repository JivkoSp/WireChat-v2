using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WireChat.Application.Queries;
using WireChat.Application.Queries.Dispatcher;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Components
{
    [Authorize]
    public class NotificationsViewComponent : ViewComponent
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly UserManager<UserReadModel> _userManager;

        public NotificationsViewComponent(IQueryDispatcher queryDispatcher, UserManager<UserReadModel> userManager)
        {
            _queryDispatcher = queryDispatcher;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var getNotificationHubQuery = new GetNotificationHubQuery(Guid.Parse(user.Id));

            var notificationHub = await _queryDispatcher.DispatchAsync(getNotificationHubQuery);

            return View(notificationHub);
        }
    }
}
