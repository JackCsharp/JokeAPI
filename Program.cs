global using JokeAPI.Model;
global using Microsoft.EntityFrameworkCore;
global using JokeAPI.Data;
using JokeAPI.Services.JokeService;
using JokeAPI.Services.GuildService;
using JokeAPI.Services.UserService;
using JokeAPI.Services.CommentService;
using JokeAPI.Services.CommentReplyService;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IJokeService, JokeService>();
builder.Services.AddScoped<IGuildService, GuildService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICommentReplyService, CommentReplyService>();


builder.Services.AddDbContext<DataContext>();

builder.Services.AddCors(o => o.AddPolicy("AllowAll", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
