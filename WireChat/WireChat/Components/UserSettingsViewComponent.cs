using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WireChat.Application.Queries;
using WireChat.Application.Queries.Dispatcher;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Components
{
    [Authorize]
    public class UserSettingsViewComponent : ViewComponent
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly UserManager<UserReadModel> _userManager;

        public UserSettingsViewComponent(IQueryDispatcher queryDispatcher, UserManager<UserReadModel> userManager)
        {
            _queryDispatcher = queryDispatcher;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var getUserSettingsQuery = new GetUserSettingsQuery(user.Id);

            var userDto = await _queryDispatcher.DispatchAsync(getUserSettingsQuery);

            return View(userDto);
        }
    }
}
