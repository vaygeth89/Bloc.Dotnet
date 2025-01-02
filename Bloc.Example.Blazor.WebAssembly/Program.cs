using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;
using Bloc.Example.Blazor.WebAssembly;
using Bloc.Example.Blazor.WebAssembly.Cubit;
using Bloc.Example.Blazor.WebAssembly.Repositories;
using Bloc.Example.Blazor.WebAssembly.States;
using Bloc.Models;
using Refit;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddFluentUIComponents();

builder.Services.AddSingleton<ITodoRepository>(sp =>
    RestService.For<ITodoRepository>("https://jsonplaceholder.typicode.com/todos"));

builder.Services.AddScoped<BlocBuilder<TodosCubit, TodosState>>(sp =>
    new BlocBuilder<TodosCubit, TodosState>(new TodosCubit(sp.GetRequiredService<ITodoRepository>())));

await builder.Build().RunAsync();