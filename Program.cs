using Pokemon.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<PokemonContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddSqlServer<PokemonDbContext>(connectionString, sql => sql.EnableRetryOnFailure());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // This allow us to use wwwroot

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Pokemon}/{action=Pokemons}/{id?}");

app.Run();
