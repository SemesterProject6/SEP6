using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SEP6;
using SEP6.Data.Actors;
using SEP6.Data.Movies;
using MudBlazor.Services;
using Microsoft.AspNetCore.Components.Authorization;
using SEP6.Models;
using SEP6.Data.Users;
using SEP6.Data.FavoriteMovie;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<MovieService>();
builder.Services.AddSingleton<IActorService, ActorService>();
builder.Services.AddSingleton<IMovieService, MovieService>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IFavoriteMovieService, FavoriteMovieService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore(options =>
{
    options.AddPolicy("SecurityLevel1", a =>
        a.RequireAuthenticatedUser().RequireClaim("Level", "1"));
});
await builder.Build().RunAsync();
