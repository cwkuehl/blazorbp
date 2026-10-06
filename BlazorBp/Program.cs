// <copyright file="Program.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

using System.Reflection;
using System.Security.Authentication;
using System.Security.Claims;
using BlazorBp.Components; // für App
using BlazorBp.Core.Base;
using BlazorBp.Core.Components.Pages;
using BlazorBp.Core.Core;
using BlazorBp.Core.Modules;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using NeoSmart.Caching.Sqlite;

var interactive = BlazorBp.Base.Konstanten.Interactive;
var modules = new IFormModule[]
{
  // Formular-Module explizit eintragen (Alternative: Assembly-Scan)
  new BlazorBp.Core.CoreModule(),
  new BlazorBp.Forms.FormsModule(),
  new BlazorBp.Forms.Demo.DemoModule(),
};
var builder = WebApplication.CreateBuilder(args);
foreach (var module in modules)
{
  module.ConfigureBuilder(builder);
}

// Add services to the container.
if (interactive || true)
  // true wegen InvalidOperationException: Cannot provide a value for property 'AuthenticationStateProvider' on type 'Microsoft.AspNetCore.Components.Authorization.CascadingAuthenticationState'. There is no registered service of type 'Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider'.
  builder.Services.AddRazorComponents(options => options.DetailedErrors = builder.Environment.IsDevelopment()).AddInteractiveServerComponents();
else
  builder.Services.AddRazorComponents(options => options.DetailedErrors = builder.Environment.IsDevelopment());

if (!builder.Environment.IsDevelopment())
{
  builder.Services.AddHsts(options => {
    options.Preload = true;
    options.MaxAge = TimeSpan.FromDays(365);
    options.IncludeSubDomains = true;
  });
}
builder.Services.AddAuthentication(o => {
  o.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
  .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o => {
    o.LoginPath = "/";
    o.ExpireTimeSpan = TimeSpan.FromSeconds(BlazorBp.Base.Konstanten.SESSION_TIMEOUT);
    o.Cookie.MaxAge = o.ExpireTimeSpan;
    o.SlidingExpiration = true;
    o.LogoutPath = "/auth/logout";
    o.AccessDeniedPath = "/auth/login";
    o.Cookie.Name = "BlazorBpCookie";
    o.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    o.Cookie.SameSite = SameSiteMode.Strict;
    o.Events = new CookieAuthenticationEvents {
      OnValidatePrincipal = context => {
        if (context.Principal?.Identity is ClaimsIdentity identity && identity.IsAuthenticated) {
          var claims = context.Principal?.Claims;
          if (claims == null)
          {
            context.RejectPrincipal();
            return context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
          }
          else
          {
            var sid = claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid);
            var sidValue = sid?.Value;
            if (sidValue != BlazorBp.Base.Konstanten.CLAIM_SID)
            {
              context.RejectPrincipal();
              return context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
          }
          identity.AddClaim(new Claim("foo", "bar"));
        }
        return Task.CompletedTask;
      }
    };
  });
builder.Services.AddAuthorization(options =>
{
  options.AddPolicy("CanadiansOnly", policy => policy.RequireClaim(ClaimTypes.Country, "Canada"));
});
builder.Services.AddEndpointsApiExplorer(); // Entdeckt MapGet-Endpunkte.
builder.Services.AddSwaggerGen(c =>
{
  // Aufruf mit /swagger/v1/swagger.json
  c.SwaggerDoc("v1", new() { Title = "BlazorBp", Version = "v1" });
  var fn = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
  c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, fn));
});
builder.Services.AddControllers(); // Add MVC with controllers.
var ismem = builder.Configuration["Caching:IsMemoryCache"] ?? "True";
if (ismem == "True")
  builder.Services.AddDistributedMemoryCache();
else
{
  var cachefile = builder.Configuration["Caching:Sqlite:ConnectionString"] ?? "cache.db";
  builder.Services.AddSqliteCache(options => {
    options.CachePath = cachefile;
  });
}
// Alternativ mit SQL Server: Package Microsoft.Extensions.Caching.SqlServer v8.0.8
// builder.Services.AddDistributedSqlServerCache(options =>
// {
//     options.ConnectionString = builder.Configuration.GetConnectionString(
//         "DistCache_ConnectionString");
//     options.SchemaName = "dbo";
//     options.TableName = "TestCache";
// });
builder.Services.AddSession(options =>
{
  options.IdleTimeout = TimeSpan.FromSeconds(BlazorBp.Base.Konstanten.SESSION_TIMEOUT);
  options.Cookie.HttpOnly = true;
  options.Cookie.IsEssential = true;
});
foreach (var module in modules)
{
  module.ConfigureServices(builder.Services);
  BlazorComponentBaseStatic.AddFormulare(module.GetForms());
  DownloadData.RegisterFuncCsv(module.GetFuncCsv());
  DownloadData.RegisterFuncHtml(module.GetFuncHtml());
  StartTask.RegisterFuncStartTask(module.GetFuncStartTask());
}
builder.Services.AddSingleton<IEnumerable<IFormModule>>(modules);
var localhostCertificateSha256 = Convert.FromHexString(
  builder.Configuration["Security:LocalhostCertificateSha256"]
    ?? throw new InvalidOperationException("Security:LocalhostCertificateSha256 must be configured."));
if (localhostCertificateSha256.Length != 32)
  throw new InvalidOperationException("Security:LocalhostCertificateSha256 must contain a SHA-256 fingerprint.");
builder.Services.AddHttpClient("HttpClientWithLocalhostCertificatePinning").ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
  ClientCertificateOptions = ClientCertificateOption.Manual,
  ServerCertificateCustomValidationCallback = (request, certificate, _, policyErrors) =>
    LocalhostCertificateValidator.IsValid(certificate, request.RequestUri?.Host, policyErrors,  localhostCertificateSha256),
  SslProtocols = SslProtocols.Tls13,
});
builder.Services.AddFactoryService();

var app = builder.Build();
app.UseFactoryService();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error", createScopeForErrors: true);
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();
app.UseStatusCodePagesWithReExecute("/StatusCode/{0}");
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();
app.MapControllers();

if (interactive)
  app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
else
  app.MapRazorComponents<App>().AddAdditionalAssemblies(
    typeof(BlazorBp.Core.Modules.IFormModule).Assembly,
    typeof(BlazorBp.Forms.FormsModule).Assembly,
    typeof(BlazorBp.Forms.Demo.DemoModule).Assembly
    );

app.Use(async (context, next) =>
{
  // const string POLICY = "script-src 'nonce-{RANDOM}' 'strict-dynamic'; object-src 'none'; base-uri 'none';"; // Nonce-based Strict Policy
  // const string POLICY = "script-src 'sha256-{HASHED_INLINE_SCRIPT}' 'strict-dynamic'; object-src 'none'; base-uri 'none'; report-to /_/csp-reports"; // Hash-based Strict Policy
  // const string POLICY = "default-src 'self'; frame-ancestors 'self'; form-action 'self';"; // The most basic policy
  // const string POLICY = "default-src 'none'; script-src 'self'; connect-src 'self'; img-src 'self'; style-src 'self'; frame-ancestors 'self'; form-action 'self';"; // To tighten further
  if (0 == 0)
  {
    const string POLICY = "default-src 'self'; script-src 'self' 'unsafe-hashes' 'sha256-CUqQNXXMRfh20wSHsbWzap8G4U55uWVlFrnrwSqnd10=' 'sha256-UlYTlM874RdFSS67t+aMjiuwzawEsxJkZV0OrhmqESo=' 'sha256-E3Jin0zoOcW167+rqzMm4duzknSmqrDJ7LJs+P1wAdI='; img-src 'self' data:; form-action 'self'; frame-ancestors 'none';"; // To prevent all framing of your content
    // const string POLICY = "default-src 'self'; script-src 'self' 'unsafe-hashes' 'sha256-fa0BfrkfoHWYWTFJg9cIEoVa6Mn3OUorfpaz+NXuHCI=' 'sha256-RFWPLDbv2BY+rCkDzsE+0fr8ylGr2R2faWMhq4lfEQc='; connect-src 'self'; img-src 'self' data:; style-src 'self'; form-action 'self'; frame-ancestors 'none';"; // To prevent all framing of your content
    // const string POLICY = "default-src 'self'; script-src 'self' 'unsafe-inline' 'unsafe-eval'; connect-src 'self'; img-src 'self'; style-src 'self'; form-action 'self'; frame-ancestors 'none';";
    // script-src 'unsafe-inline' 'unsafe-eval' for ajax
    // img-src 'self' data: for bootstrap images
    // script-src 'self' 'unsafe-hashes' 'sha256-fa0BfrkfoHWYWTFJg9cIEoVa6Mn3OUorfpaz+NXuHCI=' for hallo();
    // echo -e -n "submitc(\x24(this));" | openssl sha256 -binary | openssl base64
    // echo -e -n "return confimp();" | openssl sha256 -binary | openssl base64
    // Bringt andere Hashes: openssl dgst -sha3-256 -binary file.js | openssl base64 -A
    // 'sha256-ePniVEkSivX/c7XWBGafqh8tSpiRrKiqYeqbG7N1TOE=' document.forms[0].submit()
    // 'sha256-gn6SvwkOt5ByZ8z2lZtOcIQopPyjkBUNz7EbU50dwb8=' submitControl($(this).attr('id'),'form1');
    // 'sha256-JINyXuiE90RdGlUFK8DM5WNxzknp65BaeVE4VuderpY=' submitControl($(this).attr('id'),'formt');
    // 'sha256-CUqQNXXMRfh20wSHsbWzap8G4U55uWVlFrnrwSqnd10=' submitc($(this));
    // 'sha256-UlYTlM874RdFSS67t+aMjiuwzawEsxJkZV0OrhmqESo=' statec($(this));
    // 'sha256-E3Jin0zoOcW167+rqzMm4duzknSmqrDJ7LJs+P1wAdI=' return confimp();
    // 'sha256-aV5tqRL+qWGkuS9LFLVv5WMI1ldktz5yzpz7ftN2I5k=' alert('Hallo'); <script>alert('Hallo');</script>
    context.Response.Headers.Append("Content-Security-Policy", $"{POLICY}");
    // Verhindern von MIME-Typ-Sniffing.
    context.Response.Headers.Append("X-Content-Type-Options", "nosniff");
    // Verhindern von Clickjacking.
    context.Response.Headers.Append("X-Frame-Options", "DENY");
    // Aktivieren von XSS-Schutz.
    context.Response.Headers.Append("X-XSS-Protection", "1; mode=block");
  }
  await next();
});
app.UseCookiePolicy(new CookiePolicyOptions
{
  Secure = CookieSecurePolicy.Always,
  HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always
});
app.UseSession();

foreach (var module in modules)
{
  // MapGet-Endpunkte für jedes Modul registrieren, z.B. /hello.
  module.ConfigureApp(app);
}

// app.UseStaticFiles(new StaticFileOptions()
// {
//   // Add the other folder, using the Content Root as the base
//   FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "wwwroot/help"))
// });

app.UseSwagger();
app.UseSwaggerUI(c =>
{
  // Aufruf mit /swagger und /swagger/v1/swagger.json
  c.SwaggerEndpoint("v1/swagger.json", "BlazorBp API V1");
  // Bei app.UseSwaggerUI funktioniert automatische Abmeldung mit /auth/logout nicht, wenn RoutePrefix nicht gesetzt ist.
  c.RoutePrefix = "swagger";
});

app.Run();

/*

dotnet new sln -o blazorbp
dotnet new blazor --auth Individual -o BlazorBp
dotnet new classlib -o BlazorBp.Services
dotnet new xunit -o BlazorBp.Tests
dotnet sln blazorbp.sln add ./BlazorBp/BlazorBp.csproj ./BlazorBp.Services/BlazorBp.Services.csproj ./BlazorBp.Tests/BlazorBp.Tests.csproj
dotnet add ./BlazorBp/BlazorBp.csproj reference ./BlazorBp.Services/BlazorBp.Services.csproj
dotnet add ./BlazorBp.Tests/BlazorBp.Tests.csproj reference ./BlazorBp.Services/BlazorBp.Services.csproj
dotnet ef database update
update AspNetUsers set EmailConfirmed=1;
Projekt BlazorBp in BlazorBp.Identity umbenannt.
dotnet new blazor -o BlazorBp
dotnet add ./BlazorBp/BlazorBp.csproj reference ./BlazorBp.Services/BlazorBp.Services.csproj
dotnet sln blazorbp.sln add ./BlazorBp/BlazorBp.csproj
dotnet add package NeoSmart.Caching.Sqlite.AspNetCore

Services.dll hinzufügen:
dotnet sln add ../csbp/CSBP.Services/CSBP.Services.csproj
dotnet add ./BlazorBp/BlazorBp.csproj reference ../csbp/CSBP.Services/CSBP.Services.csproj
dotnet add ./BlazorBp.Services/BlazorBp.Services.csproj reference ../csbp/CSBP.Services/CSBP.Services.csproj

Authorisierung mit Cookies: https://www.youtube.com/watch?v=B3zvX_CWKVc

Swagger für Endpoints:
dotnet add package Swashbuckle.AspNetCore

Redesign BlazorBp mit Razor Class Libraries:
dotnet new razorclasslib -o BlazorBp.Core
dotnet sln blazorbp.sln add ./BlazorBp.Core/BlazorBp.Core.csproj
dotnet add ./BlazorBp/BlazorBp.csproj reference ./BlazorBp.Core/BlazorBp.Core.csproj
dotnet new razorclasslib -o BlazorBp.Forms.Demo
dotnet sln blazorbp.sln add ./BlazorBp.Forms.Demo/BlazorBp.Forms.Demo.csproj
dotnet add ./BlazorBp/BlazorBp.csproj reference ./BlazorBp.Forms.Demo/BlazorBp.Forms.Demo.csproj
BlazorBp.Services entfernt, da die Funktionen in BlazorBp.Forms.Demo eingebaut sind.

Neues Projekt BlazorSpa.Base für TableReadModel erstellt.
dotnet new classlib -o BlazorSpa.Base
dotnet sln blazorbp.sln add ./BlazorSpa.Base/BlazorSpa.Base.csproj
dotnet add ./BlazorBp/BlazorBp.csproj reference ./BlazorSpa.Base/BlazorSpa.Base.csproj
dotnet add ./BlazorBp.Forms.Demo/BlazorBp.Forms.Demo.csproj reference ./BlazorSpa.Base/BlazorSpa.Base.csproj

Neues Projekt BlazorBp.Forms als Razor Class Library für alle Formulare außer Demo:
dotnet new razorclasslib -o BlazorBp.Forms
dotnet sln blazorbp.sln add ./BlazorBp.Forms/BlazorBp.Forms.csproj
dotnet add ./BlazorBp/BlazorBp.csproj reference ./BlazorBp.Forms/BlazorBp.Forms.csproj

*/
