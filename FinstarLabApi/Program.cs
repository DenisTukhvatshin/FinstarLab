using FinstarLab.Application.ServiceCollections;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCommands();
builder.Services.AddQueries();
builder.Services.AddDbPostgreSql(builder.Configuration);
builder.Services.AddCors((s) =>
{
    s.AddPolicy("corsPolicy", p =>
    {
        p.AllowAnyOrigin();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("corsPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
