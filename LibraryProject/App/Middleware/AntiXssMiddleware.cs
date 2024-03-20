namespace LibraryProject.App.Middleware;

public sealed class AntiXssMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        if (!string.IsNullOrWhiteSpace(context.Request.Path.Value))
        {
            var url = context.Request.Path.Value;

            if (context.Request.Path == "/Home/Create")
            {
                await next(context);
                return;
            }
            
            if (IsDangerousString(url, out _))
            {
                context.Response.Redirect($"/Error/ErrorPage404/");
                return;
            }
        }

        if (!string.IsNullOrWhiteSpace(context.Request.QueryString.Value))
        {
            var queryString = WebUtility.UrlDecode(context.Request.QueryString.Value);

            if (IsDangerousString(queryString, out _))
            {
                context.Response.Redirect($"/Error/ErrorPage404/");
                return;
            }
        }

        var originalBody = context.Request.Body;
        try
        {
            var content = await ReadRequestBody(context.Request);
            if (IsDangerousString(content, out _))
            {
                await RespondWithAnError(context).ConfigureAwait(false);
                return;
            }

            await next(context).ConfigureAwait(false);
        }
        finally
        {
            context.Request.Body = originalBody;
        }
    }

    private static async Task<string> ReadRequestBody(HttpRequest request)
    {
        HttpRequestRewindExtensions.EnableBuffering(request);
        var body = request.Body;

        var buffer = new byte[Convert.ToInt32(request.ContentLength)];
        _ = await request.Body.ReadAsync(buffer.AsMemory(0, buffer.Length));
        var bodyAsText = Encoding.UTF8.GetString(buffer);

        body.Seek(0, SeekOrigin.Begin);
        request.Body = body;

        return WebUtility.UrlDecode(bodyAsText);
    }

    private static async Task RespondWithAnError(HttpContext context)
    {
        JsonResponseModel responseModel = new() { Title = MessageTitle.InvalidRequest };

        responseModel.Errors.Add(ExceptionMessage.CheckInformationTryAgain);

        context.Response.Clear();
        context.Response.ContentType = "application/json; charset=utf-8";
        context.Response.StatusCode = HttpStatusCode.OK.ToInt();

        await context.Response.WriteAsync(responseModel.ToJsonString());
    }

    public bool IsDangerousString(string s, out int matchIndex)
    {
        char[] StartingChars = { '<', '&' };

        matchIndex = 0;

        for (var i = 0;;)
        {
            var n = s.IndexOfAny(StartingChars, i);

            if (n < 0) return false;

            if (n == s.Length - 1) return false;

            matchIndex = n;

            switch (s[n])
            {
                case '<':
                    if (IsAtoZ(s[n + 1]) || s[n + 1] == '!' || s[n + 1] == '/' || s[n + 1] == '?') return true;
                    break;
                case '&':
                    if (s[n + 1] == '#') return true;
                    break;
            }

            i = n + 1;
        }
    }

    private bool IsAtoZ(char c)
    {
        return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
    }
}