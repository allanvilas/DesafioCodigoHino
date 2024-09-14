using System.Data;
using DotNetEnv;
using Npgsql;

Env.Load();

var builder = WebApplication.CreateBuilder(args);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IMovimentacaoRepository, MovimentacaoRepository>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddTransient<IDbConnection>(sp => new NpgsqlConnection(GetConnectionString()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
app.Run();

static string GetConnectionString() {
        string host = Environment.GetEnvironmentVariable("DB_HOST");
        string database = Environment.GetEnvironmentVariable("DB_NAME");
        string username = Environment.GetEnvironmentVariable("DB_USER");
        string password = Environment.GetEnvironmentVariable("DB_PASSWORD");

        return $"Server={host},5432;Database={database};User ID={username};Password={password};";
    }