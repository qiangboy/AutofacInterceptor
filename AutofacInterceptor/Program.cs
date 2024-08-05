using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using AutofacInterceptor;

var builder = WebApplication.CreateBuilder(args);

builder.Host
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(cb =>
    {
        cb.RegisterType<LoggingInterceptor>().AsSelf().SingleInstance();
        cb.RegisterType<LoggingAsyncInterceptor>().AsSelf().SingleInstance();
        cb.RegisterType<TestTimingInterceptor>().AsSelf().SingleInstance();
        cb.RegisterType<TestAsyncTimingInterceptor>().AsSelf().SingleInstance();
        cb.RegisterType<UserService>().As<IUserService>().EnableInterfaceInterceptors().InterceptedBy(typeof(LoggingInterceptor)).InterceptedBy(typeof(TestTimingInterceptor));
    });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
