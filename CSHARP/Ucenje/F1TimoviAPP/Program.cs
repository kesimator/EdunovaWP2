using F1TimoviAPP.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Prilagodba za dokumentaciju, èitati https://medium.com/geekculture/customizing-swagger-in-asp-net-core-5-2c98d03cbe52
builder.Services.AddSwaggerGen(sgo =>
{ // sgo je instanca klase SwaggerGenOptions
  // Èitati https://devintxcontent.blob.core.windows.net/showcontent/Speaker%20Presentations%20Fall%202017/Web%20API%20Best%20Practices.pdf
    var o = new Microsoft.OpenApi.Models.OpenApiInfo()
    {
        Title = "Formula 1 Timovi API",
        Version = "v1",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
        {
            Email = "kesinovic957@gmail.com",
            Name = "Marijan Kešinoviæ"
        },
        Description = "Ovo je dokumentacija za Formula 1 Timovi API",
        License = new Microsoft.OpenApi.Models.OpenApiLicense()
        {
            Name = "Edukacijska licenca"
        }
    };
    sgo.SwaggerDoc("v1", o);

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    sgo.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);

});

// Svi se od svuda na sve moguæe naèine mogu spojitina naš API
// Èitati https://code-maze.com/aspnetcore-webapi-best-practices/
builder.Services.AddCors(opcije =>
{
    opcije.AddPolicy("CorsPolicy",
        builder =>
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
    );
});

// Dodavanje baze podataka
builder.Services.AddDbContext<EdunovaContext>(o =>
    o.UseSqlServer(builder.Configuration.GetConnectionString(name: "EdunovaContext"))
);


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
// Moguænost generiranja poziva rute u CMD i Powershell
app.UseSwaggerUI(opcije =>
{
    opcije.ConfigObject.
    AdditionalItems.Add("requestSnippetsEnabled", true);
});
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseStaticFiles();

app.UseCors("CorsPolicy");


app.UseDefaultFiles();
app.UseDeveloperExceptionPage();
app.MapFallbackToFile("index.html");

app.Run();
