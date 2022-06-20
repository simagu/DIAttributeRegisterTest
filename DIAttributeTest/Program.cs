using DIAttributeTest.Services.Auth;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc();
builder.Services.AddHttpContextAccessor();

builder.Services.AddAttributeModelRegister();
// builder.Services.AddSingleton<IAuthService, AuthService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    //加上MapDefaultControllerRoute()
    endpoints.MapDefaultControllerRoute();
    //支援透過Attribute指定路由
    endpoints.MapControllers();
});

app.Run();
