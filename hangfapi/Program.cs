using hangfapi.Services;
using Hangfire;
using HangfireBasicAuthenticationFilter;

namespace hangfapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHangfire(config => config
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(builder.Configuration.GetConnectionString("baglanti")));

            builder.Services.AddTransient<IServiceManagement,ServiceManagement>();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
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

            app.UseHangfireDashboard("/hangfire", new DashboardOptions()
            {
                DashboardTitle = "Drivers Dashboard",
                Authorization = new[]
                {
                    new HangfireCustomBasicAuthenticationFilter()
                    {
                        Pass = "123",
                        User = "umutcanbu"
                    }
                }
            });

            app.MapHangfireDashboard();
            RecurringJob.AddOrUpdate<IServiceManagement>(x => x.SyncData(), Cron.Minutely);

            app.Run();
        }
    }
}