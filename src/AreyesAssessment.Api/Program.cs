using AreyesAssessment.API.Services.Implementations;
using AreyesAssessment.API.Services.Interfaces;
using AreyesAssessment.Data.Context;
using AreyesAssessment.Data.Implementations;
using AreyesAssessment.Data.Interfaces;
using AreyesAssessment.Data.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agregar AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Register your repositories
builder.Services.AddScoped<IDonorRepository, DonorRepository>();
builder.Services.AddScoped<IPledgeRepository, PledgeRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IChangelogRepository, ChangelogRepository>();
builder.Services.AddScoped<IPledgePaymentRepository, PledgePaymentRepository>();


// Register your services
builder.Services.AddScoped<IDonorService, DonorService>();
builder.Services.AddScoped<IPledgeService, PledgeService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IChangelogService, ChangelogService>();
builder.Services.AddScoped<IPledgePaymentService, PledgePaymentService>();



// Agregar soporte para controladores y API
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

app.MapControllers(); 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

