using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BlazorBp.Identity.Components;
using BlazorBp.Identity.Components.Account;
using BlazorBp.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Use(async (context, next) =>
{
  // const string POLICY = "script-src 'nonce-{RANDOM}' 'strict-dynamic'; object-src 'none'; base-uri 'none';"; // Nonce-based Strict Policy
  // const string POLICY = "script-src 'sha256-{HASHED_INLINE_SCRIPT}' 'strict-dynamic'; object-src 'none'; base-uri 'none'; report-to /_/csp-reports"; // Hash-based Strict Policy
  // const string POLICY = "default-src 'self'; frame-ancestors 'self'; form-action 'self';"; // The most basic policy
  // const string POLICY = "default-src 'none'; script-src 'self'; connect-src 'self'; img-src 'self'; style-src 'self'; frame-ancestors 'self'; form-action 'self';"; // To tighten further
  if (0 == 0)
  {
    const string POLICY = "default-src 'self'; script-src 'self' 'unsafe-hashes' 'sha256-gn6SvwkOt5ByZ8z2lZtOcIQopPyjkBUNz7EbU50dwb8=' 'sha256-JINyXuiE90RdGlUFK8DM5WNxzknp65BaeVE4VuderpY='; img-src 'self' data:; form-action 'self'; frame-ancestors 'none';"; // To prevent all framing of your content
    // const string POLICY = "default-src 'self'; script-src 'self' 'unsafe-hashes' 'sha256-fa0BfrkfoHWYWTFJg9cIEoVa6Mn3OUorfpaz+NXuHCI=' 'sha256-RFWPLDbv2BY+rCkDzsE+0fr8ylGr2R2faWMhq4lfEQc='; connect-src 'self'; img-src 'self' data:; style-src 'self'; form-action 'self'; frame-ancestors 'none';"; // To prevent all framing of your content
    // const string POLICY = "default-src 'self'; script-src 'self' 'unsafe-inline' 'unsafe-eval'; connect-src 'self'; img-src 'self'; style-src 'self'; form-action 'self'; frame-ancestors 'none';";
    // script-src 'unsafe-inline' 'unsafe-eval' for ajax
    // img-src 'self' data: for bootstrap images
    // script-src 'self' 'unsafe-hashes' 'sha256-fa0BfrkfoHWYWTFJg9cIEoVa6Mn3OUorfpaz+NXuHCI=' for hallo();
    // echo -e -n "submitControl(\x24(this).attr('id'),'form1');" | openssl sha256 -binary | openssl base64
    // 'sha256-ePniVEkSivX/c7XWBGafqh8tSpiRrKiqYeqbG7N1TOE=' document.forms[0].submit()
    // 'sha256-gn6SvwkOt5ByZ8z2lZtOcIQopPyjkBUNz7EbU50dwb8=' submitControl($(this).attr('id'),'form1');
    // 'sha256-JINyXuiE90RdGlUFK8DM5WNxzknp65BaeVE4VuderpY=' submitControl($(this).attr('id'),'formt');
    context.Response.Headers.Append("Content-Security-Policy", $"{POLICY}");
  }
  await next();
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

*/
