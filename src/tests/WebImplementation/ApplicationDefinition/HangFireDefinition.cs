// ***********************************************************************
//  Assembly         : RzR.Services.WebImplementation
//  Author           : RzR
//  Created On       : 2023-03-30 18:55
// 
//  Last Modified By : RzR
//  Last Modified On : 2023-03-30 19:07
// ***********************************************************************
//  <copyright file="HangFireDefinition.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System.Collections.Generic;
using AppInitDefinitionDecorate;
using Hangfire.Dashboard;
using HFMRProcessor;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

#endregion

namespace WebImplementation.ApplicationDefinition
{
    public class HangFireDefinition : InitDefinitionDecorate
    {
        public HangFireDefinition()
        {
            base.InitializeOrder = 2;
            base.IsDecorationEnable = true;
        }

        /// <inheritdoc />
        public override void ServiceConfiguration(IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureHangFireServices(configuration);

            services.RegisterProcessorAsServer(configuration);
        }

        /// <inheritdoc />
        public override void ApplicationConfiguration(IApplicationBuilder app, IHostEnvironment env)
        {
            app.UseCustomHangFireDashboard("/hangfire", new List<IDashboardAsyncAuthorizationFilter>());
        }
    }
}