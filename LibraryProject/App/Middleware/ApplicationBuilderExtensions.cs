namespace LibraryProject.App.Middleware;

/// <summary>
/// Uygulama için kullanılan HTTP güvenliği ve istisna işleme ortancalarını yapılandırmak için kullanılan genişletme yöntemleri.
/// </summary>
/// <remarks>
/// Uygulama için HTTP güvenliği ayarlarını yapılandırmak ve özel istisna işleme ve yönlendirme ortancalarını eklemek için kullanılır.
/// </remarks>
internal static class ApplicationBuilderExtensions
{
    internal static IApplicationBuilder UseHttpSecurity(this IApplicationBuilder app)
    {
        app.UseHsts();

        app.UseHttpsRedirection();

        return app;
    }

    internal static IApplicationBuilder UseCustomExceptionAndPageRedirect(this IApplicationBuilder app)
    {
        app.UseStatusCodePagesWithReExecute("/Error/ErrorPage");

        app.UseExceptionHandler(config =>
        {
            config.Run(async httpContext =>
            {
                var exceptionHandlerFeature = httpContext.Features.Get<IExceptionHandlerFeature>();

                Log.Error(exceptionHandlerFeature.Error, exceptionHandlerFeature.Error.Message);

                if (httpContext.Request.Method.Equals(HttpMethods.Get, StringComparison.OrdinalIgnoreCase))
                {
                    httpContext.Response.Redirect($"/Error/ErrorPage404");

                    return;
                }

                httpContext.Response.StatusCode = HttpStatusCode.OK.ToInt();
                httpContext.Response.ContentType = MediaTypeNames.Application.Json;

                JsonResponseModel jsonResponseModel = new() { Url = "/Error/ErrorPage404" };

                await httpContext.Response.WriteAsync(jsonResponseModel.ToJsonString());
            });
        });

        return app;
    }

    internal static IApplicationBuilder UseMiddlewares(this IApplicationBuilder app)
    {
        app.UseMiddleware<AntiXssMiddleware>();

        return app;
    }
}