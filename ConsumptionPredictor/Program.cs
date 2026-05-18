using Application.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<SmaCalculadora>();
builder.Services.AddScoped<RegresionLinealCalculadora>();
builder.Services.AddScoped<VariacionPorcentualCalculadora>();
builder.Services.AddScoped<DeteccionTendenciaCalculadora>();
builder.Services.AddScoped<PredictionOrchestratorService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Prediccion}/{action=Inicio}/{id?}");

app.Run();