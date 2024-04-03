using ApiSignalrBG.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddCors(options => {
    options.AddPolicy("todos", builder => {
        builder.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed((Host) => true).AllowCredentials();
        });
    });


var app = builder.Build();
app.UseCors("todos");
app.MapHub<Proceso>("/proceso");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

