using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Snippet.WebAPI.Middleware
{
    public static class CustomExceptionMidldewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature?>();

                    if (contextFeature != null)
                    {
                        context.Response.ContentType = "text/plain";

                        if (contextFeature.Error is BadRequestException exception)
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                            logger.LogWarning(exception.Message, nameof(BadRequestException));

                            await context.Response.WriteAsync(exception.Message).ConfigureAwait(false);

                            return;
                        }

                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    }

                    await context.Response.WriteAsync("Internal Server Error").ConfigureAwait(false);
                });
            });
        }

    }
}

