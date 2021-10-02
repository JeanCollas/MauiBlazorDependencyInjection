## Presentation
This tool aims at simplifying the share of dependency injection between Maui and Blazor in a mixed environment

## Nuget
[DependencyInjectionMauiBlazor](https://www.nuget.org/packages/DependencyInjectionMauiBlazor/)
[![NuGet Status](https://img.shields.io/nuget/v/DependencyInjectionMauiBlazor.svg?style=flat)](https://www.nuget.org/packages/DependencyInjectionMauiBlazor/) 

![MAUI Blazor sample](../maui-blazor-sample.gif "MAUI Blazor sharing context sample")

## How to use ?

**In MauiProgram class**
```
using MauiBlazorDependencyInjection;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .RegisterBlazorMauiWebView()
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddBlazorWebView();
        builder.Services.AddSingleton<WeatherForecastService>();

        // Register any other service / ViewModel / Page here
        builder.Services.AddSingleton<TestSingletonService>();

        // Pre-build the app
        var app = builder.Build();
        // Intercept and register the ServiceProvider
        app.Services.UseResolver();
        // Return the app as usual
        return app;
    }
}
```


**a. Use it as your factory from Maui side**

``` csharp
Resolver.ServiceProvider.GetRequiredService<TestSingletonService>();
Console.WriteLine($"Instance number {TestSingletonService.Index}");
```
**b. The services instances will be shared with your Blazor `@inject` services.**
``` razor
@inject TestSingletonService tester
Instance number @(tester.Index).
```
