using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<MyContext>(x => x.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register services
builder.Services.AddTransient<Warehouse>();
builder.Services.AddTransient<Contact>();   
builder.Services.AddTransient<Client>();   
builder.Services.AddTransient<Supplier>();
builder.Services.AddTransient<WarehouseServices>(); 
builder.Services.AddTransient<LocationServices>();
builder.Services.AddTransient<TransfersServices>();
builder.Services.AddTransient<ItemGroupService>();
builder.Services.AddTransient<ClientServices>();
builder.Services.AddTransient<SuppliersServices>();
builder.Services.AddTransient<ISuppliers, SuppliersServices>();
builder.Services.AddTransient<Inventory>();
builder.Services.AddTransient<InventoriesLocations>();
builder.Services.AddTransient<InventoryServices>();
builder.Services.AddTransient<Shipment>();
builder.Services.AddTransient<ShipmentsItem>();
builder.Services.AddTransient<ShipmentsServices>();
builder.Services.AddTransient<ItemLineServices>();
builder.Services.AddTransient<IOrdersInterface,OrdersServices>();
builder.Services.AddTransient<ItemTypeServices>();
builder.Services.AddTransient<ItemServices>();
builder.Services.AddTransient<IOrdersInterface,OrdersServices>();
builder.Services.AddTransient<Orders>();
builder.Services.AddTransient<ItemLine>();


var app = builder.Build();
app.UseMiddleware<Authentication>();  // Register custom API key middleware
app.MapControllers();
app.Urls.Add("http://localhost:5000");
app.MapGet("/", () => "Hello World!");
app.Run();
