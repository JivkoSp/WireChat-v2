using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WireChat.Application.Queries;
using WireChat.Application.Queries.Dispatcher;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Components
{
    public class UserInfoViewComponent : ViewComponent
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly UserManager<UserReadModel> _userManager;

        public UserInfoViewComponent(IQueryDispatcher queryDispatcher, UserManager<UserReadModel> userManager)
        {
            _queryDispatcher = queryDispatcher;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var getUserInfoQuery = new GetUserInfoQuery(user.Id);

            var userInfoDto = await _queryDispatcher.DispatchAsync(getUserInfoQuery);

            return View(userInfoDto);
        }
    }
}
