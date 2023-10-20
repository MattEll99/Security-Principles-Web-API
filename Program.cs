using Microsoft.EntityFrameworkCore;
using Security_Principles_Web_API.Data;
using Security_Principles_Web_API.Interfaces;
using Security_Principles_Web_API.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ISecurityPrincipleRepository, SecurityPrincipleRepository>();
builder.Services.AddScoped<IGroupMemberRepository, GroupMemberRepository>();
builder.Services.AddScoped<IvGroupMemberRepository, vGroupMembersRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Both Connections strings
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SourceDbDefaultConnection"));
    ////Only using the target!!!!!!!!!!!!!!!
    //options.UseSqlServer(builder.Configuration.GetConnectionString("TargetDBDefaultConnection"));
});
builder.Services.AddDbContext<TDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TargetDBDefaultConnection"));
});

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
