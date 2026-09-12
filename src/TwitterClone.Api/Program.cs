var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers(); 
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();

var app = builder.Build();
 
if (app.Environment.IsDevelopment())
{ 
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
 
app.Run();
