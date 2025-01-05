using Examarbeta.Business.SchedueldJobs;
using Examarbeta.Interface;
using Examarbeta.Services;
using Umbraco.Cms.Core.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.CreateUmbracoBuilder()
    .AddBackOffice()
.AddWebsite()
    .AddDeliveryApi()
    .AddComposers()
    .Build();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IEventsJob, EventsJob>();
//builder.Services.AddScoped<IContentService, ContentService>();
//builder.Services.AddScoped<IContentTypeService, ContentTypeService>();


WebApplication app = builder.Build();

await app.BootUmbracoAsync();


app.UseUmbraco()
    .WithMiddleware(u =>
    {
        u.UseBackOffice();
        u.UseWebsite();
    })
    .WithEndpoints(u =>
    {
        u.UseBackOfficeEndpoints();
        u.UseWebsiteEndpoints();
    });

await app.RunAsync();
