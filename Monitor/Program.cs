using System.Globalization;
using Application.Authentication.Identity;
using Application.Common.Statics;
using Application.Seed.Main;
using FrameWork.Utility;
using Infra.Data.Context;
using Infra.IOC;
using Logger.Serilog;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

#region AddService

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterServices(builder.Configuration);


builder.Services.AddSwaggerGen(options =>
{
  options.AddSecurityDefinition("Bearer",
    new OpenApiSecurityScheme
    {
      Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
      In = ParameterLocation.Header,
      Name = "Authorization",
      Type = SecuritySchemeType.ApiKey,
      Scheme = JwtBearerDefaults.AuthenticationScheme
    });
  options.AddSecurityRequirement(new OpenApiSecurityRequirement
  {
    {
      new OpenApiSecurityScheme
      {
        Name = "Bearer",
        In = ParameterLocation.Header,
        Reference = new OpenApiReference { Id = "Bearer", Type = ReferenceType.SecurityScheme }
      },
      new List<string>()
    }
  });
  options.OrderActionsBy((apiDesc) => $"{apiDesc.ActionDescriptor.RouteValues["controller"]}");
 // options.EnableAnnotations();
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => { options.SwaggerGeneratorOptions.DescribeAllParametersInCamelCase = true; });
builder.Services.AddJwtAuthentication();
builder.Services.AddCustomIdentity().AddErrorDescriber<CustomErrorDescriber>();

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
builder.Services.AddDbContext<MainContext>(options => { options.UseSqlServer(StaticData.AllSqlCon); });

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

#endregion AddService

#region Config

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

#endregion Config

#region ConfigureSeed

{
  using var serviceScope = app.Services.CreateScope();
  var services = serviceScope.ServiceProvider;
  try
  {
    var seedMain = services.GetRequiredService<ISeedMain>();

    seedMain.RunAsync().Wait();
    //var q= _SeedMain.RunAsync().Result;   //for return result
  }
  catch (Exception ex)
  {
    var _Logger = services.GetRequiredService<ILogger>();
    // _Logger.Fatal(ex);
  }
}

#endregion ConfigureSeed

app.Run();
