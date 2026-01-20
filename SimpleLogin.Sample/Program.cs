using SimpleLogin.Ui.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Register the SimpleLogin authentication service (Mock implementation for testing)
builder.Services.AddScoped<ISimpleLoginAuth, MockAuthService>();

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

app.MapRazorPages();

// Allow navigating to root to see something, or just redirect to login if not auth?
// For this sample, let's just add a default "Home" page or redirect.
app.MapGet("/", () => Results.Redirect("/Login"));

app.Run();

// Mock Implementation for the Sample App
public class MockAuthService : ISimpleLoginAuth
{
    public Task<bool> ValidateUserAsync(string username, string password)
    {
        // Simple hardcoded check for demonstration
        if (username == "admin" && password == "password")
        {
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }
}
