using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Mappers;
using BusinessLayer.Validators;
using DataAccessLayer.Abstract;
using DataAccessLayer.Abstract.Repositories;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;
using DemoProject.Areas.Admin.Services;
using DemoProject.Middleware;
using DemoProject.Models;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddIdentity<AppUser, AppRole>(options => {
    
    options.Password.RequireNonAlphanumeric = false;
    
}

).AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();


builder.Services.ConfigureApplicationCookie(options =>
{
    // Yönlendirme yollarýný buradan belirleyin
    options.LoginPath = "/user/Login";
    options.LogoutPath = "/user/Logout";
    options.AccessDeniedPath = "/user/AccessDenied";
});

builder.Services.AddAuthorization(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();

    options.DefaultPolicy = policy; // Varsayýlan policy olarak ayarlanýyor
});


builder.Services.AddControllersWithViews(options =>
{
    var policy = builder.Services.BuildServiceProvider()
                        .GetRequiredService<IAuthorizationPolicyProvider>()
                        .GetDefaultPolicyAsync().Result;
    options.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddFluentValidationAutoValidation(fv =>
{
    
    fv.DisableDataAnnotationsValidation = true;
}).AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<WriterDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<BlogCreateValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UserSignUpDtoValidator>();





builder.Services.AddSession();
builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x => { x.LoginPath = "/user/login"; }    );

builder.Services.AddScoped<IValidator<BlogDto>, BlogCreateValidator>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));



builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IWriterRepository, WriterRepository>();
builder.Services.AddScoped<IWriterService, WriterService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IBlogRaytingService, BlogRaytingService>();
builder.Services.AddScoped<IBlogRaytingRepository, BlogRaytingRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IMessageService, MessageService>();

builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddDbContext<Context>(
    x =>
    {
        x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
        {
            option.MigrationsAssembly(Assembly.GetAssembly(typeof(Context)).GetName().Name);
        });
    }
    );

builder.Services.AddHttpClient<CategoryApiService>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});

var app = builder.Build();


app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();


app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.UseMiddleware<CurrentUserMiddleware>();

app.MapControllerRoute(name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
