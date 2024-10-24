using Rental.Data.interfaces; // Ваші using
using Rental.Data.mocks;
using Rental.Data; // Простір імен, де знаходиться AppDBContent
using Microsoft.EntityFrameworkCore; // Для підключення до бази даних
using Rental.Data.Repository;
using Rental.Data.Models; // Простір імен для моделей

var builder = WebApplication.CreateBuilder(args);

// Додавання конфігурації з файлу dbsettings.json
IConfigurationRoot _confString = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("dbsettings.json")
    .Build();

// Додавання служб
builder.Services.AddMvc(options => options.EnableEndpointRouting = false); // Додавання підтримки MVC без маршрутизації на кінцеві точки

// Підключення до бази даних
builder.Services.AddDbContext<AppDBContent>(options =>
    options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));

// Додаємо ваші сервіси
builder.Services.AddTransient<IAllCars, CarRepository>();
builder.Services.AddTransient<ICarsCategory, CategoryRepository>();
builder.Services.AddTransient<IAllOrders, OrdersRepository>();

// Додавання підтримки для IHttpContextAccessor, сесій і корзини
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp => RentalCart.GetCart(sp));

builder.Services.AddMemoryCache(); // Для використання кешування
builder.Services.AddSession(); // Додавання підтримки сесій

var app = builder.Build();

// Налаштування конвеєра обробки запитів
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

app.UseSession(); // Додайте використання сесій перед використанням маршрутизації

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

// Ініціалізація бази даних
using (var scope = app.Services.CreateScope())
{
    AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
    DBObjects.Initial(content);
}

app.Run();