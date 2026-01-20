# SimpleLogin.Ui

![NuGet Version](https://img.shields.io/nuget/v/SimpleLogin.Ui)
![Build Status](https://github.com/Ayomide-R/LoginNuggetPackage/actions/workflows/pack.yml/badge.svg)
![License](https://img.shields.io/badge/license-MIT-blue.svg)

**SimpleLogin.Ui** is a plug-and-play Razor Class Library (RCL) that provides a stunning, modern **Glassmorphism** login page for your ASP.NET Core applications. It abstracts away the UI complexity, allowing you to focus purely on your authentication logic.

---

## ✨ Features

- **🚀 Instant Setup**: Add a professional login page in seconds.
- **🎨 Glassmorphism Design**: Modern, translucent UI with beautiful gradients and blur effects.
- **🔌 Auth Agnostic**: You control the authentication logic via a simple interface (`ISimpleLoginAuth`).
- **📱 Fully Responsive**: Looks great on desktop, tablet, and mobile.
- **🎨 Customizable**: Easily themeable using CSS variables.
- **📦 Lightweight**: Minimal dependencies.

## 📦 Installation

Install the package via the .NET CLI:

```bash
dotnet add package SimpleLogin.Ui
```

Or via the NuGet Package Manager:

```powershell
Install-Package SimpleLogin.Ui
```

## 🚀 Quick Start

### 1. Implement authentication logic
Create a class that implements the `ISimpleLoginAuth` interface. This is where you verify credentials against your database or identity provider.

```csharp
using SimpleLogin.Ui.Services;

public class MyAuthService : ISimpleLoginAuth
{
    public Task<bool> ValidateUserAsync(string username, string password)
    {
        // Your real logic here (e.g., database check)
        if (username == "admin" && password == "securepassword")
        {
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }
}
```

### 2. Register services in `Program.cs`
Add Razor Pages support and register your auth service.

```csharp
using SimpleLogin.Ui.Services;

var builder = WebApplication.CreateBuilder(args);

// Add Razor Pages (Required for the UI)
builder.Services.AddRazorPages();

// Register your Auth Service
builder.Services.AddScoped<ISimpleLoginAuth, MyAuthService>();

var app = builder.Build();

app.UseStaticFiles(); // Required for CSS/JS
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages(); // Maps the login page

// Optional: Redirect root to Login
app.MapGet("/", () => Results.Redirect("/Login"));

app.Run();
```

### 3. Run it!
Navigate to `/Login` in your browser. You should see the login page!

## 🎨 Customization

You can customize the look and feel by overriding the CSS variables in your project's global CSS file (e.g., `wwwroot/css/site.css`).

```css
:root {
    /* Change the primary button color */
    --primary-color: #ff5722;
    --primary-hover: #e64a19;

    /* Change the background gradient */
    --bg-gradient: linear-gradient(135deg, #1e3c72 0%, #2a5298 100%);
    
    /* Adjust text color */
    --text-color: #ffffff;
}
```

## 🔧 Requirements

- .NET 8.0 SDK or later.
- ASP.NET Core project (Web App, MVC, or Razor Pages).

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1.  Fork the repository.
2.  Create your feature branch (`git checkout -b feature/AmazingFeature`).
3.  Commit your changes (`git commit -m 'Add some AmazingFeature'`).
4.  Push to the branch (`git push origin feature/AmazingFeature`).
5.  Open a Pull Request.

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details.
