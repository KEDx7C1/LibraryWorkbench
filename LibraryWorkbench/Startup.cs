using LibraryWorkbench.Converters;
using LibraryWorkbench.Core;
using LibraryWorkbench.Core.Interfaces;
using LibraryWorkbench.Data;
using LibraryWorkbench.Data.Intefaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;

namespace LibraryWorkbench
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
            }).AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new DateTimeOffsetConverter());
            }).AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });

            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString,
                b=>b.MigrationsAssembly("LibraryWorkbench")));

            services.AddScoped<PersonsService>();
            services.AddScoped<IPersonsService, PersonsService>(sp=>sp.GetService<PersonsService>());
            services.AddScoped<BooksService>();
            services.AddScoped<IBooksService, BooksService>(sp => sp.GetService <BooksService>());
            services.AddScoped<GenresServices>();
            services.AddScoped<IGenresServices, GenresServices>(sp => sp.GetService<GenresServices>());
            services.AddScoped<AuthorsService>();
            services.AddScoped<IAuthorsService, AuthorsService>(sp => sp.GetService<AuthorsService>());

            services.AddScoped<IAuthorsRepository, AuthorsRepository>();
            services.AddScoped<IBooksRepository, BooksRepository>();
            services.AddScoped<IGenresRepository, GenresRepository>();
            services.AddScoped<IPersonsRepository, PersonsRepository>();

            services.AddScoped<DataContext>();
            services.AddScoped<IDataContext, DataContext>(sp => sp.GetService<DataContext>());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
