using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    options.ModelValidatorProviders.Clear();
}).AddRazorRuntimeCompilation();

builder.Services.AddScopedServices();
builder.Services.AddInfrastructureServices();
builder.AddSeriLog();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidation(options =>
{
    options.RegisterValidatorsFromAssembly(typeof(Program).Assembly);
    options.AutomaticValidationEnabled = false;
    options.DisableDataAnnotationsValidation = true;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseRouting();
app.UseHttpSecurity();
app.UseMiddlewares();
app.UseCustomExceptionAndPageRedirect();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();