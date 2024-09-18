
using Microsoft.EntityFrameworkCore;
using SecretClientTasksBackend.API_Setup;
using SecretClientTasksBackend.DBContexts;
using SecretClientTasksBackend.Repository;

var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddWebApi(typeof(Program));

            var objBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
            IConfiguration conManager = objBuilder.Build();
            var conn = conManager.GetConnectionString("SCTasksDB");

            builder.Services.AddDbContext<SCTasksDBContext>(options =>
            {
                options.UseSqlServer(conn);
            });
            builder.Services.AddTransient<ISCTaskRepository, SCTaskRepository>();
            builder.Services.AddTransient<ICsvFileRepository, CsvFileRepository>();

var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            await app.RegisterWebApisAsync();
            await app.RunAsync();
