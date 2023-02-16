using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// BL Injected
//builder.Services.AddSingleton<BL.Configuration>();
builder.Services.AddScoped<BL.Interfaces.IServiceFactory, BL.Services.ServiceFactory>();
// Dal Context injection.
builder.Services.AddDbContext<DAL.Context>( config =>
{
    config.UseSqlServer(builder.Configuration.GetConnectionString("CoreContext"));
});
const string All = "*";
builder.Services.AddCors( options =>
{
    options.AddPolicy(All, pol => { pol.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();  });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(All);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
