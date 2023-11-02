using ProyectoDesarrollo.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Add(new ServiceDescriptor(typeof(IDoctor), new DoctorRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(ISecretaria), new SecretariaRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IAdministrador), new AdministradorRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IPaciente), new PacienteRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IEspecialidad), new EspecialidadRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(ICita), new CitaRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IEstados), new EstadosRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IHorario), new HorarioRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IGenero), new GeneroRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IUsuarios), new UsuariosRepository()));
builder.Services.AddControllersWithViews();

// Configure the session
builder.Services.AddDistributedMemoryCache(); // Optional: Use a distributed cache for session storage
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "YourSessionCookieName"; // Specify a unique name for your session cookie
    options.IdleTimeout = TimeSpan.FromMinutes(20); // Set the session timeout period
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession(); // Enable session middleware

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Proyecto}/{action=Inicio}/{id?}");

app.Run();
