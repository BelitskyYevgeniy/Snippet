using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApplication1.Middleware
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

            using var timeoutCts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
            using var cts = CancellationTokenSource
                .CreateLinkedTokenSource(context!.RequestAborted, timeoutCts.Token);

            context.RequestAborted = cts.Token;

            await _next(context).ConfigureAwait(false);
        }
    }
}
