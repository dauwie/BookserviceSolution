﻿using Bookservice.WebAPI.Data;
using Bookservice.WebAPI.Repositories;
using Bookservice.WebAPI.Services.AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bookservice.WebAPI
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
            var config = new AutoMapper.MapperConfiguration(cfg => 
                                                cfg.AddProfile(new AutoMapperProfileConfiguration()));
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddDbContext<BookServiceContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("BookService"))
                );

            services.AddScoped<BookRepository>();
            services.AddScoped<AuthorRepository>();
            services.AddScoped<PublisherRepository>();
            services.AddScoped<ReaderRepository>();
            services.AddScoped<RatingRepository>();

            services.AddCors();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
