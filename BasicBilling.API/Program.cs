using AutoMapper;
using BasicBilling.API;
using Core.Interfaces;
using Core.Service;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.context;
using Persistence.Repositories;
using Persistence.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IBillingRepository, BillingRepository>();
builder.Services.AddTransient<IClientRepository, ClientRepository>();
builder.Services.AddTransient<IBillingCategoryRepository, BillingCategoryRepository>();
builder.Services.AddTransient<IBillingStatusRepository, BillingStatusRepository>();

builder.Services.AddTransient<IBillingService, BillingService>();
builder.Services.AddTransient<IClientService, ClientService>();

builder.Services.AddTransient<BillingStatusSeeder>();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddDbContext<BasicBillingContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("BasicBilling"))
);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BasicBillingContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(builder => builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader());

app.Run();
