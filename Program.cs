using GloboClimaBlazor.Components;
//using GloboClimaAPI.Services;
using Amazon.DynamoDBv2;
using Amazon.Extensions.NETCore.Setup;
using Amazon.Runtime;
using GloboClimaBlazor.Models;
using Blazored.LocalStorage;
using GloboClimaBlazor.Authentication;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
//builder.Services.AddScoped<DynamoDBService>();
builder.Services.AddScoped<PaisesModel>();
builder.Services.AddScoped<CityModel>();
var credentials = new BasicAWSCredentials("chaveamazon", "amazon");
builder.Services.AddAWSService<IAmazonDynamoDB>();
builder.Services.AddAWSService<IAmazonDynamoDB>(new AWSOptions
{
    Credentials = credentials,
    Region = Amazon.RegionEndpoint.USEast2
});
builder.Services.AddHttpClient();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<JwtAuthorizationHandler>();

builder.Services.AddHttpClient("API", client =>
{
    client.BaseAddress = new Uri("http://18.220.208.30:8080"); 
});
builder.Services.AddHttpClient("API").AddHttpMessageHandler<JwtAuthorizationHandler>();


builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseAuthorization();
app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles();
app.UseAntiforgery();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
