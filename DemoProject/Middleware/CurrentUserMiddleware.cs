using BusinessLayer.Abstract;

namespace DemoProject.Middleware
{
    public class CurrentUserMiddleware
    {
        private readonly RequestDelegate _next;

        public CurrentUserMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IWriterService writerService)
        {
            var userName = context.User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                var user = await writerService.GetCurrentUserByUsername(userName);
                context.Items["CurrentUser"] = user;
            }

            await _next(context);
        }
    }

}
