using System.Text;
using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using DA;
using DA.Authentication;
using DA.Listado;
using DA.ListaVisualizacion;
using DA.Repositorios;
using DA.Usuarios;
using Flujo;
using Flujo.Authentication;
using Flujo.ListadoPeliculas;
using Flujo.Usuarios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Reglas;
using Reglas.Peliculas;
using Reglas.Series;
using Servicios.Peliculas;
using Servicios.Series;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

builder.Services.AddScoped<ISeriesFlujo, SeriesFlujo>();
builder.Services.AddScoped<ISeriesReglas, SeriesReglas>();
builder.Services.AddScoped<ISeriesServicio, SeriesServicio>();
builder.Services.AddScoped<IGenerosSerieServicio, GenerosSerieServicio>();
builder.Services.AddScoped<IPeliculasFlujo, PeliculasFlujo>();
builder.Services.AddScoped<IPeliculasReglas, PeliculasReglas>();
builder.Services.AddScoped<IPeliculasServicio, PeliculasServicio>();
builder.Services.AddScoped<IGeneroServicio, GeneroServicio>();
builder.Services.AddScoped<IConfiguracion, Configuracion>();
builder.Services.AddScoped<IGenerosFlujo, GenerosFlujo>();
builder.Services.AddScoped<ISerieGeneroServicio, SeriesGeneroServicio>();
builder.Services.AddScoped<IUsuariosFlujo, UsuariosFlujo>();
builder.Services.AddScoped<IUsuariosDA, UsuariosDA>();
builder.Services.AddScoped<IRepositorioDapper, RepositorioDapper>();
builder.Services.AddScoped<IAuthenticationDA, AuthenticationDA>();
builder.Services.AddScoped<IAuthenticationFlujo, AuthenticationFlujo>();
builder.Services.AddScoped<IPeliculasListadoDA, PeliculasListadoDA>();
builder.Services.AddScoped<IPeliculasListadoFlujo, PeliculasListadoFlujo>();
builder.Services.AddScoped<IListaVisualizacionFlujo, ListaVisualizacionFlujo>();
builder.Services.AddScoped<IListaVisualizacionDA, ListaVisualizacionDA>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Token:Issuer"],
            ValidAudience = builder.Configuration["Token:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:Key"])),
            
        };

        options.Events = new JwtBearerEvents
        {
            OnTokenValidated = async context =>
            {
                var claimsIdentity = context.Principal.Identity as System.Security.Claims.ClaimsIdentity;
                var userName = claimsIdentity?.Name;

                var userRole = await context.HttpContext.RequestServices
                    .GetRequiredService<IAuthenticationFlujo>()
                    .GetRole(userName);

                if (!string.IsNullOrEmpty(userRole))
                {
                    claimsIdentity.AddClaim(new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Role, userRole));
                }
            }
        };
    });


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins(
                "http://localhost:65385",
                "https://localhost:7247"
            )
            .AllowAnyHeader()
            .AllowAnyMethod()
            
            .AllowCredentials();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
