using licencjatApi.MulticriteriaSelectionMethods;
using licencjatApi.Data;
using licencjatApi.Repositories;
using licencjatApi.Repository;
using licencjatApi.Services;
using licencjatApi.Services.Ranking;
using Microsoft.EntityFrameworkCore;
using licencjatApi.Services.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();//.AddJsonOptions(x => 
//    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve
//);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations(); 
});

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IMountainHostelRepository, MountainHostelRepository>();
builder.Services.AddScoped<IMountainHostelService, MountainHostelService>();
builder.Services.AddScoped<ICriterionRepository, CriterionRepository>();
builder.Services.AddScoped<ICriterionService, CriterionService>();
builder.Services.AddScoped<IHostelCriterionValueRepository, HostelCriterionValueRepository>();
builder.Services.AddScoped<IHostelCriterionValueService, HostelCriterionValueService>();
builder.Services.AddScoped<IRankingService, RankingService>();
builder.Services.AddScoped<IProgramParametersRepository, ProgramParametersRepository>();
builder.Services.AddScoped<IProgramParametersService, ProgramParametersService>();

builder.Services.AddScoped<IMountainHostelValidator, MountainHostelValidator>();
builder.Services.AddScoped<ICriterionValidator, CriterionValidator>();
builder.Services.AddScoped<IHostelCriterionValueValidator, HostelCriterionValueValidator>();

builder.Services.AddScoped<IMulticriteriaSelectionMethod, SAWMulticriteriaSelectionMethod>();
builder.Services.AddScoped<IMulticriteriaSelectionMethod, TopsisMulticriteriaSelectionMethod>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(c =>
    {
        c.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi2_0;
    });
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
