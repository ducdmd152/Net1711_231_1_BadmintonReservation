using BadmintonReservationBusiness;
using BadmintonReservationData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddScoped<BookingBusiness>();
builder.Services.AddScoped<CourtBusiness>();
builder.Services.AddScoped<CustomFrameBusiness>();
builder.Services.AddScoped<FrameBusiness>();
builder.Services.AddScoped<DateTypeBusiness>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
