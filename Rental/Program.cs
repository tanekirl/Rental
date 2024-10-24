using Rental.Data.interfaces; // ���� using
using Rental.Data.mocks;
using Rental.Data; // ������ ����, �� ����������� AppDBContent
using Microsoft.EntityFrameworkCore; // ��� ���������� �� ���� �����
using Rental.Data.Repository;
using Rental.Data.Models; // ������ ���� ��� �������

var builder = WebApplication.CreateBuilder(args);

// ��������� ������������ � ����� dbsettings.json
IConfigurationRoot _confString = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("dbsettings.json")
    .Build();

// ��������� �����
builder.Services.AddMvc(options => options.EnableEndpointRouting = false); // ��������� �������� MVC ��� ������������� �� ����� �����

// ϳ��������� �� ���� �����
builder.Services.AddDbContext<AppDBContent>(options =>
    options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));

// ������ ���� ������
builder.Services.AddTransient<IAllCars, CarRepository>();
builder.Services.AddTransient<ICarsCategory, CategoryRepository>();
builder.Services.AddTransient<IAllOrders, OrdersRepository>();

// ��������� �������� ��� IHttpContextAccessor, ���� � �������
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp => RentalCart.GetCart(sp));

builder.Services.AddMemoryCache(); // ��� ������������ ���������
builder.Services.AddSession(); // ��������� �������� ����

var app = builder.Build();

// ������������ ������� ������� ������
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStatusCodePages();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseSession(); // ������� ������������ ���� ����� ������������� �������������

app.UseAuthorization();

app.MapControllerRoute(
    name: "carDetails",
    pattern: "CarDetails/{id:int}",
    defaults: new { controller = "CarDetails", action = "Index" });


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "categoryFilter",
    pattern: "{controller=Cars}/{action}/{category?}");

// ����������� ���� �����
using (var scope = app.Services.CreateScope())
{
    AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
    DBObjects.Initial(content);
}

app.Run();