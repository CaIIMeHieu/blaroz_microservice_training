using IrisTraining_Auth.DependencyInjections.Extensions;
using IrisTraining_Auth.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDBContextSQLServer(builder.Configuration);
builder.Services.AddServiceInjection();
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<AuthService>();

app.Run();
