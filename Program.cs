using cros_dots_hw_blazor.Components;

var builder = WebApplication.CreateBuilder(args);

// Добавляем поддержку интерактивных серверных компонентов
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

app.UsePathBase("/dotnet_blazor_app");

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();       // ← должен идти ПОСЛЕ UsePathBase, но ДО UseRouting
app.UseRouting();           // ← явно добавляем (иногда требуется)
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();