var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

var app = builder.Build();

// Configure pipeline
app.UseDefaultFiles();   
app.UseStaticFiles();    

app.UseHttpsRedirection();
app.MapControllers();

app.Run();