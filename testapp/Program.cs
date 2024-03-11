using testapp;

var builder = WebApplication.CreateBuilder(args);
IServiceCollectionExtensions.AddIdentityConfiguration(builder.Services, builder.Configuration, env: builder.Environment);
IServiceCollectionExtensions.AddRepositories(builder.Services);
IServiceCollectionExtensions.AddServices(builder.Services);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}
if (!app.Environment.IsProduction())
{
    app.UseExceptionHandler("/Home/ProductError");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
}
//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
