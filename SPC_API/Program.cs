using Microsoft.EntityFrameworkCore;
using SPC_API.Data;
using SPC_API.Model;


var builder = WebApplication.CreateBuilder(args);
var connection = "Data Source=DESKTOP-9N2N8IQ;Initial Catalog=SPCDB_ICBT;Integrated Security=True;Trust Server Certificate=True";
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(connection));

// Add services to the container.
builder.Services.AddScoped<DrugRepo>();
builder.Services.AddScoped<TenderRepo>();
builder.Services.AddScoped<StaffRepo>();
builder.Services.AddScoped<SupplierRepo>();
builder.Services.AddScoped<PharmacyRepo>();
builder.Services.AddScoped<SpcTenderAdRepo>();
builder.Services.AddScoped<OrderRepo>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Specify the URL for the Kestrel server to bind to
app.Run();