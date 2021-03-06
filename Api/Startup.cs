﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Liberry_v2.Repositories;
using Liberry_v2.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Api
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
            services.AddMvc();
            services.AddTransient<IBookRepository,BookRepository>();
            services.AddTransient<IUserRepository,UserRepository>();
            services.AddTransient<IBookService,BookService>();
            services.AddTransient<IUserService,UserService>();
            services.AddTransient<IReviewService,ReviewService>();
            services.AddTransient<ILoanService,LoanService>();
            services.AddTransient<IRecommendationService,RecommendationService>();
            services.AddDbContext<AppDataContext>(options => options.UseSqlite("Data source=../Repositories/Liberry_v2.db",
            b => b.MigrationsAssembly("Api")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
