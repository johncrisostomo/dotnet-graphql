﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using GraphQL;
using GraphQL.Http;
using GraphQL.Server.Transports.AspNetCore;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using ProjectSchema;
using ProjectSchema.Types;

namespace dotnet_graphql
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
            services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddMvc();
            services.AddSingleton<SchemaData>();
            services.AddSingleton<RootQuery>();
            services.AddSingleton<UserType>();
            services.AddSingleton<ISchema, GQLSchema>();

            services.AddGraphQLHttp();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphQLHttp<ISchema>(new GraphQLHttpOptions());

            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

            app.UseMvc();
        }
    }
}
