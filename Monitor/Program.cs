using System.Globalization;
using Application.Authentication;
using Application.Authentication.Identity;
using Application.Common.Statics;
using Infra.Data.Context;
using Infra.IOC;
using Logger.Serilog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options => { options.SwaggerGeneratorOptions.DescribeAllParametersInCamelCase = true; });

builder.Services.AddJwtAuthentication();
builder.Services.AddCustomIdentity()
  .AddErrorDescriber<CustomErrorDescriber>();

builder.Services.AddControllers().ConfigureApiBehaviorOptions(opt =>
{
  opt.InvalidModelStateResponseFactory = context =>
  {
    var responseObj = new ResponseDto()
    {
      StatusCode = 400,
      Message = context.ModelState.Keys.SelectMany(k =>
      {
        return context?.ModelState[k]?.Errors.Select(e => e.ErrorMessage).ToList()!;
      }).ToList()
    };
    return new BadRequestObjectResult(responseObj);
  };
});


StaticData.Config(builder.Configuration);

builder.Services.AddDbContext<ApplicationContext>(opt =>
  opt.UseSqlServer(StaticData.AllSqlCon));

CorsServiceCollectionExtensions.AddCors(builder.Services, options =>
{
  options.AddPolicy("EnableCors", corsPolicyBuilder =>
  {
    corsPolicyBuilder.AllowAnyOrigin()
      .AllowAnyMethod()
      .AllowAnyHeader()
      .Build();
    //
  });
});

//AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Host.UseSeriLog_SqlServer();
builder.Host.UseSeriLog_Files();

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


//app.UseMiddleware<UsernameMiddleware>();
CorsMiddlewareExtensions.UseCors(app, "EnableCors");
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI(options =>
{
  options.SwaggerEndpoint("/swagger/v1/swagger.json",
    $"{StaticData.Version}");
});
//}
app.UseJwtAuthentication();
app.UseHttpsRedirection();

app.MapControllers();
app.Use(async (context, next) =>
{
  var cultureInfo = new CultureInfo("fa-IR");
  cultureInfo.NumberFormat.CurrencyDecimalSeparator = ".";
  cultureInfo.NumberFormat.NegativeSign = "-";

  CultureInfo.CurrentCulture = cultureInfo;

  await next();
});
app.Run();
