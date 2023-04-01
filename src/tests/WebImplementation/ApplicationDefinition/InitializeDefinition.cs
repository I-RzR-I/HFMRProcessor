// ***********************************************************************
//  Assembly         : RzR.Services.WebImplementation
//  Author           : RzR
//  Created On       : 2023-03-30 18:55
// 
//  Last Modified By : RzR
//  Last Modified On : 2023-03-30 19:07
// ***********************************************************************
//  <copyright file="InitializeDefinition.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using AppInitDefinitionDecorate;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

#endregion

namespace WebImplementation.ApplicationDefinition
{
    public class InitializeDefinition : InitDefinitionDecorate
    {
        public InitializeDefinition()
        {
            base.InitializeOrder = -1;
            base.IsDecorationEnable = true;
        }

        /// <inheritdoc />
        public override void ServiceConfiguration(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
        }

        /// <inheritdoc />
        public override void ApplicationConfiguration(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}