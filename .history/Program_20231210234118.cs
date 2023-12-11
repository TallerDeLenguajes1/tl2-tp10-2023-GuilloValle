using ConjuntoDeInterfacesRepo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();  //se agrego para login (ver que hace)

builder.Services.AddSession(options =>   //se agrego para login (ver que hace)
{
    options.IdleTimeout = TimeSpan.FromSeconds(300);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var CadenaDeConexion = builder.Configuration.GetConnectionString("SqliteConexion")!.ToString(); //el signo de exclamacion es para decir que no es null
builder.Services.AddSingleton<string>(CadenaDeConexion);

builder.Services.AddScoped<ITareaRepository, TareaRepository>();     //Inyeccion de dependencias
builder.Services.AddScoped<ITableroRepository, TableroRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();   //se agrego para login (ver que hace)
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
