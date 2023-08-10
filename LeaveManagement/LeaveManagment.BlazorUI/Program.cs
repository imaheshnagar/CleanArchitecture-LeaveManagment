using LeaveManagement.BlazorUI;
using LeaveManagement.BlazorUI.Contracts;
using LeaveManagement.BlazorUI.Services;
using LeaveManagement.BlazorUI.Services.Base;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Reflection;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using LeaveManagement.BlazorUI.Providers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient<IClient, Client>(client =>
client.BaseAddress = new Uri("https://localhost:7078"));

//builder.Services.AddTransient<JwtAuthorizationMessageHandler>();
//builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:7112"))
//    .AddHttpMessageHandler<JwtAuthorizationMessageHandler>(); ;

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();

builder.Services.AddScoped<ILeaveTypeService, LeaveTypeService>();
builder.Services.AddScoped<ILeaveTypeRequestService,LeaveTypeRequestService>();
builder.Services.AddScoped<ILeaveTypeAllocationService,LeaveTypeAllocationService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

await builder.Build().RunAsync();
