//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

////builder.Services.AddControllers();
//// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
////builder.Services.AddEndpointsApiExplorer();
////builder.Services.AddSwaggerGen();

//// Add YARP reverse proxy
//builder.Services.AddReverseProxy()
//    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

//var app = builder.Build();

//// Configure the HTTP request pipeline.
////if (app.Environment.IsDevelopment())
////{
////    app.UseSwagger();
////    app.UseSwaggerUI();
////}

//// Enable request forwarding
//app.MapReverseProxy();

////app.UseHttpsRedirection();

////app.UseAuthorization();

////app.MapControllers();

//app.Run();




var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

app.UseRouting();

app.MapReverseProxy();

app.Run();
