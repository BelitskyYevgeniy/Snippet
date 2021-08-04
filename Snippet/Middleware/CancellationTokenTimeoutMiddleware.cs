using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Snippet.WebAPI.Middleware
{
    public class CancellationTokenTimeoutMiddleware
    {
        private readonly RequestDelegate _next;

        public CancellationTokenTimeoutMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            using var timeoutCts = new CancellationTokenSource(TimeSpan.FromSeconds(5000));
            using var cts = CancellationTokenSource
                .CreateLinkedTokenSource(context!.RequestAborted, timeoutCts.Token);

            context.RequestAborted = cts.Token;

            await _next(context).ConfigureAwait(false);
        }
    }

    public static class CancellationTokenTimeoutMiddlewareExtensions
    {
        public static IApplicationBuilder UseCancellationTokenTimeout(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CancellationTokenTimeoutMiddleware>();
        }
    }
}
